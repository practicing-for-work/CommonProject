using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Practicing_For_Work.EntityFrameworkCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FdMember",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MemberSeq = table.Column<Guid>(nullable: false),
                    Num = table.Column<int>(nullable: false),
                    Account = table.Column<string>(nullable: true),
                    IsOpen = table.Column<bool>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Birthday = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    Township = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    OpenAccountTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FdMember", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FdMember");
        }
    }
}
