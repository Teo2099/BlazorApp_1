using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public interface IIesiriDetaliuService
    {
        bool AddEdit(IesiriDetaliu iesiriDetaliu, decimal iesireId);

        bool Delete(decimal id);

        public IesiriDetaliu FindById(decimal id);

        List<IesiriDetaliu> FindAll();
    }
}
