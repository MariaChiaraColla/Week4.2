using GestioneOrdini.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneOrdini.EF.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //chiavi
            builder.HasKey(k => k.ID);

            //proprietà
            builder.Property(d => d.OrderDate).IsRequired();
            builder.Property(c => c.OrderCode).IsRequired().HasMaxLength(5);
            builder.Property(p => p.ProductCode).IsRequired().HasMaxLength(5);

            //relazioni
            builder.HasOne(o => o.Customer).WithMany(c => c.ClientOrders);
        }
    }
}
