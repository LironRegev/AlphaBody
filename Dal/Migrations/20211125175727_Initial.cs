using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    FoodKind = table.Column<int>(nullable: false),
                    Grams = table.Column<int>(nullable: false),
                    Calories = table.Column<int>(nullable: false),
                    ProteinGrams = table.Column<double>(nullable: false),
                    CarbsGrams = table.Column<double>(nullable: false),
                    FatGrams = table.Column<double>(nullable: false),
                    CholesterolMilligram = table.Column<double>(nullable: false),
                    Fibers = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoalDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Goal = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    MinAge = table.Column<int>(nullable: false),
                    MaxAge = table.Column<int>(nullable: false),
                    Calories = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDislikes",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    FoodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDislikes", x => new { x.UserId, x.FoodId });
                    table.ForeignKey(
                        name: "FK_UserDislikes_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDislikes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    Goal = table.Column<int>(nullable: false),
                    ActivityLevel = table.Column<int>(nullable: false),
                    MealsNum = table.Column<int>(nullable: false),
                    BMI = table.Column<double>(nullable: false),
                    BMR = table.Column<double>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    NeededCalories = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserInfos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    FoodId = table.Column<int>(nullable: false),
                    MealTime = table.Column<int>(nullable: false),
                    Grams = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMenuItems_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMenuItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDislikes_FoodId",
                table: "UserDislikes",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMenuItems_FoodId",
                table: "UserMenuItems",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMenuItems_UserId",
                table: "UserMenuItems",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoalDefinitions");

            migrationBuilder.DropTable(
                name: "UserDislikes");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "UserMenuItems");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
