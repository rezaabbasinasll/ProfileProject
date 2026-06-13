using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfileProject.DataAccess.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfileEntitys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileEntitys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfileSkils",
                columns: table => new
                {
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SkillLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileSkils", x => new { x.ProfileId, x.Id });
                    table.ForeignKey(
                        name: "FK_ProfileSkils_ProfileEntitys_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "ProfileEntitys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileEntitys_Email",
                table: "ProfileEntitys",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileEntitys_IsDeleted",
                table: "ProfileEntitys",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileSkils_Name",
                table: "ProfileSkils",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileSkils");

            migrationBuilder.DropTable(
                name: "ProfileEntitys");
        }
    }
}
