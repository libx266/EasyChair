using EasyChair2.Database.Entities;
using System;
using System.Collections.Generic;
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

namespace EasyChair2.Controls
{
    /// <summary>
    /// Interaction logic for ProductControl.xaml
    /// </summary>
    public partial class ProductControl : UserControl
    {
        public ProductControl()
        {
            InitializeComponent();
            Main.ContextMenu ??= new ContextMenu();

            var add = new MenuItem { Header = "Добавить" };
            add.Click += new RoutedEventHandler((s, e) => new Windows.ProductAddEdit().ShowDialog());

            var edit = new MenuItem { Header = "Редактировать" };
            edit.Click += new RoutedEventHandler((s, e) => new Windows.ProductAddEdit(this.Get<Product>()).ShowDialog());

            var remove = new MenuItem { Header = "Удалить" };
            remove.Click += new RoutedEventHandler((s, e) =>
            {
                if ("Вы уверены?".Warning())
                {
                    this.Get<Product>().CascadeDelete();
                    Pages.Products.UpdateData();
                }
            });

            Main.ContextMenu.ItemsSource = new MenuItem[] { add, edit, remove };
        }
    }
}
