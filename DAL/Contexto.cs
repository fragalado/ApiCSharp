using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aseguramos el uso de Ids autoincrementales.
            modelBuilder.UseSerialColumns();

            // Forma para cambiarle el nombre a las tablas
            modelBuilder.Entity<Usuario>()
                .ToTable("usuarios");
            modelBuilder.Entity<Acceso>()
                .ToTable("accesos");
        }

        // Los DbSet
        // Un DbSet es una clase que representa una colección de entidades de un tipo específico.
        // Se utiliza para realizar operaciones de consulta y modificación en la base de datos.
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Acceso> Accesos { get; set; }

    }
}
