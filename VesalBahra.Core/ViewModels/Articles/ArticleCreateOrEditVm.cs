using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VesalBahar.Core.Interfaces;
using VesalBahar.Core.Statics;

namespace VesalBahar.Core.ViewModels.Articles
{
    public class ArticleCreateOrEditVm: ICreateOrEdit<int>
    {
        public int Id { get; set; }

        [Display(Name = "گروه محصول")]
        public int GroupId { get; set; }

        [Display(Name = "عنوان مقاله")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "عنوان سربرگ مقاله")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string HeadTitle { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "تصویر محصول")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "عنوان تصویر")]
        public string ImageTitle { get; set; }

        public string ImageFullName =>
            !string.IsNullOrEmpty(ImageTitle)
                ? $"{PathTools.ArticleImagePath}{ImageTitle}"
                : PathTools.ArticleImageDefautl;

        #region General

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "تاریخ ویرایش")]
        public DateTime ModifyDate { get; set; }

        #endregion
    }
}
