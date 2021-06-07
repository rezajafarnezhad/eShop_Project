using _0_Framework.Application;
using ShopManagement.Application.Contract.Comment;
using ShopManagement.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class CommentApplication : ICommentApplication
    {

        private readonly ICommentRepo _commentRepo;
        public CommentApplication(ICommentRepo commentRepo)
        {
            _commentRepo = commentRepo;
        }

        public OperationResult AddComment(AddComment command)
        {
            OperationResult operationResult = new OperationResult();

            var comment = new Comment(command.Name, command.Email, command.Message, command.ProductId);
            _commentRepo.Create(comment);
            _commentRepo.Save();
            return operationResult.Succeeded();


        }

        public OperationResult Cancel(long id)
        {
            OperationResult operationResult = new OperationResult();
            var comment = _commentRepo.Get(id);
            if (comment == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);
            }

            comment.Cancel();
            _commentRepo.Save();
            return operationResult.Succeeded();
        }

        public List<CommentViewModel> Comments()
        {
            return _commentRepo.Comments();
        }

        public OperationResult Confirm(long id)
        {
            OperationResult operationResult = new OperationResult();
            var comment = _commentRepo.Get(id);
            if (comment == null)
            {
                return operationResult.Failed(ApplicationMessage.recordNotFound);
            }

            comment.confirm();
            _commentRepo.Save();
            return operationResult.Succeeded();
        }

        public CommentReview Review(long id)
        {
            return _commentRepo.Review(id);
        }
    }
}
