using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Domain.Concrete.Base
{
    public class Entity
    {
        [Column(Order = 1)]
        public int Id { get; set; }
        [Column(Order = 2)]
        public bool IsActive { get; set; }
   
        [Column(Order = 3)]
        public DateTime CreatedDate { get; set; }
    }
}
