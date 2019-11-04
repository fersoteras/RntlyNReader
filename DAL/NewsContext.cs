using NewsreaderWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NewsreaderWebApp.DAL
{ 
    public class NewsContext : DbContext
    {
        public NewsContext(): base("name=NewsContextConnString")
        {
           
        }

        public DbSet<FeedChannel> Channels { get; set; }

        public DbSet<FeedNewsArticle> Articles { get; set; }

        public  DbSet<NewsUserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // prevent table names for being pluralized.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}