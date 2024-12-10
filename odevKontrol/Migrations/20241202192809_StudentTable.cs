using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace odevKontrol.Migrations
{
    /// <inheritdoc />
    public partial class StudentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Homeworks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentNumber = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homeworks", x => x.Id);
     
                table.ForeignKey(
                    name: "FK_Homeworks_Students_StudentId",
                    column: x => x.StudentId,
                    principalTable: "Students",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
           
        });

            migrationBuilder.InsertData(
                table: "Homeworks",
                columns: new[] { "Id", "Description", "IsActive", "Name", "StudentNumber" },
                values: new object[,]
                {
                    { 1, "Kalem açıklama", true, "Kalem", 10L },
                    { 2, "Defter açıklama", true, "Defter", 15L },
                    { 3, "Silgi açıklama", false, "Silgi", 20L },
                    { 4, "Kitap açıklama", false, "Kitap", 30L },
                    { 5, "Boya açıklama", false, "Boya", 25L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Homeworks");
        }
    }
}
