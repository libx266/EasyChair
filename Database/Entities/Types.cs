using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyChair2.Database.Entities
{
    [Table(nameof(ProductType))]
    public class ProductType : BaseEntity { }

    [Table(nameof(MaterialType))]
    public class MaterialType : BaseEntity { }

}
