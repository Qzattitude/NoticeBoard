using Microsoft.EntityFrameworkCore.Migrations;

namespace NoticeBoard.Migrations
{
    public partial class RemovedUserIsChecked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserNotice_AspNetUsers_UserId",
                table: "UserNotice");

            migrationBuilder.DropTable(
                name: "NoticeUser");

            migrationBuilder.DropIndex(
                name: "IX_UserNotice_UserId",
                table: "UserNotice");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserNotice");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Notice_NoticeId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_NoticeId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575");

            migrationBuilder.DropColumn(
                name: "NoticeId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserNotice",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "NoticeUser",
                columns: table => new
                {
                    PostedNoticeId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeUser", x => new { x.PostedNoticeId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_NoticeUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoticeUser_Notice_PostedNoticeId",
                        column: x => x.PostedNoticeId,
                        principalTable: "Notice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9E30A0BD-8810-452B-AC3C-D603F381BF15",
                column: "ConcurrencyStamp",
                value: "a27e563f-4093-4808-b161-7247409a949b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "9932c2d9-3a45-4a4b-8153-4b63d5fccc41");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", 0, "f2b743d7-0b2f-4169-8233-32b828b2e8e0", "IdentityUser", "mukit@gmail.com", true, false, null, "mukit@gmail.com", "ADMIN@2022", "AQAAAAEAACcQAAAAEMayXkZBVblSljc6ENWr31Ea5H2JempoEjKlDVsnGYqwYzbCwTfYYWsIBKpHid26oA==", null, false, "", false, "Admin@2022" });

            migrationBuilder.CreateIndex(
                name: "IX_UserNotice_UserId",
                table: "UserNotice",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NoticeUser_UsersId",
                table: "NoticeUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotice_AspNetUsers_UserId",
                table: "UserNotice",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
