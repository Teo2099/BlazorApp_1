using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public interface IParteneriService
    {

        bool AddEdit(Parteneri partener);

        bool Delete(decimal id);

        public Parteneri FindById(decimal id);

        List<Parteneri> FindAll();
    }
}
