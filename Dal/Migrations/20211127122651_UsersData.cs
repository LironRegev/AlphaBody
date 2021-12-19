using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class UsersData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"insert into users (username,password,firstname,lastname,role)
            values
            ('lironregevuser','liron007','Liron','Regev',1),
            ('dorbs','dor007','Dor','Ben-Senior',0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
