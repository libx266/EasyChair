using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitCrypt.Extensions;

namespace EasyChair2.Database
{
    public class WithImage : BaseEntity
    {
        //этот господин изъявляет крайнее недовольство
        //при сохранении значения типа null в поле byte[]?
        [Column(TypeName = "MEDIUMTEXT")]
        public string ImageData { get; set; } = "";

        [NotMapped]
        public byte[] Image
        {
            get => ImageData == "" ? Properties.Resources.picture : ImageData.FromBase256();
            set
            {
                ImageData = value.ToBase256();
                NotifyProperty();
            }
        }
    }
}
