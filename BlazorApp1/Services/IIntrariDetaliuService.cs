using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public interface IIntrariDetaliuService
    {
        bool AddEdit(IntrariDetaliu intrariDetaliu, decimal intrareId);

        bool Delete(decimal id);

        public IntrariDetaliu FindById(decimal id);

        List<IntrariDetaliu> FindAll();
    }
}
