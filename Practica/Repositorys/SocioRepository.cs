using Practica.Data;
using Practica.Dtos;
using Practica.Modelos;

namespace Practica.Repositorys
{
    public class SocioRepository : ISocioRepository
    {

        private readonly SociosDbContext _dbContext;

        public SocioRepository(SociosDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void AddSocio(Socio socio)
        {
           _dbContext.Socios.Add(socio);
            _dbContext.SaveChanges();
            
        }

        public void DeleteSocio(int id)
        {
            var socio = _dbContext.Socios.FirstOrDefault(x => x.Id == id);
            if (socio != null)
            {
                _dbContext.Socios.Remove(socio);
                _dbContext.SaveChanges();
            }

        }

        public IEnumerable<Socio> GetAllSocios()
        {
            return _dbContext.Socios.ToList();
        }

        public Socio GetSocio(int id)
        {
            return _dbContext.Socios.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateSocio(Socio socio)
        {

            _dbContext.Socios.Update(socio);
            _dbContext.SaveChanges();
        }
    }
}
