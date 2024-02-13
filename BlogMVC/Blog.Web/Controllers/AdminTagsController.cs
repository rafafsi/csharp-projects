using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
	{
	public class AdminTagsController : Controller
		{
		// to use this context inside this file it's possible to declare either as a private variable
		// private BlogDbContext _blogDbContext;
		// or as a readonly property (ctrl+. to generate)
		private readonly BlogDbContext blogDbContext;

		public AdminTagsController(BlogDbContext blogDbContext)
			{
			// _blogDbContext = blogDbContext;
			this.blogDbContext = blogDbContext;
			}

		[HttpGet]
		public IActionResult Add()
			{
			return View();
			}

		[HttpPost]
		public IActionResult Add(AddTagRequest addTagRequest)
			{
			var tag = new Tag
				{
				Name = addTagRequest.Name,
				DisplayName = addTagRequest.DisplayName
				};

			blogDbContext.Tags.Add(tag);
			blogDbContext.SaveChanges();

			return View("Add");
			}

		[HttpGet]
		public IActionResult Created()
			{
			return View("Created");
			}
		}
	}

