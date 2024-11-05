using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
	public class LoginModel
	{
		[Required, EmailAddress, DataType(DataType.EmailAddress)]
		public string? Username { get; set; }

		[Required, MinLength(7)]
		public string? Password { get; set; }
	}
}
