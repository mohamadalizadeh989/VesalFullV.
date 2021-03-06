using System;

namespace VesalBahar.Core.Interfaces
{
    public interface IAdminCreateOrEditViewModel<TKey> 
        where TKey:struct
    {
        public TKey Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}