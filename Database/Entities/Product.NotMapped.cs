using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyChair2.Database.Entities
{
    public partial class Product
    {

        [NotMapped]
        public virtual IEnumerable<ProductMaterial> Materials
        {
            get => ProductMaterial.Repository.Where(PM => PM.ProductID == ID);
            set
            {
                E.ProductMaterials.AddRange(value);
                NotifyProperty(nameof(MATERIALS));
            }
        }

        [NotMapped]
        public bool MaterialExists => E.ProductMaterials.Any(PM => PM.ProductID == ID);

        [NotMapped]
        public string MATERIALS { get; private set; }

        [NotMapped]
        public string TYPE { get; private set; }

        [NotMapped]
        public string TITLE => String.Format("{0} | {1}", TYPE, Name);

        [NotMapped]
        public string PRICE => String.Format("Агент: {0} руб.", Math.Round(Math.Abs(MinCostAgent), 2));

        [NotMapped]
        public double CostMaterials { get; private set; }

        [NotMapped]
        public string COST => String.Format("Материалы: {0} руб.", CostMaterials);

        public override void Cache()
        {
            TYPE = Type.Name;
            MATERIALS = MaterialExists ? "Материалы:  " + String.Join(", ", Materials) : "Материалы не указаны";
            CostMaterials = MaterialExists ? Math.Round((double)Materials.Sum(M => M.Quan * M.Material.Cost), 2) : Double.NaN;
        }
        
        public void CascadeDelete()
        {
            E.ProductMaterials.RemoveRange(Materials);
            E.SaveChanges();

            E.Products.Remove(this);
            E.SaveChanges();
        }

        private static HashSet<Product> repository = new();

        internal static ICollection<Product> GetRepository(bool update) =>
            update ? repository = E.Products.ToHashSet().Cache() : repository;

        internal static ICollection<Product> Repository =>
            GetRepository(E.Products.Count() != repository.Count);
    }
}
