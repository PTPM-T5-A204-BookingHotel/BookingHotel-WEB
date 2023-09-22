using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class update6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CCCD",
                table: "HoaDonDatPhong",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "GioiTinh",
                table: "HoaDonDatPhong",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HinhXacNhan",
                table: "HoaDonDatPhong",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CCCD",
                table: "HoaDonDatPhong");

            migrationBuilder.DropColumn(
                name: "GioiTinh",
                table: "HoaDonDatPhong");

            migrationBuilder.DropColumn(
                name: "HinhXacNhan",
                table: "HoaDonDatPhong");
        }
    }
}
