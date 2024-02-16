using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillMasteryAPI.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goals_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Progresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    Milestones = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Progresses_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 16, 16, 57, 29, 144, DateTimeKind.Utc).AddTicks(481), "The ability to write computer programs", "Programming", new DateTime(2024, 2, 16, 16, 57, 29, 144, DateTimeKind.Utc).AddTicks(484) },
                    { 2, new DateTime(2024, 2, 16, 16, 57, 29, 144, DateTimeKind.Utc).AddTicks(486), "The ability to create designs for user interfaces", "Design", new DateTime(2024, 2, 16, 16, 57, 29, 144, DateTimeKind.Utc).AddTicks(486) },
                    { 3, new DateTime(2024, 2, 16, 16, 57, 29, 144, DateTimeKind.Utc).AddTicks(487), "The ability to manage and maintain database management systems", "Database", new DateTime(2024, 2, 16, 16, 57, 29, 144, DateTimeKind.Utc).AddTicks(488) }
                });

            migrationBuilder.InsertData(
                table: "Goals",
                columns: new[] { "Id", "CreatedAt", "Deadline", "Description", "SkillId", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 16, 16, 57, 29, 144, DateTimeKind.Utc).AddTicks(665), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete a basic programming course", 1, 1, new DateTime(2024, 2, 16, 16, 57, 29, 144, DateTimeKind.Utc).AddTicks(665) },
                    { 2, new DateTime(2024, 2, 16, 16, 57, 29, 144, DateTimeKind.Utc).AddTicks(672), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Design a user interface for a mobile app", 2, 0, new DateTime(2024, 2, 16, 16, 57, 29, 144, DateTimeKind.Utc).AddTicks(672) },
                    { 3, new DateTime(2024, 2, 16, 16, 57, 29, 144, DateTimeKind.Utc).AddTicks(673), new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Optimize database performance", 3, 1, new DateTime(2024, 2, 16, 16, 57, 29, 144, DateTimeKind.Utc).AddTicks(674) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goals_SkillId",
                table: "Goals",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Progresses_SkillId",
                table: "Progresses",
                column: "SkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "Progresses");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
