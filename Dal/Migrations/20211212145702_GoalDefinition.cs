using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class GoalDefinition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"insert into GoalDefinitions (Goal,Gender,MinAge,MaxAge,Calories)
values
(1, 1, 0, 13, 800),
(1, 1, 14, 20, 1200),
(1, 1, 21, 27, 1600),
(1, 1, 28, 100, 2000),
(1,2, 0, 13, 700),
(1,2, 14, 20, 1100),
(1,2, 21, 27, 1500),
(1,2, 28, 100, 1900),
(2, 1, 0, 13, 1200),
(2, 1, 14, 20, 1600),
(2, 1, 21, 27, 2000),
(2, 1, 28, 100, 2400),
(2,2, 0, 13, 1100),
(2,2, 14, 20, 1500),
(2,2, 21, 27, 1900),
(2,2, 28, 100, 2200),
(3, 1, 0, 13, 600),
(3, 1, 14, 20, 1000),
(3, 1, 21, 27, 1400),
(3, 1, 28, 100, 1800),
(3,2, 0, 13, 500),
(3,2, 14, 20, 900),
(3,2, 21, 27, 1300),
(3,2, 28, 100, 1700),
(4, 1, 0, 13, 900),
(4, 1, 14, 20, 1300),
(4, 1, 21, 27, 1700),
(4, 1, 28, 100, 2100),
(4,2, 0, 13, 800),
(4,2, 14, 20, 1200),
(4,2, 21, 27, 1600),
(4,2, 28, 100, 2000)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
