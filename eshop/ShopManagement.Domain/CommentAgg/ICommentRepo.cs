using _0_Framework.Domain;
using ShopManagement.Application.Contract.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.CommentAgg
{
    public interface ICommentRepo : IRepository<long, Comment>
    {
        List<CommentViewModel> Comments();
        CommentReview Review(long id);

    }
}
