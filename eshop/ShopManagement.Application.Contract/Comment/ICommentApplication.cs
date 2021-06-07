using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Comment
{
    public interface ICommentApplication
    {

        OperationResult AddComment(AddComment command);
        OperationResult Cancel(long id);
        OperationResult Confirm(long id);
        List<CommentViewModel> Comments();

        CommentReview Review(long id);


    }
}
