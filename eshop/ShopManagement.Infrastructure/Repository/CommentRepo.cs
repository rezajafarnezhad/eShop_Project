using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.Comment;
using ShopManagement.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.Repository
{
    public class CommentRepo : RepositoryBase<long, Comment>, ICommentRepo
    {
        private readonly DBContext _context;

        public CommentRepo(DBContext context) : base(context)
        {
            _context = context;
        }
        
        public List<CommentViewModel> Comments()
        {
            return _context.Comments.Include(c => c.Product).Select(c => new CommentViewModel()
            {
                Id = c.Id,
                CreationDate = c.CreationDate.ToFarsi(),
                Email = c.Email,
                Message = c.Message,
                Statuses = c.Status,
                Name = c.Name,
                ProductId = c.ProductId,
                ProductName = c.Product.Name,

            }).OrderByDescending(c => c.Id).ToList();
        }

        public CommentReview Review(long id)
        {

            var comment = _context.Comments.Find(id);

            return new CommentReview()
            {
                Id = comment.Id,
                Message = comment.Message
            };


        }
    }
}
