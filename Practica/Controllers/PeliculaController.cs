using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Practica.Dtos;

namespace Practica.Controllers
{

    [ApiController]
  
    [Route("api/[controller]")]


    public class PeliculaController : Controller
    {


        private static List<Pelicula> Peliculas = new()
        {
            new Pelicula { Id= 1 , Descripcion="Peliculon", Duracion=150, Genero="Fantasia"},
            new Pelicula { Id= 2 , Descripcion="Moviecon", Duracion=180, Genero="Terror"},
        };




        [HttpGet]
        public List<Pelicula> ShowAllPeliculas()
        {
            return Peliculas;
        }



        [HttpGet("{id}")]
        public Object ShowOnePelicula(int id)
        {

            Pelicula seleccionada = Peliculas.Find(x => x.Id == id);
            if (seleccionada != null)
                return seleccionada;
            else
                return "No se encontro la peliculita";


        }

        [HttpPost]
        public bool CreatePelicula(Pelicula pelicula)
        {
            Peliculas.Add(pelicula);
            return true;
        }


        [HttpPut("{id}")]
        public string UpdatePelicula(Pelicula pelicula, int id)
        {
            Pelicula seleccionada = Peliculas.Find(x => x.Id == id);

            if (seleccionada != null)
            {
                seleccionada.Duracion = pelicula.Duracion;
                seleccionada.Descripcion = pelicula.Descripcion;
                seleccionada.Genero = pelicula.Genero;
                return "Pelicula modificada correctamente";
            }
            else
                return "Pelicula no encontrada";


        }

        [HttpDelete("{id}")]
        public string DeletePelicula(int id)
        {
            Pelicula seleccionada = Peliculas.Find(x => x.Id == id);
            if (seleccionada != null)
            {
                Peliculas.Remove(seleccionada);
                return "Pelicula eliminada correctamente";
            }
            else
                return "Pelicula no encontrada";
        }

    }
}
