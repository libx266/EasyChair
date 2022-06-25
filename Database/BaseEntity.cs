using EasyChair2.Utlis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyChair2.Database
{
    public abstract class BaseEntity : NotifyPropertyBase
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(64)]
        public virtual string Name { get; set; }

        [NotMapped]
        public object? Tag { get; set; }

        public override string ToString() => Name;

        public virtual void Cache() => throw new NotImplementedException();

        protected static EfModel E => EfModel.Instance;

        public static implicit operator bool(BaseEntity? e) => e != null;
    }
}
