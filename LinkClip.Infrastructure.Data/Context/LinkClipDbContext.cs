
using LinkClip.Domain.Models.Account;
using LinkClip.Domain.Models.Link;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LinkClip.Infrastructure.Data.Context
{
    public class LinkClipDbContext : DbContext
    {
        public LinkClipDbContext(DbContextOptions<LinkClipDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }


        //link
        public DbSet<LinkShortener> LinkShorteners { get; set; }
        public DbSet<Browser> Browsers { get; set; }
        public DbSet<OS> OS { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<RequestUrl> RequestUrls { get; set; }

        



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(s=> s.GetForeignKeys()))
            {
                relation.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
        }


    }
}
