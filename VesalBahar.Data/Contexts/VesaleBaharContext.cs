using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VesalBahar.Domine.Entities.Articles;

namespace VesalBahar.Data.Contexts
{
    public class VesaleBaharContext : DbContext
    {
        public VesaleBaharContext(DbContextOptions<VesaleBaharContext> options) : base(options)
        {

        }


        #region Dbset
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleGroup> ArticleGroups { get; set; }
        #endregion

        #region ModelBuilder

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasQueryFilter(A => !A.IsDelete);
            var date = new DateTime(2022, 01, 14);

            modelBuilder.Entity<ArticleGroup>().HasData(new ArticleGroup
            {
                Id = 1,
                Title = "گروه اصلی",
                CreateDate = date
            });
            #region DataSeed

            #endregion
            base.OnModelCreating(modelBuilder);
        }

        #endregion

    }
}
