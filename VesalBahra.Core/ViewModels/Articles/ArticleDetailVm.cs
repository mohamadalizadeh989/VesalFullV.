using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VesalBahar.Core.Statics;

namespace VesalBahar.Core.ViewModels.Articles
{
    public class ArticleDetailVm
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string Title { get; set; }
        public string HeadTitle { get; set; }
        public string Description { get; set; }
        public string ImageTitle { get; set; }

        public string ImageFullName =>
            !string.IsNullOrEmpty(ImageTitle)
                ? $"{PathTools.ArticleImagePath}{ImageTitle}"
                : PathTools.ArticleImageDefautl;

        #region General
        
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        #endregion
    }
}
