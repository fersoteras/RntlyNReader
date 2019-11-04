using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using NewsreaderWebApp.Models;

namespace NewsreaderWebApp.DAL
{
    public class NewsInitializer : System.Data.Entity.DropCreateDatabaseAlways<NewsContext>
    {

        public override void InitializeDatabase(NewsContext context)
        {
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                , string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

            base.InitializeDatabase(context);
        }
        protected override void Seed(NewsContext context )
        {

            //seed data
           
            

            // seed it with 10 articles.

            var articles = new List<FeedNewsArticle> {
                                            new FeedNewsArticle { FeedId=1 , Title="Reunion con Cliente1" , content="En esta reunion chequeamos que nuestras UserStories estan alineadas con los lineamientos de negocios de Cliente1.Lorem ipsum dolor sit amet, consetetur sadipscing elitr     sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam.  sed diam nonumy eirmod tempor.Lorem ipsum dolor sit amet, consetetur sadipscing elitr     sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam" , ArticleDate = new DateTime(2019 , 6 , 12 , 8 , 30 , 30 )},
                                            new FeedNewsArticle { FeedId=1 , Title="Nueva Reunion con Cliente1" , content="En esta reunion rechequeamos que nuestras UserStories estan alineadas con los lineamientos de negocios de Cliente1", ArticleDate = new DateTime(2019 , 6 , 15 , 8 , 30 , 30 )},
                                            new FeedNewsArticle{ FeedId =1, Title = "Cliente1 quiere chequear todo nuevamente", content = "En esta reunion modificamos nuestras UserStories, Cliente1 cambio de opinion nuevamente.  sed diam nonumy eirmod tempor",ArticleDate = new DateTime(2019 , 6 , 18 , 8 , 30 , 30 ) },

                                             new FeedNewsArticle { FeedId=2 , Title="uso de branching en Excepcions en C#8" , content= " era   sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum", ArticleDate = new DateTime(2019 , 6 , 13 , 8 , 30 , 30 )},
                                             new FeedNewsArticle { FeedId=2 , Title="implementacion de Async await a traves de State machines" , content="Lorem ipsum dolor sit amet, consetetur sadipscing elitr     sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam era   sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum.Lorem ipsum dolor sit amet, ", ArticleDate = new DateTime(2019 , 6 , 16 , 8 , 30 , 30 )},
                                             new FeedNewsArticle{ FeedId =2, Title = "C# Generics" , content = " Lorem ipsum dolor sit amet, consetetur sadipscing elitr     sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam era   sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum.Lorem ipsum dolor sit amet,      sed diam nonumy eirmod tempor ", ArticleDate = new DateTime(2019 , 6 , 19 , 8 , 30 , 30 ) },

                                              new FeedNewsArticle { FeedId=3 , Title="Proximo asado" , content="Lorem ipsum dolor sit amet, consetetur sadipscing elitr     sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam.  sed diam nonumy eirmod tempor.Lorem ipsum dolor sit amet, consetetur sadipscing elitr     sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam", ArticleDate = new DateTime(2019 , 6 , 14 , 8 , 30 , 30 )},
                                              new FeedNewsArticle { FeedId=3 , Title="Organizar partido de futbol" , content="Lorem ipsum dolor sit amet, consetetur sadipscing elitr     sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam.Lorem ipsum dolor sit amet, consetetur sadipscing elitr     sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam",ArticleDate = new DateTime(2019 , 6 , 17 , 8 , 30 , 30 )},
                                              new FeedNewsArticle{ FeedId =3, Title = "Happy hour", content = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr     sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam ", ArticleDate = new DateTime(2019 , 7 , 20 , 8 , 30 , 30 ) }
                                                                        };

            articles.ForEach(s => context.Articles.Add(s));
           

            //seed at least three channels.

            var feeds = new List<FeedChannel> {
                                                    new FeedChannel { FeedChannelName="Proximas reuniones"},
                                                    new FeedChannel { FeedChannelName="Noticias de C#"},
                                                    new FeedChannel { FeedChannelName="Noticias varias"}
                                                                        };
            feeds.ForEach(s => context.Channels.Add(s));

            // lastly , seed one user ,
            var users = new List<NewsUserProfile> {
                                                    new NewsUserProfile{ LastArticleSelected=1  , SelectedChannels= new List<FeedChannel>(){  feeds.ElementAt(0) , feeds.ElementAt(0) } }
                };
            users.ForEach(s => context.UserProfiles.Add(s));
            context.SaveChanges();


        }
    }
}