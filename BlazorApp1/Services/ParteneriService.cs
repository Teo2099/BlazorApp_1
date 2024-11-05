using BlazorApp1.Data;
using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public class ParteneriService : IParteneriService
    {
        private readonly DbProject1Context _projectContext;

        public ParteneriService(DbProject1Context projectContext)
        {
            _projectContext = projectContext;
        }
        public bool AddEdit(Parteneri partener)
        {
            try
            {
                if (partener.Id == 0)
                {
                    var result = _projectContext.Parteneris.Max(x => x.Cod);
                    partener.Cod = result + 1;
                    _projectContext.Parteneris.Add(partener);
                }
                else
                {
                    _projectContext.Parteneris.Update(partener);
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
                _projectContext.Parteneris.Remove(result);
                _projectContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Parteneri> FindAll()
        {
            return _projectContext.Parteneris.ToList();
        }

        public Parteneri FindById(decimal id)
        {
            return _projectContext.Parteneris.Find(id);
        }
    }
}
