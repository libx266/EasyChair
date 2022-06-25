using EasyChair2.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyChair2.Database
{
    public sealed partial class EfModel
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Material> Materials { get; set; }

        public DbSet<ProductMaterial> ProductMaterials { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }

    }
}
