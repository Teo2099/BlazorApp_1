using BlazorApp1.Data;
using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public class IesiriDetaliuService : IIesiriDetaliuService
    {
        private readonly DbProject1Context _projectContext;

        public IesiriDetaliuService(DbProject1Context projectContext)
        {
            _projectContext = projectContext;
        }
        public bool AddEdit(IesiriDetaliu iesireDetaliu, decimal iesireId)
        {
            try
            {
                if (iesireDetaliu.Id == 0)
                {
                    iesireDetaliu.IdIesiri = iesireId;
                    _projectContext.IesiriDetalius.Add(iesireDetaliu);
                }
                else
                {
                    _projectContext.IesiriDetalius.Update(iesireDetaliu);
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
                _projectContext.IesiriDetalius.Remove(result);
                _projectContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<IesiriDetaliu> FindAll()
        {
            return _projectContext.IesiriDetalius.ToList();
        }

        public IesiriDetaliu FindById(decimal id)
        {
            return _projectContext.IesiriDetalius.Find(id);
        }
    }
}
