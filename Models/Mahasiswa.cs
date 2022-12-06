using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahasiswaAPI.Models
{
	[Index(nameof(nim), IsUnique = true)]
	public class Mahasiswa
	{
		[Key]
		public int id { get; set; }
		public string nim { get; set; } = null!;
		public string nama { get; set; } = null!;
		public string jurusan { get; set; } = null!;
	}
}
