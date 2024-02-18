using Minimal_Api.Data;
using Minimal_Api.Modelos;

namespace Minimal_Api.Repositorys
{
    public class SocioRepository : ISocioRepository
    {
        private readonly SocioDbContext _dbContext;

        public SocioRepository(SocioDbContext dbContext)
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
            var socio = _dbContext.Socios.FirstOrDefault(s => s.Id == id);
            if (socio != null)
            {
                _dbContext.Socios.Remove(socio);
            }
        }

        public IEnumerable<Socio> GetAllSocios()
        {
            return _dbContext.Socios.ToList();
        }

        public Socio GetSocioById(int id)
        {
            return _dbContext.Socios.FirstOrDefault(s => s.Id == id);
        }

        public void UpdateSocio(Socio socio)
        {
            _dbContext.Socios.Update(socio);
        }
    }
}
