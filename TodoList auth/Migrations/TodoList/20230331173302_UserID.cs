using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList_auth.Migrations.TodoList
{
    /// <inheritdoc />
    public partial class UserID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TodoLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TodoLists");
        }
    }
}
