using BlazorApp1.Data;
using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public class ProduseService : IProduseService
    {
        private readonly DbProject1Context _projectContext;

        public ProduseService(DbProject1Context projectContext)
        {
            _projectContext = projectContext;
        }
        public bool AddEdit(Produse produse)
        {
            try
            {
                if (produse.Id == 0)
                {
                    var result = _projectContext.Produses.Max(x => x.Cod);
                    produse.Cod = result + 1;
                    _projectContext.Produses.Add(produse);
                }
                else
                {
                    _projectContext.Produses.Update(produse);
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
                _projectContext.Produses.Remove(result);
                _projectContext.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            { 
                return false;
            }
        }

        public List<Produse> FindAll()
        {
            return _projectContext.Produses.ToList();
        }

        public Produse FindById(decimal id)
        {
            return _projectContext.Produses.Find(id);
        }
    }
}
