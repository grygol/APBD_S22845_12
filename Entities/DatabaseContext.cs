using System;
using APBD12.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD12.Entities
{
	public class DatabaseContext : DbContext
	{
        public DbSet<List> Lists { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }


        public DatabaseContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<List>(e =>
			{
				e.HasKey(e => e.Id_list);

				e.Property(e => e.Name).HasMaxLength(40).IsRequired();
				e.Property(e => e.Address).HasMaxLength(254).IsRequired();
				e.Property(e => e.Created_at).IsRequired();
				e.Property(e => e.Description).HasMaxLength(255).IsRequired();

				e.HasData(new List
				{
					Id_list = 1,
					Name = "VIP",
					Address = "VIP@example.com",
					Created_at = DateTime.Now,
					Description = "Lista zawierająca wszystkich gości VIP"
				});

				e.ToTable("List");
			});

			modelBuilder.Entity<Membership>(e =>
			{
				e.HasKey(e => new { e.Id_list, e.Id_subscriber });

				e.Property(e => e.Status).HasMaxLength(16).IsRequired();
				e.Property(e => e.Added_at).IsRequired();

				e.HasOne(e => e.List)
				.WithMany(e => e.Memberships)
				.HasForeignKey(e => e.Id_list)
				.OnDelete(DeleteBehavior.Cascade);

				e.HasOne(e => e.Subscriber)
				.WithMany(e => e.Memberships)
				.HasForeignKey(e => e.Id_subscriber)
				.OnDelete(DeleteBehavior.Cascade);

				e.HasData(
					new Membership
					{
						Id_list = 1,
						Id_subscriber = 1,
						Status = "Unsubscribed",
						Added_at = DateTime.Now
					},
					new Membership
					{
						Id_list = 1,
						Id_subscriber = 2,
						Status = "Subscribed",
						Added_at = DateTime.Now
					},
					new Membership
					{
						Id_list = 1,
						Id_subscriber = 3,
						Status = "Subscribed",
						Added_at = DateTime.Now
					});

				e.ToTable("Membership");

			});

			modelBuilder.Entity<Subscriber>(e =>
			{
				e.HasKey(e => e.Id_subscriber);

				e.Property(e => e.Address).HasMaxLength(254).IsRequired();
				e.Property(e => e.Name).HasMaxLength(40).IsRequired();
				e.Property(e => e.Status).HasMaxLength(16).IsRequired();

				e.HasData(
					new Subscriber
					{
						Id_subscriber = 1,
						Address = "Antoni@gmail.com",
						Name = "Antoni Przykładowy",
						Status = "Verified"
					},
					new Subscriber
                    {
						Id_subscriber = 2,
						Address = "bartlomiej@outlook.com",
						Name = "Bartłomiej Następny",
						Status = "Unknown"
                    },
					new Subscriber
                    {
						Id_subscriber = 3,
						Address = "cecylia@poczta.pl",
						Name = "Cecylia Ostateczna",
						Status = "Suppressed"
                    });

				e.ToTable("Subscriber");
			});
        }
	}
}

