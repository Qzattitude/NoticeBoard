using Microsoft.EntityFrameworkCore.Migrations;

namespace NoticeBoard.Migrations
{
    public partial class NoticeUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "UserNotice",
                newName: "NoticeName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Notice",
                newName: "NoticeName");

            migrationBuilder.RenameColumn(
                name: "Link",
                table: "Notice",
                newName: "NoticeLink");

            migrationBuilder.AddColumn<string>(
                name: "NoticeLink",
                table: "UserNotice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserNotice",
                type: "nvarchar(450)",
                nullable: true);

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
                name: "IX_UserNotice_UserId",
                table: "UserNotice",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotice_AspNetUsers_UserId",
                table: "UserNotice",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserNotice_AspNetUsers_UserId",
                table: "UserNotice");

            migrationBuilder.DropIndex(
                name: "IX_UserNotice_UserId",
                table: "UserNotice");

            migrationBuilder.DropColumn(
                name: "NoticeLink",
                table: "UserNotice");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserNotice");

            migrationBuilder.RenameColumn(
                name: "NoticeName",
                table: "UserNotice",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "NoticeName",
                table: "Notice",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NoticeLink",
                table: "Notice",
                newName: "Link");

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
                value: "ef006d2c-3741-42ae-9edd-8478ae004368");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "af99a0bd-0531-4d18-a4fd-578f0c028614");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "98155bb0-7c00-498b-af23-f610fcd7b452", "AQAAAAEAACcQAAAAENztyRWd3UM5jJSnNi92DZq2A6tHlfFdCRNOIOYDx7/9D0xLK8b066hA/PiHDgjFYQ==" });

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
    }
}
