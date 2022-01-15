using System;

namespace VesalBahar.Domine.Base
{
    public interface IAudiTable
    {
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}