using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDonDatPhong_LoaiPhong_LoaiPhongId",
                table: "HoaDonDatPhong");

            migrationBuilder.DropIndex(
                name: "IX_HoaDonDatPhong_LoaiPhongId",
                table: "HoaDonDatPhong");

            migrationBuilder.DropColumn(
                name: "IdLoaiPhong",
                table: "HoaDonDatPhong");

            migrationBuilder.DropColumn(
                name: "LoaiPhongId",
                table: "HoaDonDatPhong");

            migrationBuilder.AddColumn<int>(
                name: "IdLoaiPhong",
                table: "Phong",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LoaiPhongId",
                table: "Phong",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Phong_LoaiPhongId",
                table: "Phong",
                column: "LoaiPhongId");

            migrationBuilder.AddForeignKey(
                name: "FK_Phong_LoaiPhong_LoaiPhongId",
                table: "Phong",
                column: "LoaiPhongId",
                principalTable: "LoaiPhong",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phong_LoaiPhong_LoaiPhongId",
                table: "Phong");

            migrationBuilder.DropIndex(
                name: "IX_Phong_LoaiPhongId",
                table: "Phong");

            migrationBuilder.DropColumn(
                name: "IdLoaiPhong",
                table: "Phong");

            migrationBuilder.DropColumn(
                name: "LoaiPhongId",
                table: "Phong");

            migrationBuilder.AddColumn<int>(
                name: "IdLoaiPhong",
                table: "HoaDonDatPhong",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LoaiPhongId",
                table: "HoaDonDatPhong",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonDatPhong_LoaiPhongId",
                table: "HoaDonDatPhong",
                column: "LoaiPhongId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDonDatPhong_LoaiPhong_LoaiPhongId",
                table: "HoaDonDatPhong",
                column: "LoaiPhongId",
                principalTable: "LoaiPhong",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
