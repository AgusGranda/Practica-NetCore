using Practica.Dtos;

namespace Practica.Modelos
{
    public interface ISocioRepository
    {
        IEnumerable<Socio> GetAllSocios();
        Socio GetSocio(int id);
        void AddSocio(Socio socio);
        void UpdateSocio(Socio socio);
        void DeleteSocio(int id);
    }
}
