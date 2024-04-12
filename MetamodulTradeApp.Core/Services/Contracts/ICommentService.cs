using MetamodulTradeApp.Core.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetamodulTradeApp.Core.Services.Contracts
{
    public interface ICommentService
    {

        Task AddCommentAsync(CommentFormViewModel model);

        Task EditCommentAsync(int id, CommentFormViewModel model);

        Task DeleteCommentAsync(int id);

        Task<CommentAllViewModel?> GetCommentByIdAsync(int id);
    }
}
