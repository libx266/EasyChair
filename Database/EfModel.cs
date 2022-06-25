using EasyChair2.Database.Entities;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyChair2.Database
{
    public sealed partial class EfModel : DbContext
    {
        private EfModel() : base() => Database.EnsureCreated();

        internal static MySqlConnectionStringBuilder Settings { private get; set; }

        private static EfModel? instance;

        public static EfModel Instance => instance ??= new EfModel();

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
           options.UseMySQL(Settings.ConnectionString);

        protected override void OnModelCreating(ModelBuilder builder) =>
            builder.Entity<Product>().Property(m => m.ImageData).IsRequired(false);
    }
}
