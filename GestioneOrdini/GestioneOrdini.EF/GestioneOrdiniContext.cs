using GestioneOrdini.EF.Config;
using GestioneOrdini.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneOrdini.EF
{
    public class GestioneOrdiniContext : DbContext
    {
        public GestioneOrdiniContext() : base() { }
        public GestioneOrdiniContext(DbContextOptions<GestioneOrdiniContext> options) : base(options) { }

        //tabelle
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }

        //configurazione con il db
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Persist Security Info = False; Integrated Security = true; Initial Catalog = OrderManagement; Server = .\SQLEXPRESS");
        }

        //creo le relazioni con le fluent api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Client>(new ClientConfiguration());
            modelBuilder.ApplyConfiguration<Order>(new OrderConfiguration());
        }
    }
}
