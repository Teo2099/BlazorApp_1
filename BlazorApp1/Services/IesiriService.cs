using BlazorApp1.Data;
using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public class IesiriService : IIesiriService
    {
        private readonly DbProject1Context _projectContext;

        public IesiriService(DbProject1Context projectContext)
        {
            _projectContext = projectContext;
        }
        public bool AddEdit(Iesiri iesiri)
        {
            try
            {
                if (iesiri.Id == 0)
                {
                    var result = _projectContext.Iesiris.Max(x => x.Numar);
                    iesiri.Numar = result + 1;
                    _projectContext.Iesiris.Add(iesiri);
                }
                else
                {
                    _projectContext.Iesiris.Update(iesiri);
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
                var result2 = _projectContext.IesiriDetalius.Where(x => x.IdIesiri == result.Id).ToList();

                if (result2 != null)
                {
                    foreach (var item in result2)
                    {
                        _projectContext.IesiriDetalius.Remove(item);
                    }
                    _projectContext.SaveChanges();
                }

                _projectContext.Iesiris.Remove(result);
                _projectContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Iesiri> FindAll()
        {
            return _projectContext.Iesiris.ToList();
        }

        public Iesiri FindById(decimal id)
        {
            return _projectContext.Iesiris.Find(id);
        }
    }
}
