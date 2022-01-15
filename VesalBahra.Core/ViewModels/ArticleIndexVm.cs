using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VesalBahra.Core.Interfaces;

namespace VesalBahra.Core.ViewModels
{
    public class ArticleIndexVm : IIndex<int>
    {
        public int Id { get; set; }

        [Display(Name = "عنوان مقاله")]
        public string Title { get; set; }

        [Display(Name = "عنوان سربرگ مقاله")]
        public string HeadTitle { get; set; }

        [Display(Name = "عنوان عکس")]
        public string ImageTitle { get; set; }

        #region General

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "تاریخ ویرایش")]
        public DateTime? ModifyDate { get; set; }

        #endregion
    }
}
