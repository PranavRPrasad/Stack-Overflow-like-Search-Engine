using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverflowLikeWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddingIndexesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
            name: "IX_PostTypes_Type",
            table: "PostTypes",
            column: "Type");

            migrationBuilder.CreateIndex(
            name: "IX_VoteTypes_Name",
            table: "VoteTypes",
            column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
