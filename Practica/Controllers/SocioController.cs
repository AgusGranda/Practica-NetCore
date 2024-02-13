using Microsoft.AspNetCore.Mvc;
using Practica.Dtos;

namespace Practica.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SocioController : Controller
    {

        private static List<Socio> Socios = new()
        {
            new Socio { Id = 1, Nombre ="Kevin" , Apellido = "Rocket", Direccion= "Salguero"},
            new Socio { Id = 2,Nombre ="Borham" , Apellido = "Racoon" , Direccion= "Delia"},
        };



        [HttpGet]
        public List<Socio> ShowAllSocios()
        {
            return Socios;
        }

        [HttpGet("{id}")]
        public Object ShowOneSocio(int id)
        {
            Socio seleccionado = Socios.Find(x => x.Id == id);
            if (seleccionado != null)
                return seleccionado;
            else
                return "Socio no encontrado";
        }

        [HttpPost]
        public string CreateSocio(Socio socio)
        {
            if (socio != null)
            {
                Socios.Add(socio);
                return "Socio agregado correctamente";
            }
            else
                return "No puedes agregar un socio sin datos";   
        }


        [HttpPut("{id}")]
        public string UpdateSocio(Socio socio, int id)
        {
            Socio seleccionado = Socios.Find(x => x.Id == id);

            if (seleccionado != null)
            {
                seleccionado.Nombre = socio.Nombre;
                seleccionado.Apellido = socio.Apellido;
                seleccionado.Direccion = socio.Direccion;
                return "Socio modificado exitosamente";
            }
            else
                return "Socio inexistente";

        }

        [HttpDelete("{id}")]
        public string DeleteSocio(int id)
        {
            Socio seleccionado = Socios.Find(x => x.Id == id);

            if (seleccionado != null)
            {
                Socios.Remove(seleccionado);
                return "Socio eliminado correctamente";
            }
            else
                return "Socio inexistente";
        }
    }
}
