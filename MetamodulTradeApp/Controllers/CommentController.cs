using MetamodulTradeApp.Core.Models.Comment;
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
        public async Task<IActionResult> Add()
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

            return RedirectToAction();
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


            return RedirectToAction();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,  CommentFormViewModel model)
        {

            if (model.CreatorId != User.Id())
            {
                return Unauthorized();
            }

            if(ModelState.IsValid == false)
            {
                return View(model);
            }

            await commentService.EditCommentAsync(id, model);

            return RedirectToAction();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction();
        }
    }
}
