using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VesalBahra.Core.Interfaces
{
    public interface IArticleServices : IGeneralService<int, ProductIndexVm, ProductCreateOrEditVm>
    {
        IPagedList<ProductDetailVm> GetProductsByGroupId(int groupId, int page = 1);
        ProductDetailVm GetProductDetail(int productId);
    }
}
