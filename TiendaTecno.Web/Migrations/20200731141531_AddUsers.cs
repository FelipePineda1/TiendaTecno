using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaTecno.Web.Migrations
{
    public partial class AddUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Productos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_UserId",
                table: "Productos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_AspNetUsers_UserId",
                table: "Productos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_AspNetUsers_UserId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_UserId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Productos");
        }
    }
}
