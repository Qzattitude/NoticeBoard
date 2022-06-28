using Microsoft.EntityFrameworkCore.Migrations;

namespace NoticeBoard.Migrations
{
    public partial class SelectedUsersByCheckbox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserNotice");

            migrationBuilder.AddColumn<int>(
                name: "NoticeId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9E30A0BD-8810-452B-AC3C-D603F381BF15",
                column: "ConcurrencyStamp",
                value: "21c0f5ae-2eef-40e2-b0a6-f82836f73a1a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "13e3f8fe-7b9f-4986-b2c1-11696c64303d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ffc9e7f3-e4ca-4df2-a846-7a2c9508bc65", "AQAAAAEAACcQAAAAEMOlRosORq6kjcAyhxt/L/uiw1CncdUNcbdI3rlq6vj1IaiaETDZRptj0fijakkmsA==" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NoticeId",
                table: "AspNetUsers",
                column: "NoticeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Notice_NoticeId",
                table: "AspNetUsers",
                column: "NoticeId",
                principalTable: "Notice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Notice_NoticeId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_NoticeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NoticeId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "UserNotice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsVisited = table.Column<bool>(type: "bit", nullable: false),
                    NoticeId = table.Column<int>(type: "int", nullable: false),
                    NoticeLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoticeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ViewCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotice_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserNotice_Notice_NoticeId",
                        column: x => x.NoticeId,
                        principalTable: "Notice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9E30A0BD-8810-452B-AC3C-D603F381BF15",
                column: "ConcurrencyStamp",
                value: "c53a28d6-9395-4377-ade6-673a616d420c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "542b6b7e-84a1-41b8-a505-6a7ef5fad2af");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "40d0aab3-0f71-4e07-85c9-8cdd9f1e2d46", "AQAAAAEAACcQAAAAEPhRSYSoX1AiuvRoS6NVBQLqsZ21ZmnurGoDqWU+ernQ8iNh4bmgJKYM/WBnPclRLA==" });

            migrationBuilder.CreateIndex(
                name: "IX_UserNotice_NoticeId",
                table: "UserNotice",
                column: "NoticeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotice_UserId",
                table: "UserNotice",
                column: "UserId");
        }
    }
}
