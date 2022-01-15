using System;

namespace VesalBahra.Core.Interfaces
{
    public interface ICreateOrEdit<TKey> where TKey:struct
    {
        public TKey Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}