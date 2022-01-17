using System.Collections.Generic;
using System.Threading.Tasks;


namespace VesalBahar.Core.Interfaces
{
    public interface IGeneralService<Tkey, TIndex, TCreateOrEdit>
        where Tkey : struct
        where TIndex : IIndex<Tkey>
        where TCreateOrEdit : ICreateOrEdit<Tkey>
    {
        Task<List<TIndex>> GetAllAsync();
        Task<bool> AddAsync(TCreateOrEdit model);
        Task<bool> EditAsync(TCreateOrEdit model); 
        Task<bool> DeleteAsync(Tkey id);
        Task<TCreateOrEdit> FindAsync(Tkey id);
        Task<bool> Exists(Tkey id);
    }
}