using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using NewsreaderWebApp.DAL;
using NewsreaderWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace NewsreaderWebApp.Controllers
{
    public class NewsHomeController : Controller
    {
        private NewsContext db;
        private ApplicationUser user;
        private NewsUserProfile profile;
        public NewsHomeController()
        {
            // initialize news context , user id.
            db = new NewsContext();
            user  = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            //There's a profile for this user? if not create one , if is there , retrieve it.
           profile = this.RetrieveOrCreate(user);
        }

        public ActionResult Index(int ?id )
        {
            // create a valid first ViewModel with data required by current state of application.
            MssgNavViewModels vm = new MssgNavViewModels();
         
            // retrieve this user newsReading profile data to saludate user on app banner.
            var userName = User.Identity.Name;
           
       

            // list of channels this user is subscribed.
            var channels = db.Channels.Where(ch => ch.UserProfile.ID == profile.ID);
            int[] ids = channels.Select(x => x.FeedChannelID).ToArray();

            // return articles of selected channels only.

            vm.Messages = db.Articles.Where( arty => ids.Contains(arty.FeedId)).ToList();
            if (id == null) { vm.LastMessageViewed = 0; } else { vm.LastMessageViewed = (int)id; };
            return View(vm);
        }
        [HttpGet]
        public ActionResult FeedsIndex()
        {
           // var vm = new  ChannelSelectionViewModel();
            var coll = new List<FeedSelectionViewModel>();
            // assemble a list of vms

            // all channels.
            var list = db.Channels;

            //index list of those channels currently subscribed by current user.
            var subsChannels = db.Channels.Where(ch => ch.UserProfile.ID == profile.ID);
            int[] ids = subsChannels.Select(x => x.FeedChannelID).ToArray();

            foreach (var feedItem in list)
            {
                //ids contains result is ID?
                bool contained = ids.Contains(feedItem.FeedChannelID);

                var newVm = new FeedSelectionViewModel( ) { FeedID = feedItem.FeedChannelID , FeedName = feedItem.FeedChannelName , FeedSelected = contained   };
              coll.Add(newVm);
            }
          //  vm.AvailableChannels= coll;
            return View(coll);
        }

       

 

        // GET: NewsHome/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            } else
            {
                // instantiate vm
                var cnl =(FeedChannel) db.Channels.First(ch => ch.FeedChannelID == id);
                //   var newVm = new FeedSelectionViewModel( ) { FeedID = feedItem.FeedChannelID , FeedName = feedItem.FeedChannelName , FeedSelected = contained   };
                var newVm = new FeedSelectionViewModel() { FeedID = cnl.FeedChannelID, FeedName = cnl.FeedChannelName  };
                return View(newVm);

            }
           
        }
        [HttpPost]
        public ActionResult EditDetails(FeedSelectionViewModel vm)
        {
            if (vm == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            };
            //if user tickled add to feed radio button , add this to the list of feeds current user is following.
            try
            {

                var id = vm.FeedID;
                FeedChannel chn = (FeedChannel)db.Channels.First(ch => ch.FeedChannelID == id);
                profile.SelectedChannels.Add(chn);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $@"Unable to save the record. {ex.Message}");
                return View(vm);
            }



            return RedirectToAction("FeedsIndex");

        }

    



        private NewsUserProfile RetrieveOrCreate(ApplicationUser usr)
        {
            // stub , return first user for now.
          return   db.UserProfiles.First();

        }
    }
}