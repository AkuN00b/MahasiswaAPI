using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MahasiswaAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mahasiswas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nim = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    jurusan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mahasiswas", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mahasiswas_nim",
                table: "Mahasiswas",
                column: "nim",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mahasiswas");
        }
    }
}
