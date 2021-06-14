﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_eshopQuery.Contracts.Article
{
    public class ArticleQueryModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
        public string KeyWords { get; set; }
        public string MetaDescription { get; set; }
        public string CanonicalAddress { get; set; }
        public bool IsRemoved { get; set; }
        public string PublishDate { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<string> KeywordList { get; set; }
    }
}
