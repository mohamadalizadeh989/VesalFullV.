using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using VesalBahar.Domine.Base;

namespace VesalBahar.Domine.Entities.Sliders
{
    public class Article : BaseEntity<int>, IAudiTable
    {
        public string Title { get; set; }
        public string HeadTitle { get; set; }
        public string Description { get; set; }
        public string ImageTitle { get; set; }

        #region General
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        #endregion
    }
}
