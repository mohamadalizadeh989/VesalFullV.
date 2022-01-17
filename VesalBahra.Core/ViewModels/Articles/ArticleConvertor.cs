using VesalBahar.Domine.Entities.Articles;
using System.Collections.Generic;
using System.Linq;

namespace VesalBahar.Core.ViewModels.Articles
{
    public static class ArticleConvertor
    {
        public static ArticleDetailVm ToDetailViewModel(this Article article)
        {
            if (article == null) return null;
            return new ArticleDetailVm
            {
                Id = article.Id,
                GroupId = article.GroupId,
                GroupName = article.Group?.Title,
                Title = article.Title,
                HeadTitle = article.HeadTitle,
                Description = article.Description,
                ImageTitle = article.ImageTitle
            };
        }

        #region ToCreateOrEditViewModel

        public static ArticleCreateOrEditVm ToCreateOrEditViewModel(this Article article)
        {
            if (article == null) return null;
            return new ArticleCreateOrEditVm
            {
                Id = article.Id,
                GroupId = article.GroupId,
                Title = article.Title,
                HeadTitle = article.HeadTitle,
                Description = article.Description,
                ImageTitle = article.ImageTitle
            };
        }

        public static IQueryable<ArticleCreateOrEditVm> ToCreateOrEditViewModel(this IQueryable<Article> articles)
        {
            return articles.Select(c => c.ToCreateOrEditViewModel());
        }

        #endregion


        #region ToIndexViewModel

        public static ArticleIndexVm ToIndexViewModel(this Article article)
        {
            if (article == null) return null;
            return new ArticleIndexVm
            {
                Id = article.Id,
                CreateDate = article.CreateDate,
                ModifyDate = article.ModifyDate,
                Title = article.Title,
                GroupName = article.Group.Title,
                HeadTitle = article.HeadTitle,
                ImageTitle = article.ImageTitle,

            };
        }
        public static IEnumerable<ArticleIndexVm> ToIndexViewModel(this IEnumerable<Article> articles)
        {
            return articles.Select(c => c.ToIndexViewModel());
        }
        public static IQueryable<ArticleIndexVm> ToIndexViewModel(this IQueryable<Article> articles)
        {
            return articles.Select(c => c.ToIndexViewModel());
        }

        #endregion
    }
}
