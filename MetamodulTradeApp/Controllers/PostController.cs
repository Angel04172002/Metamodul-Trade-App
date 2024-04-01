using MetamodulTradeApp.Core.Models.Post;
using MetamodulTradeApp.Core.Services.Contracts;
using MetamodulTradeApp.Infrastructure.Data.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace MetamodulTradeApp.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService _postService)
        {
            postService = _postService;
        }

        //Return view with all posts
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var posts = await postService.GetAllPostsAsync();

            return View(posts);
        }

        [HttpGet]
        [AllowAnonymous] 
        public IActionResult Add()
        {
            var model = new PostFormViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostFormViewModel model)
        {
            if(!DateTime.TryParseExact(
                model.CreatedOn,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime date
                ))
            {
                ModelState.AddModelError(nameof(model.CreatedOn), "Invalid date format!");
            }

            if(!ModelState.IsValid)
            {
                return View(model);
            }

            await postService.AddPostAsync(model);


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]   
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostFormViewModel model, int id)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Remove()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }
    }
}
