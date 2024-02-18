using Minimal_Api.Data;
using Minimal_Api.Modelos;

namespace Minimal_Api.Repositorys
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
            var pelicula = _dbContext.Peliculas.FirstOrDefault(x => x.Id == id);
            if (pelicula != null)
            {
                _dbContext.Peliculas.Remove(pelicula);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Pelicula> GetAllPeliculas()
        {
            return _dbContext.Peliculas.ToList();
        }

        public Pelicula GetPeliculaById(int id)
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
