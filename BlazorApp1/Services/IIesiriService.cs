using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public interface IIesiriService
    {
        bool AddEdit(Iesiri iesiri);

        bool Delete(decimal id);

        public Iesiri FindById(decimal id);

        List<Iesiri> FindAll();
    }
}
