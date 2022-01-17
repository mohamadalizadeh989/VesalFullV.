using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VesalBahar.Domine.Entities.Articles;

namespace VesalBahar.Core.ViewModels.ArticleGroups    
{
    public static class ArticleGroupConvertor
    {
        public static ArticleGroupCreateOrEditVm ToCreateOrEditViewModel(this ArticleGroup group)
        {
            return new ArticleGroupCreateOrEditVm
            {
                CreateDate = group.CreateDate,
                Id = group.Id,
                Title = group.Title
                //LastModifyDate = group.LastModifyDate
            };
        }
        public static IQueryable<ArticleGroupCreateOrEditVm> ToCreateOrEditViewModel(this IQueryable<ArticleGroup> groups)
        {
            return groups.Select(c => c.ToCreateOrEditViewModel());
        }

        public static ArticleGroupIndexVm ToIndexViewModel(this ArticleGroup group)
        {
            return new ArticleGroupIndexVm
            {                
                Id = group.Id,        
                Title = group.Title,
                CreateDate = group.CreateDate,
                ModifyDate = group.ModifyDate
            };
        }
        public static IEnumerable<ArticleGroupIndexVm> ToIndexViewModel(this IEnumerable<ArticleGroup> groups)
        {
            return groups.Select(c => c.ToIndexViewModel());
        }
        public static IQueryable<ArticleGroupIndexVm> ToIndexViewModel(this IQueryable<ArticleGroup> groups)
        {
            return groups.Select(c => c.ToIndexViewModel());
        }
    }
}
