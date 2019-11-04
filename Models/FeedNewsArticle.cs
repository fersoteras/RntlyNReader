using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsreaderWebApp.Models
{
    public class FeedNewsArticle
    {
        public  int FeedNewsArticleId { get;  set; }
        public int FeedId { get; set; }   // the feed to wich this article belongs.

        [StringLength(150)]
        public string Title { get; set; }   // this is the head in usenet parlance.

        [StringLength(1000)]
        public string content { get; set; } // this is the body in usenet parlance

        public DateTime ArticleDate { get; set; } // date  required to sort news chronolgically.
    }
}