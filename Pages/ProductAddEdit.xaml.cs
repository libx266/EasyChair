using EasyChair2.Database;
using EasyChair2.Database.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasyChair2.Pages
{
    /// <summary>
    /// Interaction logic for PruductAddEdit.xaml
    /// </summary>
    public partial class PruductAddEdit : Page
    {
        static EfModel E => EfModel.Instance;
        List<ProductMaterial> materials;

        Action close;

        private void UpdateMaterials() => TbMaterials.Text = materials.Count > 0 ? "Материалы:  " + String.Join(", ", materials) : "Материалы не указаны";
        
        public PruductAddEdit(Product? product, Action close)
        {
            this.close = close;
            InitializeComponent();

            DataContext = product ??= new Product
            {
                Name = "Новый товар",
                Article = Random.Shared.Next(Int32.MaxValue),
                Type = E.ProductTypes.First(),
                MinCostAgent = 1488m,
                PersonalRequired = 1,
            };

            if(product.ID == 0)
            {
                E.Products.Add(product);
                E.SaveChanges();
            }

            CbType.ItemsSource = E.ProductTypes.ToList();
            CbType.SelectedItem = product.Type;

            CbMaterials.ItemsSource = E.Materials.ToList();

            materials = product.Materials.ToList();
            UpdateMaterials();
        }

       

        private void AddMaterial(object sender, RoutedEventArgs e)
        {
            var M = sender.Get<Material>();
            var P = this.Get<Product>();
            Func<ProductMaterial, Boolean> search = PM => PM.MaterialID == M.ID;

            if (materials.Any(search)) materials.First(search).Quan++;
            else materials.Add(new ProductMaterial
            {
                Product = P,
                Material = M,
                Quan = 1
            });

            E.SaveChanges();
            UpdateMaterials();
        }

        private void RemoveMaterial(object sender, RoutedEventArgs e)
        {
            var M = sender.Get<Material>();
            var P = this.Get<Product>();
            Func<ProductMaterial, Boolean> search = PM => PM.MaterialID == M.ID;

            if (materials.Any(search))
            {
                var pm = materials.First(search);
                if (pm.Quan > 0) pm.Quan--;
                else materials.Remove(pm);

            }
            else "Материалла нет в списке".Error();
          
            E.SaveChanges();
            UpdateMaterials();
        }


        private void SaveChanges(object sender, RoutedEventArgs e)
        {
             this.Get<Product>().Materials = materials;
             E.SaveChanges();
             Products.UpdateData();
             close();
        }

        private void ChangeImage(object sender, MouseButtonEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;";
            if (dialog.ShowDialog() ?? false)
            {
                this.Get<Product>().Image =
                    File.ReadAllBytes(dialog.FileName);
            }
        }
    }
}
