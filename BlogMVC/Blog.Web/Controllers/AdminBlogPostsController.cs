using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
    {
    public class AdminBlogPostsController : Controller
        {
        private readonly BlogDbContext blogDbContext;
        public AdminBlogPostsController(BlogDbContext blogDbContext)
            {
            this.blogDbContext = blogDbContext;
            }

        [HttpGet]
        public IActionResult Add()
            {
            return View();
            }
        [HttpPost]
        public IActionResult Add(AddBlogPostRequest addBlogPostRequest)
            {

            var blogPost = new BlogPost
                {
                Heading = addBlogPostRequest.Heading,
                PageTitle = addBlogPostRequest.PageTitle,
                Content = addBlogPostRequest.Content,
                ShortDescription = addBlogPostRequest.ShortDescription,
                FeaturedImageUrl = addBlogPostRequest.FeaturedImageUrl,
                UrlHandle = addBlogPostRequest.UrlHandle,
                PublishedDate = addBlogPostRequest.PublishedDate,
                Author = addBlogPostRequest.Author,
                Visible = addBlogPostRequest.Visible,
                };


            blogDbContext.Add(blogPost);
            blogDbContext.SaveChanges();

            return View(addBlogPostRequest);

            }
        }


    }
