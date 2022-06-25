using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
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
using EasyChair2.Database;
using EasyChair2.Utlis;
using MySql.Data.MySqlClient;
using RabbitCrypt;
using RabbitCrypt.Extensions;
using SixLabors.ImageSharp.PixelFormats;

namespace EasyChair2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void InputSettings() => EfModel.Settings = new MySqlConnectionStringBuilder
        {
            Server = ExtendConsole.Input("IP"),
            Port = UInt16.Parse(ExtendConsole.Input("Port")),
            UserID = ExtendConsole.Input("Login"),
            Password = ExtendConsole.InputPassword("Password"),
            Database = ExtendConsole.Input("Database")
        };
        public MainWindow() => Setup();

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = !"Вы уверены?".Warning();
            base.OnClosing(e);
        }

        protected virtual async void Setup()
        {
            string dbPassword = ExtendConsole.InputPassword("Settings Store Password");

            if (SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(dbPassword)).ToBase64() == @"Hxi5M+ITnONEzqweoSC5/Gn/Q7GpMGgR6Xrfoxdp+js=")
            {
                EfModel.Settings = new MySqlConnectionStringBuilder(await ImageEngine.DecodeAsync
                (
                    SixLabors.ImageSharp.Image.Load<Rgb24>(Properties.Resources.B8_png),
                    SixLabors.ImageSharp.Image.Load<Rgb24>(Properties.Resources.ConnectionString_png),
                    dbPassword
                ));
                Console.WriteLine(EfModel.Instance.Products.Count());
            }
            else
            {
                Console.WriteLine("Invalid password, switch to manual input");
                bool incorrect = true;

                while (incorrect)
                {
                    try
                    {
                        InputSettings();
                        Console.WriteLine(EfModel.Instance.Products.Count());
                        incorrect = false;
                    }
                    catch (Exception ex) { ex.ErrorCli(); }
                }
            }

            if (0 == 1) Import.InsertData();
            
            InitializeComponent();

            Title = "Просмотр товаров";
            Navigator.Navigate(new Pages.Products());
        }
    }
}
