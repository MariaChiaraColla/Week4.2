using GestioneOrdini.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneOrdini.EF.Config
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            //chiavi
            builder.HasKey(k => k.ID);

            //proprietà
            builder.Property(c => c.ClientCode).IsRequired().HasMaxLength(5);
            builder.Property(f => f.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(l => l.LastName).IsRequired().HasMaxLength(50);

            //relazioni
            builder.HasMany(c => c.ClientOrders).WithOne(o => o.Customer);
        }
    }
}
