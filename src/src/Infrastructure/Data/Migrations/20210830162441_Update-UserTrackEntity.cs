using Microsoft.EntityFrameworkCore.Migrations;

namespace Featurify.Infrastructure.Data.Migrations
{
    public partial class UpdateUserTrackEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e0aa57d-e22c-47de-9025-9c2aa4e391f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab212cf0-107f-4f4e-bf64-4f93bfc51406");

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "UsersTracks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ecb60d60-6d97-4669-bc57-94443de044d9", "4d72c60c-6e42-4d46-bfce-1cfb77bfa350", "Basic", "BASIC" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f2914a9b-4ed8-4ba3-9ba9-dec0f8755a6c", "165ffe19-25c3-47bf-a16d-4644a97cda31", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecb60d60-6d97-4669-bc57-94443de044d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2914a9b-4ed8-4ba3-9ba9-dec0f8755a6c");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "UsersTracks");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ab212cf0-107f-4f4e-bf64-4f93bfc51406", "8ceb673e-9343-4acc-89cd-7be04533e5d8", "Basic", "BASIC" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e0aa57d-e22c-47de-9025-9c2aa4e391f4", "2497e6bd-c562-4f79-9c2f-c309ca2045db", "Admin", "ADMIN" });
        }
    }
}
