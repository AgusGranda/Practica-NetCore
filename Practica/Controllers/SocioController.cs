using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Practica.Dtos;
using Practica.Modelos;
using Practica.Repositorys;

namespace Practica.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SocioController : ControllerBase
    {

        private readonly ISocioRepository _socioRepository;

        public SocioController(ISocioRepository socioRepository)
        {

            _socioRepository = socioRepository;
        }



        [HttpGet]
        public IActionResult Get()
        {
            var socios = _socioRepository.GetAllSocios();
            return Ok(socios);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var socio = _socioRepository.GetSocio(id);
            if (socio != null)
            {
                return Ok(socio);

            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post(Socio socio)
        {
            _socioRepository.AddSocio(socio);
            return CreatedAtAction(nameof(Get), new {id = socio.Id }, socio);

        }


        [HttpPut("{id}")]
        public IActionResult Put(Socio updatedSocio, int id)
        {
            var socio = _socioRepository.GetSocio(id);
            if (socio != null)
            {
                socio.Direccion = updatedSocio.Direccion;
                socio.Nombre = updatedSocio.Nombre;
                socio.Apellido = updatedSocio.Apellido;
                _socioRepository.UpdateSocio(socio);
                return NoContent();
            }
            return NotFound();  
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var socio = _socioRepository.GetSocio(id);
            if (socio != null)
            {
                _socioRepository.DeleteSocio(id);
                return NoContent();
            }
            return NotFound();
        }
    }
}
