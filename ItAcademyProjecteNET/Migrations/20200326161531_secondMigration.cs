using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ItAcademyProjecteNET.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Events_EventId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "StudentExercises");

            migrationBuilder.DropIndex(
                name: "IX_Persons_EventId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Persons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExercises", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_EventId",
                table: "Persons",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Events_EventId",
                table: "Persons",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
