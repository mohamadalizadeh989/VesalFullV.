using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VesalBahar.Core.ViewModels;
using VesalBahar.Core.ViewModels.Articles;
using X.PagedList;

namespace VesalBahar.Core.Interfaces
{
    public interface IArticleService : IGeneralService<int, ArticleIndexVm, ArticleCreateOrEditVm>
    {
        IPagedList<ArticleDetailVm> GetArticlesByGroupId(int groupId, int page = 1);
        ArticleDetailVm GetArticleDetail(int articleId);
    }
}
