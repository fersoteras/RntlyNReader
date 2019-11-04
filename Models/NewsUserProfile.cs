using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsreaderWebApp.Models
{
    //this entity have a one to many relationship with feeds.It also remeber the last 
    // NewsArticle selected by this User.
    public class NewsUserProfile
    {
        public int ID { get; set; }//primary key
        public int ProfileUserId { get; set; }
        public virtual ICollection<FeedChannel> SelectedChannels { get; set; }  //navigation property.
        public int LastArticleSelected { get; set; }
      
    }
}