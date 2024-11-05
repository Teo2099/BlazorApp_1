using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazorApp1.Services
{
	public class IntrariService : IIntrariService
	{
		private readonly DbProject1Context _projectContext;

		public IntrariService(DbProject1Context projectContext)
		{
			_projectContext = projectContext;
		}

		public bool AddEdit(Intrari intrari)
		{
			try
			{
				if (intrari.Id == 0)
				{
					var result = _projectContext.Intraris.Max(x => x.Numar);
					intrari.Numar = result + 1;
					_projectContext.Intraris.Add(intrari);
				}
				else
				{
					_projectContext.Intraris.Update(intrari);
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
				var result2 = _projectContext.IntrariDetalius.Where(x => x.IdIntrari == result.Id).ToList();

				if (result2 != null) 
				{
					foreach (var item in result2)
					{
						_projectContext.IntrariDetalius.Remove(item);
					}
					_projectContext.SaveChanges();
				}

				_projectContext.Intraris.Remove(result);
				_projectContext.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public List<Intrari> FindAll()
		{
			return _projectContext.Intraris.ToList();
		}

		public Intrari FindById(decimal id)
		{
			return _projectContext.Intraris.Find(id);
		}
	}
}
