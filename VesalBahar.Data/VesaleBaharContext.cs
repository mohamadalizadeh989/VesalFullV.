using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VesalBahar.Domine.Entities.Sliders;

namespace VesalBahar.Data
{
    public class VesaleBaharContext:DbContext
    {
        public VesaleBaharContext(DbContextOptions<VesaleBaharContext> options):base(options)
        {
            
        }


        #region Dbset
        public DbSet<Article> Articles { get; set; }
        #endregion

        #region ModelBuilder

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasQueryFilter(A => !A.IsDelete);
            var data = new DateTime(2022, 01, 14);
            #region DataSeed
       
            #endregion
            base.OnModelCreating(modelBuilder);
        }

        #endregion

    }
}
