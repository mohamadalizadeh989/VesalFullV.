using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VesalBahar.Core.ViewModels.ArticleGroups;

namespace VesalBahar.Core.Interfaces
{
    public interface IArticleGroupService : IGeneralService<int, ArticleGroupIndexVm, ArticleGroupCreateOrEditVm>
    {

    }
}
