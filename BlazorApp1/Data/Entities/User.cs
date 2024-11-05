using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Data.Entities
{
	public class User
	{
		[Key]
		public int Id { get; set; }

		[Required, MaxLength(20)]
		public string FirstName { get; set; }

		[Required, MaxLength(20)]
		public string LastName { get; set; }

		[Required, MaxLength(30)]
		public string Email { get; set; }

		[Required, MaxLength(100)]
		public string Password { get; set; }
	}
}
