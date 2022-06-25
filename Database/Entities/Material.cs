using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyChair2.Database.Entities
{
    [Table(nameof(Material))]
    public class Material : BaseEntity
    {
        public virtual MaterialType Type { get; set; }

        public int PackQuan { get; set; }

        public int StoreQuan { get; set; }

        public int MinRemaindQuan { get; set; }

        public decimal Cost { get; set; }

        [MaxLength(8)]
        public string Unit { get; set; }


    }
}
