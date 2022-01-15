using System;

namespace VesalBahra.Core.Interfaces
{
    public interface IIndex<Tkey> where Tkey:struct
    {
        public Tkey Id { get; set; }


        public DateTime CreateDate { get; set; }
    }
}