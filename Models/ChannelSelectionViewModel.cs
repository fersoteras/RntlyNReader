using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsreaderWebApp.Models
{
    public class ChannelSelectionViewModel
    {
        public IList<FeedSelectionViewModel> AvailableChannels { get; set; }

        public ChannelSelectionViewModel()
        {
            this.AvailableChannels = new List<FeedSelectionViewModel>();

        }

         public IEnumerable<int> getSelectedIds()
        {

            return (from p in this.AvailableChannels where p.FeedSelected select p.FeedID).ToList();
        }

    }
}