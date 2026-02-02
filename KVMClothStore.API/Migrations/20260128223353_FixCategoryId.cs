using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KVMClothStore.API.Migrations
{
    /// <inheritdoc />
    public partial class FixCategoryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "categories",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "categories",
                newName: "ID");
        }
    }
}
