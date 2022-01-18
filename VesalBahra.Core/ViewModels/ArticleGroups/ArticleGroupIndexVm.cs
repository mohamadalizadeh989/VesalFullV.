using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VesalBahar.Core.Interfaces;

namespace VesalBahar.Core.ViewModels.ArticleGroups
{
    public class ArticleGroupIndexVm : IAdminIndexViewModel<int>
    {
        public int Id { get; set; }
        [Display(Name = "عنوان گروه")]
        public string Title { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }
        [Display(Name ="تاریخ ویرایش")]
        public DateTime? ModifyDate { get; set; }
    }
}
