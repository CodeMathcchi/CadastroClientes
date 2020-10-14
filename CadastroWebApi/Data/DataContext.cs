using Microsoft.EntityFrameworkCore;
using CadastroWebApi.Models;
using MySql.Data.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CadastroWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
            .HasData(new List<Cliente>(){
                new Cliente(1, "Matheus Gomes Roberto dos Santos", new DateTime(1995, 12, 14), "Masculino", "95055-268", "Rua Alfeiros", "4", "", "Muggles", "PR", "Maringá"),
                new Cliente(2, "Lucas Souza de Gois", new DateTime(1999, 12, 27), "Masculino", "95055-268", "Rua Alfeiros", "4", "", "Muggles", "PR", "Maringá"),
                new Cliente(3, "Bethy da Silva", new DateTime(1941, 2, 21), "Feminino", "823489-025", "Alameda Yaya", "257", "", "Gopauva", "SP", "São Paulo"),
                new Cliente(4, "Lívia Bernardo", new DateTime(1996, 1, 17), "Feminino", "78964-568", "Rua da Toalha", "42", "Apt. 1101", "Fim do Universo", "PR", "Maringá")
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;database=clientesdb;user=matheusgr;password=1234");
            }
        }
    }
}