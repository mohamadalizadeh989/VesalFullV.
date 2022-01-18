using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VesalBahar.Core.Interfaces;
using VesalBahar.Core.Statics;

namespace VesalBahar.Core.ViewModels.Articles
{
    public class ArticleIndexVm : IAdminIndexViewModel<int>
    {
        public int Id { get; set; }

        [Display(Name = "نام گروه")]
        public string GroupName { get; set; }

        [Display(Name = "عنوان مقاله")]
        public string Title { get; set; }

        [Display(Name = "عنوان سربرگ مقاله")]
        public string HeadTitle { get; set; }

        [Display(Name = "تصویر")]
        public string ImageTitle { get; set; }

        public string ImageFullName =>
            !string.IsNullOrEmpty(ImageTitle)
                ? $"{PathTools.ArticleImagePath}{ImageTitle}"
                : PathTools.ArticleImageDefautl;

        #region General

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "تاریخ ویرایش")]
        public DateTime? ModifyDate { get; set; }

        #endregion
    }
}
