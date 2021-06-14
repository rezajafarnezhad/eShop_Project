using _0_Framework.Domain;
using BlogManagement.Domain.ArticleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public class ArticleCategory : EntityBase
    {

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Slug { get; private set; }
        public int ShowOrder { get; private set; }

        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public string CanonicalAddress { get; private set; }

        public List<Article> Articles { get; private set; }

        public ArticleCategory(string name, string description, string slug, int showOrder, string keyWords,
            string metaDescription, string canonicalAddress)
        {
            Name = name;
            Description = description;
            Slug = slug;
            ShowOrder = showOrder;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            Articles = new List<Article>();
        }

        public void Edit(string name, string description, string slug, int showOrder, string keyWords,
            string metaDescription, string canonicalAddress)
        {
            Name = name;
            Description = description;
            Slug = slug;
            ShowOrder = showOrder;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
        }
    }
}
