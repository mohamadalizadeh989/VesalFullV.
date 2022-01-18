using System;

namespace VesalBahar.Core.Interfaces
{
    public interface IAdminIndexViewModel<TKey> 
        where TKey:struct
    {
        public TKey Id { get; set; }


        public DateTime CreateDate { get; set; }
    }
}