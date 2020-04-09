using AcaiApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiApp.Data.Context
{
    public class AcaiContext : DbContext
    {
        public AcaiContext(DbContextOptions<AcaiContext> options) : base(options) 
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Adicional> Adicionals { get; set; }
        public DbSet<PedidoAdicional> PedidosAdicionais { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ModelBuilderPedido(builder);
            ModelBuilderAdicional(builder);
            ModelBuilderPedidoAdicional(builder);
        }

        private void ModelBuilderPedido(ModelBuilder builder)
        {
            builder.Entity<Pedido>().ToTable("Pedido");
            builder.Entity<Pedido>().HasKey(p => p.Id);
            builder.Entity<Pedido>().Property(p => p.Id).IsRequired();
            builder.Entity<Pedido>().Property(p => p.ValorTotal).HasColumnType("decimal(5,3)").IsRequired();
            builder.Entity<Pedido>().Property(p => p.Tamanho);
            builder.Entity<Pedido>().Property(p => p.Sabores);
        }

        private void ModelBuilderAdicional(ModelBuilder builder)
        {
            builder.Entity<Adicional>().ToTable("Adicional");
            builder.Entity<Adicional>().HasKey(p => p.Id);
            builder.Entity<Adicional>().Property(p => p.Id).IsRequired();
            builder.Entity<Adicional>().Property(p => p.TempoPreparo).IsRequired();
            builder.Entity<Adicional>().Property(p => p.ValorAdicional).HasColumnType("decimal(5,3)").IsRequired();
        }

        private void ModelBuilderPedidoAdicional(ModelBuilder builder)
        {
            builder.Entity<PedidoAdicional>().ToTable("Pedido_Adicional");
            builder.Entity<PedidoAdicional>().HasKey(p => new { p.IdAdicional, p.Id });
            builder.Entity<PedidoAdicional>().Property(p => p.IdAdicional).IsRequired();
            builder.Entity<PedidoAdicional>().Property(p => p.Id).IsRequired();
        }
    }
}
