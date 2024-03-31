using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fitnessAppApi.Migrations
{
    /// <inheritdoc />
    public partial class InvitationCode1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("InvitationCode");

            migrationBuilder.CreateTable(
                 name: "InvitationCode",
                 columns: table => new
                 {
                     UsedById = table.Column<int>(nullable: false),
                     Code = table.Column<string>(nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_InvitationCode", x => x.UsedById);
                 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
