using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public interface IProduseService
    {
        bool AddEdit(Produse produse);

        bool Delete(decimal id);

        public Produse FindById(decimal id);

        List<Produse> FindAll();
    }
}
