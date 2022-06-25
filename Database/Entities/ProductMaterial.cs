using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyChair2.Database.Entities
{
    [Table(nameof(ProductMaterial))]
    public partial class ProductMaterial : BaseEntity
    {
        public int ProductID { get; set; }
        public int MaterialID { get; set; }

        public int Quan { get; set; }

    }
}
