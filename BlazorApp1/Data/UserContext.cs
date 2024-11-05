using BlazorApp1.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        { 
        }

		public virtual DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>()
				.HasData(
					new User
					{
						Id = 1,
						FirstName = "Ana",
						LastName = "Popescu",
						Email = "ana.popescu@gmail.com",
						Password = "1234567"
					}
				);
		}
	}
}
