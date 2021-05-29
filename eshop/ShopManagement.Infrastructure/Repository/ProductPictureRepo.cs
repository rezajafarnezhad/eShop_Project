using _0_Framework.Application;
using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.Repository
{
    public class ProductPictureRepo : RepositoryBase<long, ProductPicture>, IProductPictureRepo
    {
        private readonly DBContext _context;

        public ProductPictureRepo(DBContext context) : base(context)
        {
            _context = context;
        }


        public EditproductPicture GetForEdit(long id)
        {
            var Productpic = _context.ProductPictures.Find(id);

            return new EditproductPicture()
            {
                Id = Productpic.Id,
                PictureAlt = Productpic.PictureAlt,
                PictureName = Productpic.PictureName,
                PictureTitle = Productpic.PictureTitle,
                ProductId = Productpic.ProductId
            };

        }



        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            var query = _context.ProductPictures.Include(c=>c.Product).Select(c => new ProductPictureViewModel()
            {
                Id = c.Id,
                CreationDate = c.CreationDate.ToFarsi(),
                IsRemoved = c.IsRemove,
                PictureName = c.PictureName,
                ProductName = c.Product.Name,
                ProductId = c.ProductId
            });
            if (searchModel.ProductId !=0)
            {
                query = query.Where(c => c.ProductId == searchModel.ProductId);
            }

            return query.OrderByDescending(c => c.Id).ToList();
        }
    }
}
