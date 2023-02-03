using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFWpf2App
{
    public class Country
    {
        public int Id { set; get; }
        public string Title { set; get; } = null!;
        List<Company> Companies { set; get; } = new();

        public override string ToString()
        {
            return Title;
        }
    }
    public class Company
    {
        public int Id { set; get; }
        public string Title { set; get; } = null!;
        public Country? Country { set; get; }
        public int CountryId { set; get; }
        public List<Employe> Employes { set; get; } = new();
    }
    public class Position
    {
        public int Id { set; get; }
        public string Title { set; get; } = null!;
        List<Employe> Employes { set; get; } = new();
    }
    public class Employe
    {
        public int Id { set; get; }
        public string Name { set; get; } = null!;
        public Company? Company { set; get; }
        public int CompanyId { set; get; }
        public Position? Position { set; get; }
        public int PositionId { set; get; }
    }
    public class AppContext : DbContext
    {
        public DbSet<Employe> Employes { set; get; }
        public DbSet<Company> Companies { set; get; }
        public DbSet<Country> Countries { set; get; }
        public DbSet<Position> Positions { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CompanyDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
