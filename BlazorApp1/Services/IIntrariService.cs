using BlazorApp1.Models;

namespace BlazorApp1.Services
{
	public interface IIntrariService
	{
		bool AddEdit(Intrari intrari);

		bool Delete(decimal id);

		public Intrari FindById(decimal id);

		List<Intrari> FindAll();
	}
}
