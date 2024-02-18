using Practica.Data;
using Practica.Dtos;
using Practica.Modelos;

namespace Practica.Repositorys
{
    public class PeliculaRepository : IPeliculaRepository
    {

        private readonly PeliculasDbContext _dbContext;

        public PeliculaRepository(PeliculasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddPelicula(Pelicula pelicula)
        {
            _dbContext.Peliculas.Add(pelicula);
            _dbContext.SaveChanges();
        }

        public void DeletePelicula(int id)
        {
            Pelicula seleccionada = _dbContext.Peliculas.FirstOrDefault(x => x.Id == id);
            if (seleccionada != null)
            {
                _dbContext.Remove(seleccionada);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Pelicula> GetAllPeliculas()
        {
            return _dbContext.Peliculas.ToList();
        }

        public Pelicula GetPelicula(int id)
        {
            return _dbContext.Peliculas.FirstOrDefault(x => x.Id == id);

        }

        public void UpdatePelicula(Pelicula pelicula)
        {
            _dbContext.Peliculas.Update(pelicula);
            _dbContext.SaveChanges();
        }
    }
}
