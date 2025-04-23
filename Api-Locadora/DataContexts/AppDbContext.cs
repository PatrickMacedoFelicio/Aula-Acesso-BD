
using Api_Locadora.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Locadora.DataContexts
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Estudio> Estudios { get; set; }
        public DbSet<Genero> Generos { get; set; }

    }
}
