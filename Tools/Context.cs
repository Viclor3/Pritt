using Microsoft.EntityFrameworkCore;
using Pritt.Entities;
using System;
using System.Configuration;
using System.Windows.Media.Animation;

namespace Pritt.Tools
{
    public class Context : DbContext
    {
        public Context()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=Pritt;username=root;password=;");
        }



        public DbSet<Gender> Genders { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Locality> Localities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<VaccinationType> VaccinationTypes { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<OrganizationType> OrganizationTypes { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<MunicipalContract> MunicipalContracts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }

    }
}
