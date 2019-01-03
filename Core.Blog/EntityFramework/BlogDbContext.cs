using Core.Blog.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Blog.EntityFramework
{
    public class BlogDbContext:DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        
        }

        public DbSet<AdvertisementInfo> AdvertisementInfo { get; set; }
        public DbSet<ArticleCommentsInfo> ArticleCommentsInfo { get; set; }
        public DbSet<BlogPostsInfo> BlogPostsInfo { get; set; }
        public DbSet<TechnologyClassifyInfo> TechnologyClassifyInfo { get; set; }
        public DbSet<UserCollectInfo> UserCollectInfo { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdvertisementInfo>().ToTable("AdvertisementInfo");
            modelBuilder.Entity<ArticleCommentsInfo>().ToTable("ArticleCommentsInfo");
            modelBuilder.Entity<BlogPostsInfo>().ToTable("BlogPostsInfo");
            modelBuilder.Entity<TechnologyClassifyInfo>().ToTable("TechnologyClassifyInfo");
            modelBuilder.Entity<UserCollectInfo>().ToTable("UserCollectInfo");
            modelBuilder.Entity<UserInfo>().ToTable("UserInfo");
        }


    }
}
