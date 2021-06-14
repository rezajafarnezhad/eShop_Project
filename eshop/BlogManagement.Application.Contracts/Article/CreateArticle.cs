using _0_Framework.Application;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application.Contracts.Article
{
    public class CreateArticle
    {

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Description { get; set; }
        public IFormFile Picture { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string PictureTitle { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }
        public string KeyWords { get; set; }
        public string MetaDescription { get; set; }
        public string CanonicalAddress { get; set; }
        public string PublishDate { get; set; }

        [Range(1, 1000, ErrorMessage = ValidationMessages.IsRequired)]
        public long CategoryId { get; set; }

       // public List<ArticleCategoryViewModel> ArticleCategories { get; set; }
    }

}
