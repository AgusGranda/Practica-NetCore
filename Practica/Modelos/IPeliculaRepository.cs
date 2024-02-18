using Practica.Dtos;

namespace Practica.Modelos
{
    public interface IPeliculaRepository
    {

        IEnumerable<Pelicula> GetAllPeliculas();
        Pelicula GetPelicula(int id);
        void AddPelicula(Pelicula pelicula);
        void UpdatePelicula(Pelicula pelicula);
        void DeletePelicula(int id);

    }
}
