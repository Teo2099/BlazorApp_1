using BlazorApp1.Data;
using BlazorApp1.Data.Entities;
using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public class GestiuniService : IGestiuniService
    {
        private readonly DbProject1Context _projectContext;

        public GestiuniService(DbProject1Context projectContext)
        {
            _projectContext = projectContext;
        }
        public bool AddEdit(Gestiuni gestiune)
        {
            try
            {
                if (gestiune.Id == 0)
                {
                    var result = _projectContext.Gestiunis.Max(x => x.Cod);
                    gestiune.Cod = result + 1;
                    _projectContext.Gestiunis.Add(gestiune);
                }
                else
                {
                    _projectContext.Gestiunis.Update(gestiune);
                }
                _projectContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(decimal id)
        {
            try
            {
                var result = FindById(id);
                if (result == null)
                {
                    return false;
                }
                _projectContext.Gestiunis.Remove(result);
                _projectContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Gestiuni> FindAll()
        {
            return _projectContext.Gestiunis.ToList();
        }

        public Gestiuni FindById(decimal id)
        {
            return _projectContext.Gestiunis.Find(id);
        }
    }
}
