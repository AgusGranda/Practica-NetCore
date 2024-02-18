using Microsoft.EntityFrameworkCore;
using Practica.Dtos;

namespace Practica.Data
{
    public class PeliculasDbContext : DbContext
    {
        public PeliculasDbContext(DbContextOptions<PeliculasDbContext> options) : base(options)
        {
            fillPeliculas();
        }


        public DbSet<Pelicula> Peliculas { get; set; }

        private void fillPeliculas()
        {
            if (Peliculas.Count() == 0)
            {
                Peliculas.Add(new Pelicula {Id=1,Descripcion= "Pelicula Genial",Genero ="Aventura",Duracion=157 });
                Peliculas.Add(new Pelicula {Id=2,Descripcion= "Peliculon",Genero ="Accion",Duracion=180 });
                Peliculas.Add(new Pelicula {Id=3,Descripcion= "Peliculasa",Genero ="Drama",Duracion=250 });
                this.SaveChanges();
            }
        }

    }
}
