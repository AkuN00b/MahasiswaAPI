using MahasiswaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MahasiswaAPI.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Mahasiswa> Mahasiswas { get; set; }
	}
}
