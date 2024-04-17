using MetamodulTradeApp.Core.Exceptions;
using MetamodulTradeApp.Core.Models.Post;
using MetamodulTradeApp.Core.Services.Contracts;
using MetamodulTradeApp.Infrastructure.Data.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;

namespace MetamodulTradeApp.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostService postService;
        private readonly ILogger logger;

        public PostController(
            IPostService _postService,
            ILogger<PostController> _logger)
        {
            postService = _postService;
            logger = _logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PostAllViewModel model)
        {
            
            var posts = await postService.GetAllPostsAsync(
                model.SearchTerm
                ,PostAllViewModel.PostsPerPage, 
                model.CurrentPage);


            model.TotalPostsCount = posts.TotalPostsCount;
            model.Posts = posts.Posts;
            

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var postDetails = await postService.GetDetailsAsync(id);

            if(postDetails == null)
            {
                return BadRequest();
            }


            return View(postDetails);
        }
    }
}
