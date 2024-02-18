using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Practica.Dtos;
using Practica.Modelos;

namespace Practica.Controllers
{

    [ApiController]
  
    [Route("api/[controller]")]


    public class PeliculaController : ControllerBase
    {

        private readonly IPeliculaRepository _peliculaRepository;
        
        public PeliculaController(IPeliculaRepository peliculaRepository)
        {
            _peliculaRepository = peliculaRepository;
        }



        [HttpGet]
        public IActionResult Get() 
        {
            var peliculas = _peliculaRepository.GetAllPeliculas();
            return Ok(peliculas);
        }



        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pelicula = _peliculaRepository.GetPelicula(id);
            return Ok(pelicula);
            

        }

        //[HttpGet]
        //public Object FindPeliculas(string genero)
        //{
           
        //}



        [HttpPost]
        public IActionResult Post(Pelicula pelicula) 
        {
            _peliculaRepository.AddPelicula(pelicula);
            return CreatedAtAction(nameof(Get), new { Id = pelicula.Id }, pelicula);
        }


        [HttpPut("{id}")]
        public IActionResult Put(Pelicula pelicula, int id)
        {
            var peliculaSeleccionada = _peliculaRepository.GetPelicula(id);
            if (peliculaSeleccionada != null )
            {
                peliculaSeleccionada.Duracion = pelicula.Duracion;
                peliculaSeleccionada.Descripcion = pelicula.Descripcion;
                peliculaSeleccionada.Genero = pelicula.Genero;
                _peliculaRepository.UpdatePelicula(peliculaSeleccionada);
                return NoContent();
            }
            return NotFound();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pelicula = _peliculaRepository.GetPelicula(id);

            if (pelicula != null)
            {
                _peliculaRepository.DeletePelicula(id);
                return NoContent();
            }
            return NotFound();
            
        }

    }
}
