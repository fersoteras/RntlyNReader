using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsreaderWebApp.Models
{
    public class MssgNavViewModels
    {
        // 
        public IList<FeedChannel> SelectedChannels{get; set;}

        public IList<FeedNewsArticle> Messages { get; set; }

        public int LastMessageViewed { get; set; }

        public bool IsViewingAll { get; set; } = false;
    }
}