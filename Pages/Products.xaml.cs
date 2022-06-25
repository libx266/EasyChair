using EasyChair2.Database;
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

namespace EasyChair2.Pages
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Page
    {

        const string searchInfo = "Введите для поиска";

        static EfModel E => EfModel.Instance;

        IEnumerable<Product> products;

        bool init = false;

        private class Sort
        {
            internal string Text;
            internal Func<Product, Object> Func;

            public override string ToString() => Text;
        }

        public static Action UpdateData;

        public Products()
        {
            InitializeComponent();
            init = true;

            var sortInfo = "Наименование;Тип;Номер цеха;Стоимость агента;Стоимость материаллов".Split(';').ToList();
            
            var sortFunc = new List<Func<Product, Object>>
            {
                P => P.Name,
                P => P.Type.Name,
                P => P.WorkshopNumber,
                P => P.MinCostAgent,
                P => P.CostMaterials
            };

            sortInfo.ForEach(s => $"▲ {s};▼ {s}".Split(';').ToList()
            .ForEach(i => CbSort.Items.Add(new Sort
            {
                Text = i,
                Func = sortFunc[sortInfo.IndexOf(s)]
            })));

            var filt = new List<object> { "Все типы" };
            filt.AddRange(E.ProductTypes.ToList());
            CbFilt.ItemsSource = filt;

            UpdateData = () => UpdateView(edited: true);
            UpdateData.Invoke();

        }


        private void SearchGotFocus(object sender, RoutedEventArgs e)
        {
            var tb = sender as TextBox;
            if (tb.Text == searchInfo)
                tb.Text = "";
        }

        private void SearchLostFocus(object sender, RoutedEventArgs e)
        {
            var tb = sender as TextBox;
            if (tb.Text == "")
                tb.Text = searchInfo;
        }


        private void SearchChanged(object sender, TextChangedEventArgs e) => UpdateViewAsync();

        private void SortChanged(object sender, SelectionChangedEventArgs e) => UpdateViewAsync(updateData: false);

        private void FiltChanged(object sender, SelectionChangedEventArgs e) => UpdateViewAsync();
    

        private void GeneratePagination()
        {
            int count = products.Count() / 20 + Convert.ToInt32(products.Count() % 20 != 0);

            PagePanel.Children.Clear();

            for (int i = 0; i < count; i++)
            {
                var button = new Button
                {
                    Background = Brushes.White,
                    BorderThickness = new Thickness(0, 0, 0, 0),
                    FontSize = 22,
                    Content = (i + 1).ToString(),
                    Tag = i,
                    Margin = new Thickness(2, 0, 2, 0),
                };

                if (i == 0) button.FontWeight = FontWeights.Bold;

                button.Click += new RoutedEventHandler((s, e) =>
                {
                    foreach (var child in PagePanel.Children)
                        (child as Button).FontWeight = FontWeights.Normal;

                    var b = s as Button;
                    b.FontWeight = FontWeights.Bold;

                    UpdateViewAsync((int)b.Tag, false, false);
                });

                PagePanel.Children.Add(button);
            }
        }

        private void FiltData(bool edited)
        {
            string search = TbSearch.Text;

            products = Product.GetRepository(edited).Where(P =>
            {
                var filt = CbFilt.SelectedItem as ProductType;
                bool filter = !filt || P.Type.ID == filt.ID;

                bool searcher = search == searchInfo ||
                (
                    P.Name
                    + P.Type.Name
                    + P.MATERIALS
                )
                .ToLower().Contains(search.ToLower());

                return filter && searcher;
            });
        }

        private void SortData()
        {
            var sort = CbSort.SelectedItem as Sort;

            if (sort is not null)
            {
                products = sort.Text.Contains('▲')
                    ? products.OrderBy(sort.Func)
                    : products.OrderByDescending(sort.Func);
            }
        }

        private void UpdateView(int page = 0, bool updateData = true, bool sortData=true, bool edited = false)
        {
            if (!init) return;

            if (updateData)
            {
                FiltData(edited);
                GeneratePagination();
            }

            if (sortData) SortData();

            var view = products.Skip(page * 20).Take(20);
            
            TbCount.Text = $"На экране: {view.Count()}  |  Подготовлено: {products.Count()}  |  Всего: {E.Products.Count()}";
            
            LvProducts.ItemsSource = view;
        }

        private void UpdateViewAsync(int page = 0, bool updateData = true, bool sortData=true, bool edited = false) => 
            Dispatcher.InvokeAsync(() => UpdateView(page, updateData, sortData, edited));

    }
}
