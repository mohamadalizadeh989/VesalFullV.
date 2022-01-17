using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VesalBahar.Domine.Base;

namespace VesalBahar.Domine.Entities.Articles
{
    public class ArticleGroup : BaseEntity<int>, IAudiTable
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        #region Auditable
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        #endregion

        #region Relations
        public ICollection<Article> Articles { get; set; }
        #endregion
    }
}   
