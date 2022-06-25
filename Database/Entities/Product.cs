using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyChair2.Database.Entities
{
    [Table(nameof(Product))]
    public partial class Product : WithImage
    {

        public virtual ProductType Type { get; set; }
        
        public long Article { get; set; }

        public decimal MinCostAgent { get; set; }

        public short PersonalRequired { get; set; }

        public short WorkshopNumber { get; set; }

    }
}
