using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NewsreaderWebApp.Models
{
    public class FeedChannel
    {
        
        public int FeedChannelID {get; set; }

        [StringLength(50)]
        public string FeedChannelName { get; set; }

        public ICollection<FeedNewsArticle> NewsArticles { get; set; }

        public virtual NewsUserProfile UserProfile { get; set; }
         

    }
}