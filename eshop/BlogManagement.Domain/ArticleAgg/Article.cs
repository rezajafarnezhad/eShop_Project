using _0_Framework.Domain;
using BlogManagement.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Domain.ArticleAgg
{
    public class Article : EntityBase
    {

        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public string CanonicalAddress { get; private set; }
        public bool IsRemoved { get; private set; }
        public DateTime PublishDate { get; private set; }
        public long CategoryId { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }

        public Article(string title, string shortDescription, string description, string picture,
            string pictureAlt, string pictureTitle, string slug, string keyWords,
            string metaDescription, string canonicalAddress, DateTime publishdate, long categoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;
            PublishDate = publishdate;
            IsRemoved = false;
        }

        public void Edit(string title, string shortDescription, string description, string picture,
            string pictureAlt, string pictureTitle, string slug, string keyWords,
            string metaDescription, string canonicalAddress, DateTime publishdate, long categoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Description = description;

            if (!string.IsNullOrWhiteSpace(picture))
            {
                Picture = picture;
            }

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            PublishDate = publishdate;
            CategoryId = categoryId;
        }


        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = false;
        }


        public Article()
        {

        }
    }
}
