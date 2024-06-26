﻿using MetamodulTradeApp.Core.Exceptions;
using MetamodulTradeApp.Core.Models.Admin;
using MetamodulTradeApp.Core.Models.Post;
using MetamodulTradeApp.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace MetamodulTradeApp.Areas.Admin.Controllers
{
    public class PostController : AdminBaseController
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
                , PostAllViewModel.PostsPerPage,
                model.CurrentPage);


            model.TotalPostsCount = posts.TotalPostsCount;
            model.Posts = posts.Posts;


            return View(model);
        }


        [HttpGet]
        public IActionResult Add()
        {
            var model = new PostFormViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostFormViewModel model)
        {

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

            if (post == null)
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

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            try
            {

                await postService.EditPostAsync(model, id);

            }
            catch (NullEntityModelException neme)
            {
                logger.LogError(neme, "PostController/Edit");
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            var post = await postService.GetPostByIdAsync(id);

            if (post == null)
            {
                return BadRequest();
            }

            var model = new PostDeleteFormViewModel()
            {
                Id = post.Id,
                CreatedOn = DateTime.Parse(post.CreatedOn),
                Title = post.Title,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await postService.GetPostByIdAsync(id);

            if (post == null)
            {
                return BadRequest();
            }

            try
            {
                await postService.RemovePostAsync(id);
            }
            catch (NullEntityModelException neme)
            {
                logger.LogError(neme, "PostController/DeleteConfirmed");
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var postDetails = await postService.GetDetailsAsync(id);

            if (postDetails == null)
            {
                return BadRequest();
            }


            return View(postDetails);
        }
    }
}
