using _0_Framework.Domain;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.CommentAgg
{
    public class Comment : EntityBase
    {

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public int Status { get; private set; }

        public long ProductId { get; private set; }
        public Product Product { get; private set; }

        public Comment(string name, string email, string message, long productid)
        {
            Name = name;
            Email = email;
            Message = message;
            ProductId = productid;
            Status = Statuses.New;
        }
        public void confirm()
        {
            Status = Statuses.Confirmed;
        }

        public void Cancel()
        {
            Status = Statuses.Cancel;
        }

        public Comment()
        {
        }
    }
}
