using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fitnessAppApi.Migrations
{
    /// <inheritdoc />
    public partial class muscle_added_to_workoutmove_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Muscle",
                table: "WorkoutMove",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Muscle",
                table: "WorkoutMove");
        }
    }
}
