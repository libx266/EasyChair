using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyChair2.Database.Entities
{
    public partial class ProductMaterial
    {
        [NotMapped]
        public override string Name => $"{Material.Name}:  {Quan}";

        [NotMapped]
        public virtual Product Product
        {
            get => E.Products.First(P => P.ID == ProductID);
            set => ProductID = value.ID;
        }

        [NotMapped]
        public virtual Material Material
        {
            get => E.Materials.First(M => M.ID == MaterialID);
            set => MaterialID = value.ID;
        }


        protected static HashSet<ProductMaterial> repository = new();

        internal static ICollection<ProductMaterial> GetRepository(bool update) =>
            update ? repository = E.ProductMaterials.ToHashSet() : repository;

        internal static ICollection<ProductMaterial> Repository =>
            GetRepository(repository.Count != E.ProductMaterials.Count());
    }
}
