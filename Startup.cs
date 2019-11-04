using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Owin;
using NewsreaderWebApp.DAL;
using Owin;

[assembly: OwinStartup(typeof(NewsreaderWebApp.Startup))]

namespace NewsreaderWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Database.SetInitializer(new NewsInitializer());
        }
    }
}
