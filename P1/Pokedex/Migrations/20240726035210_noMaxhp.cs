using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokedex.Migrations
{
    /// <inheritdoc />
    public partial class noMaxhp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "maxHp",
                table: "PlayerPokemons");

            migrationBuilder.DropColumn(
                name: "maxHp",
                table: "ComputerPokemons");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "maxHp",
                table: "PlayerPokemons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "maxHp",
                table: "ComputerPokemons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
