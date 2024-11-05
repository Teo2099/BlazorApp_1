using BlazorApp1.Data;
using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public class IntrariDetaliuService : IIntrariDetaliuService
    {
        private readonly DbProject1Context _projectContext;

        public IntrariDetaliuService(DbProject1Context projectContext)
        {
            _projectContext = projectContext;
        }

        public bool AddEdit(IntrariDetaliu intrariDetaliu, decimal intrareId)
        {
            try
            {
                if (intrariDetaliu.Id == 0)
                {
                    intrariDetaliu.IdIntrari = intrareId;
                    _projectContext.IntrariDetalius.Add(intrariDetaliu);
                }
                else
                {
                    _projectContext.IntrariDetalius.Update(intrariDetaliu);
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
                _projectContext.IntrariDetalius.Remove(result);
                _projectContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<IntrariDetaliu> FindAll()
        {
            return _projectContext.IntrariDetalius.ToList();
        }

        public IntrariDetaliu FindById(decimal id)
        {
            return _projectContext.IntrariDetalius.Find(id);
        }
    }
}
