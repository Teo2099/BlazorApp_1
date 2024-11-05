using BlazorApp1.Data.Entities;
using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public interface IGestiuniService
    {

        bool AddEdit(Gestiuni gestiune);

        bool Delete(decimal id);

        public Gestiuni FindById(decimal id);

        List<Gestiuni> FindAll();
    }
}
