using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoMais.Infrastructure.Configuration
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetStrConn());
            base.OnConfiguring(optionsBuilder);
        }

        private string GetStrConn()
        {
            var dataSource = "DESKTOP\\DESENVOLVIMENTO";
            var database = "creamt-gestao-biblioteca";
            var user = "sa";
            var password = "1234";

            return $"Data Source={dataSource};Initial Catalog={database};Integrated Security=False;User ID={user};Password={password};Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        }
    }
}
