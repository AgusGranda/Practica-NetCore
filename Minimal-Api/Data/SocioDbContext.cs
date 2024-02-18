using Microsoft.EntityFrameworkCore;
using Minimal_Api.Modelos;

namespace Minimal_Api.Data
{
    public class SocioDbContext : DbContext
    {

        public SocioDbContext(DbContextOptions<SocioDbContext> options) : base(options)
        {
            fillSocios();
        }


        public DbSet<Socio> Socios {  get; set; }

        private void fillSocios()
        {
            if(Socios.Count() == 0)
            {
                Socios.Add(new Socio { Id = 1, Nombre = "Kevin", Apellido = "Conicelli", Direccion = "Azcuenaga" });
                Socios.Add(new Socio { Id = 2, Nombre = "Agustin", Apellido = "Granda", Direccion = "Delia" });
                this.SaveChanges();
            }
        }

    }
}
