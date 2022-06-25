using EasyChair2.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyChair2.Windows
{
    public class ProductAddEdit : MainWindow
    {
        public ProductAddEdit(Product? product = null)
        {
            Navigator.Navigate(new Pages.PruductAddEdit(product, Close));
            Title = (product ? "Редактирование" : "Добавление") + " товара";
        }
        protected override void Setup() => InitializeComponent();
    }
}
