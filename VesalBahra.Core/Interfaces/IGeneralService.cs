using System.Collections.Generic;
using System.Threading.Tasks;

namespace VesalBahra.Core.Interfaces
{
    public interface IGeneralService<Tkey, TIndex, TCreateOrEdit>
        where Tkey : struct
        where TIndex : IIndex<Tkey>
        where TCreateOrEdit : ICreateOrEdit<Tkey>
    {
        Task<List<TIndex>> GteAll();
        Task<bool> AddAsync(TCreateOrEdit model);
        Task<bool> UpdateAsync(TCreateOrEdit model); 
        Task<bool> RemoveAsync(Tkey id);
        Task<TCreateOrEdit> FindAsync(Tkey id);
        Task<bool> Exist(Tkey id);
    }
}