using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VesalBahar.Domine.Base
{
   public class BaseEntity<TKey> where TKey : struct
    {
        [Key]
        public TKey Id { get; set; }
        public bool IsDelete { get; set; }
    }
}
