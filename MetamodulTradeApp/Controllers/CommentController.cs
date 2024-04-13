using MetamodulTradeApp.Attributes;
using MetamodulTradeApp.Core.Exceptions;
using MetamodulTradeApp.Core.Models.Comment;
using MetamodulTradeApp.Core.Models.Post;
using MetamodulTradeApp.Core.Services;
using MetamodulTradeApp.Core.Services.Contracts;
using MetamodulTradeApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Security.Claims;

namespace MetamodulTradeApp.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly ILogger logger;

        public CommentController(
            ICommentService _commentService,
            ILogger<CommentController> _logger)
        {
            commentService = _commentService;
            logger = _logger;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new CommentFormViewModel();

            return View(model);
        }

        [HttpPost]
        [GetQueryId]
        public async Task<IActionResult> Add(CommentFormViewModel model)
        {
            if(ModelState.IsValid == false) 
            {
                var a = Request.GetDisplayUrl();
                return RedirectToAction("Details", "Post", new { id = Request.QueryString });

                
            }

            await commentService.AddCommentAsync(model);

            return RedirectToAction("Details", "Post", new { id = Request.QueryString });
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
                //PostId = comment.PostId,
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

            try
            {
                await commentService.EditCommentAsync(id, model);
            }
            catch(NullEntityModelException neme)
            {
                logger.LogError(neme, "CommentController/Edit");
                return BadRequest();
            }

 

            return RedirectToAction("Details", "Post", new { id  });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await commentService.GetCommentByIdAsync(id);

            if (comment == null)
            {
                return BadRequest();
            }

            if(comment.CreatorId != User.Id())
            {
                return Unauthorized();
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

            if (comment.CreatorId != User.Id())
            {
                return Unauthorized();
            }

            try
            {
                await commentService.DeleteCommentAsync(id);
            }
            catch (NullEntityModelException neme)
            {
                logger.LogError(neme, "CommentController/DeleteConfirmed");
                return BadRequest();
            }

            return RedirectToAction("Details", "Post", new { id });
        }
    }
}
