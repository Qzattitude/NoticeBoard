using Microsoft.EntityFrameworkCore.Migrations;

namespace NoticeBoard.Migrations
{
    public partial class AddedUploaViewMoel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f2b743d7-0b2f-4169-8233-32b828b2e8e0", "AQAAAAEAACcQAAAAEMayXkZBVblSljc6ENWr31Ea5H2JempoEjKlDVsnGYqwYzbCwTfYYWsIBKpHid26oA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9E30A0BD-8810-452B-AC3C-D603F381BF15",
                column: "ConcurrencyStamp",
                value: "e933db16-014f-49fc-bd7d-c92ddf80e890");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "31c12e50-f645-4a17-ae12-cad2d8c984c6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "915717f3-f80b-42fd-8a27-75acca7a8072", "AQAAAAEAACcQAAAAEBavpULFt5RFxdSgQopuVRj+aAbbEWcPrcNugmOUhN9KQ3vQcqK/WiP1GYxCy9B0YQ==" });
        }
    }
}
