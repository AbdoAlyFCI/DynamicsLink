using DynamicsLink.Models.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicsLink.Models.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasMany(s => s.Items)
                .WithOne(i => i.Store)
                .HasForeignKey(i => i.StoreId);

                entity.HasMany(s => s.Invoices)
                .WithOne(i => i.Store)
                .HasForeignKey(i => i.StoreId);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasMany(s => s.Units)
                .WithOne(i => i.Item)
                .HasForeignKey(i => i.ItemId);
            });

            modelBuilder.Entity<InvoiceItem>(entity =>
            {
                entity.HasKey(pk => new { pk.InvoiceId, pk.ItemId });

                entity.HasOne<Invoice>(i => i.Invoice)
                .WithMany(t => t.InvoiceItems)
                .HasForeignKey(i => i.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Item>(i => i.Item)
                .WithMany(t => t.InvoiceItems)
                .HasForeignKey(i => i.ItemId);

            });




        }
    }
}
