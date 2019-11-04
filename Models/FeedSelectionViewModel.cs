using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsreaderWebApp.Models
{
    public class FeedSelectionViewModel
    {
        //feed id
        public int FeedID { get; set; }
        //feed name 
        [Display(Name = "Feed Name")]
        public string FeedName { get; set; }
        //feed selected
        [Display(Name = "Select Feed to view messages")]
        public bool FeedSelected { get; set; }
    }
}