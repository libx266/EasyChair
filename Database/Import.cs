using EasyChair2.Database.Entities;
using RabbitCrypt.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyChair2.Database
{
    internal static class Import
    {
        static EfModel E => EfModel.Instance;



        private static void Parse<T>(string path, char delimiter, bool head, Func<string[], T?> parser, Action<T> insert) where T : BaseEntity
        {
            foreach(string row in File.ReadAllLines(path).Skip(Convert.ToInt32(head)))
            {
                string[] items = row.Split(delimiter).
                    Select(s => s.Trim(' ')).ToArray();

                T item = parser(items);
                if (item) insert(item);
                E.SaveChanges();
            }
        }

        internal static void InsertData()
        {
            Parse<Material>("./material.txt", ',', true, R => 
            {
                string type = R[1];

                return new Material
                {
                    Name = R[0],
                    Type = E.MaterialTypes.FirstOrDefault(M => M.Name == type) ?? new MaterialType { Name = type },
                    PackQuan = (int)R[2].ToDecimal(),
                    Unit = R[3],
                    StoreQuan = (int)R[4].ToDecimal(),
                    MinRemaindQuan = (int)R[5].ToDecimal(),
                    Cost = R[6].ToDecimal(),
                };
            },
            M => E.Materials.Add(M));


            Parse<Product>("./product.csv", ';', true, R =>
            {
                string type = R[4];
                string file = "./furniture/" + R[3].Split(@"\"[0]).Last();

                var product = new Product
                {
                    Name = R[0],
                    Article = (long)R[1].ToDecimal(),
                    MinCostAgent = R[2].ToDecimal(),
                    ImageData = File.Exists(file) ? File.ReadAllBytes(file).ToBase256() : "",
                    Type = E.ProductTypes.FirstOrDefault(P => P.Name == type) ?? new ProductType { Name = type },
                    PersonalRequired = (short)R[5].ToDecimal(),
                    WorkshopNumber = (short)R[6].ToDecimal()
                };

                return product;
            },
            P => E.Products.Add(P));


            Parse<ProductMaterial>("./productmaterial.csv", ';', true, R =>
            {
                try
                {
                    string product = R[0];
                    string material = R[1];
                    return new ProductMaterial
                    {
                        Product = E.Products.First(P => P.Name == product),
                        Material = E.Materials.First(M => M.Name == material),
                        Quan = (int)R[2].ToDecimal()
                    };
                }
                catch (Exception ex) { ex.ErrorCli(); return null; }
            },
            PM => E.ProductMaterials.Add(PM));
        }
    }
}
