using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using VesalBahar.Domine.Base;

namespace VesalBahar.Domine.Entities.Articles
{
    public class Article : BaseEntity<int>, IAudiTable
    {
        public int GroupId { get; set; }
        [Required]
        [MaxLength(300)]
        public string Title { get; set; }
        [Required]
        [MaxLength(200)]
        public string HeadTitle { get; set; }

        [Required]
        [MaxLength(int.MaxValue)]
        public string Description { get; set; }
        public string ImageTitle { get; set; }

        #region General
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        #endregion


        #region Relations

        public ArticleGroup Group { get; set; }
        
        #endregion
    }
}
