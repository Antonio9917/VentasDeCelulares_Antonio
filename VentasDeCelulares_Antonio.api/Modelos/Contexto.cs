using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace VentasDeCelulares_Antonio.api.Modelos
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> Options) : base(Options)
        {

        }

        public DbSet<Compania> Compania { get; set; }

        public DbSet<Caracterisiticas> Caracterisitcas { get; set; }

        public DbSet<Marca> Marca { get; set; }

        public DbSet<Model> Model { get; set; }
    }
}
