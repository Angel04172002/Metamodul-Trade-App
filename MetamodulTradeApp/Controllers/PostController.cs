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

        public PostController(IPostService _postService)
        {
            postService = _postService;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PostAllViewModel model)
        {
            
            var posts = await postService.GetAllPostsAsync(
                model.SearchTerm
                ,PostAllViewModel.PostsPerPage, 
                model.CurrentPage);

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
            //if(!DateTime.TryParseExact(
            //    model.CreatedOn,
            //    DataConstants.DateFormat,
            //    CultureInfo.InvariantCulture,
            //    DateTimeStyles.None,
            //    out DateTime date
            //    ))
            //{
            //    ModelState.AddModelError(nameof(model.CreatedOn), "Invalid date format!");
            //}

            model.CreatorId = User.Id();
            model.CreatedOn = DateTime.Now.ToString();

            if (!ModelState.IsValid)
            {
                return View(model);
            }


            await postService.AddPostAsync(model);


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]   
        public async Task<IActionResult> Edit(int id)
        {
            var post = await postService.GetPostByIdAsync(id);

            if(post == null)
            {
                return BadRequest();
            }

            PostFormViewModel model = new PostFormViewModel()
            {
                ImageUrl = post.ImageUrl,
                Description = post.Description,
                CreatedOn = post.CreatedOn,
                Title = post.Title
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(PostFormViewModel model, int id)
        {
            var post = await postService.GetPostByIdAsync(id);

            if (post == null)
            {
                return BadRequest();
            }

            if(ModelState.IsValid == false)
            {
                return View(model);
            }

            await postService.EditPostAsync(model, id);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {

            var post = await postService.GetPostByIdAsync(id);

            if(post == null)
            {
                return BadRequest();
            }
                
            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveConfirmed(int id)
        {
            var post = await postService.GetPostByIdAsync(id);

            if(post == null)
            {
                return BadRequest();
            }

            await postService.RemovePostAsync(id);

            return RedirectToAction(nameof(Index));
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
