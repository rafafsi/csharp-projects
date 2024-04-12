using RabbitMQ.Client;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
factory.ClientProvidedName = "RabbitMQ Sender";

IConnection connection = factory.CreateConnection();
IModel channel = connection.CreateModel();

var exchange = "exchange-demo";
var routingKey = "routing-key-demo";
var queue = "queue-demo";

channel.ExchangeDeclare(exchange, ExchangeType.Direct, true, false);
channel.QueueDeclare(queue, false, false, false, null);
channel.QueueBind(queue, exchange, routingKey);


for (int i = 0; i < 60; i++)
	{
	Console.WriteLine($"Sending message: {i}");
	byte[] messageBody = Encoding.UTF8.GetBytes($"Message: #{i}");
	channel.BasicPublish(exchange, routingKey, null, messageBody);
	Thread.Sleep(1000);
	}


channel.Close();
connection.Close();