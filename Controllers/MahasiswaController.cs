using MahasiswaAPI.Data;
using MahasiswaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MahasiswaAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class MahasiswaController : Controller
	{
		private readonly ApplicationDbContext dbContext;

		public MahasiswaController(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		[HttpGet]
		public IActionResult GetMahasiswa()
		{
			return Ok(dbContext.Mahasiswas.ToList());
		}

		[HttpGet]
		[Route("{id:int}")]
		public IActionResult GetMahasiswa([FromRoute] int id)
		{
			var mahasiswa = dbContext.Mahasiswas.Find(id);

			if (mahasiswa == null)
			{
				return NotFound();
			}

			return Ok(mahasiswa);
		}

		[HttpPost]
		public IActionResult AddMahasiswa(FormMahasiswa formMahasiswa)
		{
			var mahasiswa = new Mahasiswa()
			{
				nim = formMahasiswa.nim,
				nama = formMahasiswa.nama,
				jurusan = formMahasiswa.jurusan,
			};

			dbContext.Mahasiswas.AddAsync(mahasiswa);
			dbContext.SaveChangesAsync();

			return Ok(mahasiswa);
		}

		[HttpPut]
		[Route("{id:int}")]
		public IActionResult UpdateMahasiswa([FromRoute] int id, FormMahasiswa formMahasiswa)
		{
			var mahasiswa = dbContext.Mahasiswas.Find(id);

			if (mahasiswa != null)
			{
				mahasiswa.nim = formMahasiswa.nim;
				mahasiswa.nama = formMahasiswa.nama;
				mahasiswa.jurusan = formMahasiswa.jurusan;

				dbContext.SaveChanges();

				return Ok(mahasiswa);
			}

			return NotFound();
		}

		[HttpDelete]
		[Route("{id:int}")]
		public IActionResult DeleteMahasiswa([FromRoute] int id)
		{
			var mahasiswa = dbContext.Mahasiswas.Find(id);

			if (mahasiswa != null)
			{
				dbContext.Remove(mahasiswa);
				dbContext.SaveChanges();
				return Ok(mahasiswa);
			}

			return NotFound();
		}
	}
}
