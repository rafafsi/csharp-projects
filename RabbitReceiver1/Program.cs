using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
factory.ClientProvidedName = "RabbitMQ Receiver 1";

IConnection connection = factory.CreateConnection();
IModel channel = connection.CreateModel();

var exchange = "exchange-demo";
var routingKey = "routing-key-demo";
var queue = "queue-demo";

channel.ExchangeDeclare(exchange, ExchangeType.Direct, true, false);
channel.QueueDeclare(queue, false, false, false, null);
channel.QueueBind(queue, exchange, routingKey);

// channel quality of service 
channel.BasicQos(0, 1, false);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (sender, args) =>
{
	Task.Delay(TimeSpan.FromSeconds(5)).Wait();
	var body = args.Body.ToArray();
	string message = Encoding.UTF8.GetString(body);
	Console.WriteLine($"Message received: {message}");
	channel.BasicAck(args.DeliveryTag, false);
};

string consumerTag = channel.BasicConsume(queue, false, consumer);
Console.ReadLine();
channel.BasicCancel(consumerTag);
channel.Close();
connection.Close();