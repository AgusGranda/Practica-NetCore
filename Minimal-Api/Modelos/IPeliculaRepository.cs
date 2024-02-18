namespace Minimal_Api.Modelos
{
    public interface IPeliculaRepository
    {
        IEnumerable<Pelicula> GetAllPeliculas();
        Pelicula GetPeliculaById(int id);
        void AddPelicula(Pelicula pelicula);
        void UpdatePelicula(Pelicula pelicula);
        void DeletePelicula(int id);
    }
}
