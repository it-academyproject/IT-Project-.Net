using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ItAcademyProjecteNET.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    EventType = table.Column<string>(nullable: true),
                    Exercise_Name = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    Exercise_Description = table.Column<string>(nullable: true),
                    IsCommonBlock = table.Column<bool>(nullable: true),
                    Itinerary = table.Column<string>(nullable: true),
                    ResourceLevel = table.Column<string>(nullable: true),
                    AvalableTime = table.Column<string>(nullable: true),
                    DeliveryDate = table.Column<DateTime>(nullable: true),
                    ExerciseStatus = table.Column<string>(nullable: true),
                    Person_Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: true),
                    Dni = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    PersonGender = table.Column<string>(nullable: true),
                    PersonRole = table.Column<string>(nullable: true),
                    Absences = table.Column<int>(nullable: true),
                    LastLogin = table.Column<DateTime>(nullable: true),
                    BeginData = table.Column<DateTime>(nullable: true),
                    EndData = table.Column<DateTime>(nullable: true),
                    TeachingMaterial_Name = table.Column<string>(nullable: true),
                    TeachingMaterial_Description = table.Column<string>(nullable: true),
                    Lesson = table.Column<string>(nullable: true),
                    MaterialLink = table.Column<string>(nullable: true),
                    MaterialType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entity");
        }
    }
}
