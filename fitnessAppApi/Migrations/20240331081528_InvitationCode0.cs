using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fitnessAppApi.Migrations
{
    /// <inheritdoc />
    public partial class InvitationCode0 : Migration
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
            migrationBuilder.DropPrimaryKey(
                name: "PK_InvitationCode",
                table: "InvitationCode");

            migrationBuilder.AlterColumn<int>(
                name: "UsedById",
                table: "InvitationCode",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
