using System.Collections.Generic;
using System.Threading.Tasks;

namespace VesalBahra.Core.Interfaces
{
    public interface IGeneralServices<Tkey, Tindex, TCreateOrEdit>
        where Tkey : struct
    where Tindex : IIndex<Tkey>
    where TCreateOrEdit : ICreateOrEdit<Tkey>
    {
        Task<List<Tindex>> GteAll();
        Task<bool> Add(TCreateOrEdit model);
        Task<bool> Update(TCreateOrEdit model);
        Task<bool> Remove(Tkey id);
        Task<TCreateOrEdit> Find(Tkey id);
        Task<bool> IsExist(Tkey id);
    }
}