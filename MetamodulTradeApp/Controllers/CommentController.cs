using MetamodulTradeApp.Core.Models.Comment;
using MetamodulTradeApp.Core.Models.Post;
using MetamodulTradeApp.Core.Services;
using MetamodulTradeApp.Core.Services.Contracts;
using MetamodulTradeApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MetamodulTradeApp.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService _commentService)
        {
            commentService = _commentService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new CommentFormViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CommentFormViewModel model)
        {
            if(ModelState.IsValid == false) 
            {
                return View(model);
            }

            await commentService.AddCommentAsync(model);

            return RedirectToAction("Details", "Post", new { id = model.PostId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var comment = await commentService.GetCommentByIdAsync(id);

            if(comment == null)
            {
                return BadRequest();
            }


            if(comment.CreatorId != User.Id())
            {
                return Unauthorized();
            }

            var model = new CommentFormViewModel()
            {
                Text = comment.Text,
                PostId = comment.PostId,
                CreatorId = comment.CreatorId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,  CommentFormViewModel model)
        {
            var comment = await commentService.GetCommentByIdAsync(id);

            if (comment == null)
            {
                return BadRequest();
            }

            if (model.CreatorId != User.Id())
            {
                return Unauthorized();
            }

            if(ModelState.IsValid == false)
            {
                return View(model);
            }

            await commentService.EditCommentAsync(id, model);

            return RedirectToAction("Details", "Post", new { id = model.PostId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await commentService.GetCommentByIdAsync(id);

            if (comment == null)
            {
                return BadRequest();
            }

            var model = new CommentDeleteFormViewModel()
            {
                Text = comment.Text,
                CreatedOn = comment.CreatedOn
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await commentService.GetCommentByIdAsync(id);

            if (comment == null)
            {
                return BadRequest();
            }

            await commentService.DeleteCommentAsync(id);

            return RedirectToAction("Details", "Post", new { id });
        }
    }
}
