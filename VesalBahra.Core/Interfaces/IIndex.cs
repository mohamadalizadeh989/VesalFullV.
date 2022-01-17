using System;

namespace VesalBahar.Core.Interfaces
{
    public interface IIndex<TKey> 
        where TKey:struct
    {
        public TKey Id { get; set; }


        public DateTime CreateDate { get; set; }
    }
}