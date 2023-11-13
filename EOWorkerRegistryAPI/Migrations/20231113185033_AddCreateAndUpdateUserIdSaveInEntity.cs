using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EOWorkerRegistryAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCreateAndUpdateUserIdSaveInEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Workers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                table: "Workers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "OrganizationalUnits",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                table: "OrganizationalUnits",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "OrganizationalUnits");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "OrganizationalUnits");
        }
    }
}
