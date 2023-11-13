using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EOWorkerRegistryAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixSelfReferenceInWorker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SuperiorId1",
                table: "Workers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_SuperiorId1",
                table: "Workers",
                column: "SuperiorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Workers_SuperiorId1",
                table: "Workers",
                column: "SuperiorId1",
                principalTable: "Workers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Workers_SuperiorId1",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_SuperiorId1",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "SuperiorId1",
                table: "Workers");
        }
    }
}
