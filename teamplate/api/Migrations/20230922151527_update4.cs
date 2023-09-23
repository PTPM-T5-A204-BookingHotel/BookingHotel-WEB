using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class update4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDonDatPhong_DichVu_DichVuId",
                table: "HoaDonDatPhong");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDonDatPhong_KhachHang_KhachHangId",
                table: "HoaDonDatPhong");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDonDatPhong_Phong_PhongId",
                table: "HoaDonDatPhong");

            migrationBuilder.DropForeignKey(
                name: "FK_Phong_LoaiPhong_LoaiPhongId",
                table: "Phong");

            migrationBuilder.DropIndex(
                name: "IX_HoaDonDatPhong_DichVuId",
                table: "HoaDonDatPhong");

            migrationBuilder.DropIndex(
                name: "IX_HoaDonDatPhong_PhongId",
                table: "HoaDonDatPhong");

            migrationBuilder.DropColumn(
                name: "IdLoaiPhong",
                table: "Phong");

            migrationBuilder.DropColumn(
                name: "DichVuId",
                table: "HoaDonDatPhong");

            migrationBuilder.DropColumn(
                name: "IdDichVu",
                table: "HoaDonDatPhong");

            migrationBuilder.DropColumn(
                name: "IdKhachHang",
                table: "HoaDonDatPhong");

            migrationBuilder.DropColumn(
                name: "IdPhong",
                table: "HoaDonDatPhong");

            migrationBuilder.DropColumn(
                name: "PhongId",
                table: "HoaDonDatPhong");

            migrationBuilder.AlterColumn<int>(
                name: "SoPhong",
                table: "Phong",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LoaiPhongId",
                table: "Phong",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Ten",
                table: "LoaiPhong",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<double>(
                name: "GiaPhong",
                table: "LoaiPhong",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mota",
                table: "LoaiPhong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ten",
                table: "KhachHang",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "SoDienThoai",
                table: "KhachHang",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgaySinh",
                table: "KhachHang",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "KhachHang",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DiaChi",
                table: "KhachHang",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CCCD",
                table: "KhachHang",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "TongTien",
                table: "HoaDonDatPhong",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "KhachHangId",
                table: "HoaDonDatPhong",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LoaiPhongId",
                table: "HoaDonDatPhong",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenDichVu",
                table: "DichVu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MoTaDichVu",
                table: "DichVu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "GiaDichVu",
                table: "DichVu",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateTable(
                name: "HoaDonDatPhongDichVu",
                columns: table => new
                {
                    HoaDonDatPhongId = table.Column<int>(type: "int", nullable: false),
                    DichVuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonDatPhongDichVu", x => new { x.HoaDonDatPhongId, x.DichVuId });
                    table.ForeignKey(
                        name: "FK_HoaDonDatPhongDichVu_DichVu_DichVuId",
                        column: x => x.DichVuId,
                        principalTable: "DichVu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDonDatPhongDichVu_HoaDonDatPhong_HoaDonDatPhongId",
                        column: x => x.HoaDonDatPhongId,
                        principalTable: "HoaDonDatPhong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonDatPhong_LoaiPhongId",
                table: "HoaDonDatPhong",
                column: "LoaiPhongId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonDatPhongDichVu_DichVuId",
                table: "HoaDonDatPhongDichVu",
                column: "DichVuId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDonDatPhong_KhachHang_KhachHangId",
                table: "HoaDonDatPhong",
                column: "KhachHangId",
                principalTable: "KhachHang",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDonDatPhong_LoaiPhong_LoaiPhongId",
                table: "HoaDonDatPhong",
                column: "LoaiPhongId",
                principalTable: "LoaiPhong",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Phong_LoaiPhong_LoaiPhongId",
                table: "Phong",
                column: "LoaiPhongId",
                principalTable: "LoaiPhong",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDonDatPhong_KhachHang_KhachHangId",
                table: "HoaDonDatPhong");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDonDatPhong_LoaiPhong_LoaiPhongId",
                table: "HoaDonDatPhong");

            migrationBuilder.DropForeignKey(
                name: "FK_Phong_LoaiPhong_LoaiPhongId",
                table: "Phong");

            migrationBuilder.DropTable(
                name: "HoaDonDatPhongDichVu");

            migrationBuilder.DropIndex(
                name: "IX_HoaDonDatPhong_LoaiPhongId",
                table: "HoaDonDatPhong");

            migrationBuilder.DropColumn(
                name: "GiaPhong",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "Mota",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "LoaiPhongId",
                table: "HoaDonDatPhong");

            migrationBuilder.AlterColumn<int>(
                name: "SoPhong",
                table: "Phong",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LoaiPhongId",
                table: "Phong",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdLoaiPhong",
                table: "Phong",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Ten",
                table: "LoaiPhong",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ten",
                table: "KhachHang",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SoDienThoai",
                table: "KhachHang",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgaySinh",
                table: "KhachHang",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "KhachHang",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DiaChi",
                table: "KhachHang",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CCCD",
                table: "KhachHang",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TongTien",
                table: "HoaDonDatPhong",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KhachHangId",
                table: "HoaDonDatPhong",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DichVuId",
                table: "HoaDonDatPhong",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdDichVu",
                table: "HoaDonDatPhong",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdKhachHang",
                table: "HoaDonDatPhong",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPhong",
                table: "HoaDonDatPhong",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PhongId",
                table: "HoaDonDatPhong",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "TenDichVu",
                table: "DichVu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MoTaDichVu",
                table: "DichVu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "GiaDichVu",
                table: "DichVu",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonDatPhong_DichVuId",
                table: "HoaDonDatPhong",
                column: "DichVuId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonDatPhong_PhongId",
                table: "HoaDonDatPhong",
                column: "PhongId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDonDatPhong_DichVu_DichVuId",
                table: "HoaDonDatPhong",
                column: "DichVuId",
                principalTable: "DichVu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDonDatPhong_KhachHang_KhachHangId",
                table: "HoaDonDatPhong",
                column: "KhachHangId",
                principalTable: "KhachHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDonDatPhong_Phong_PhongId",
                table: "HoaDonDatPhong",
                column: "PhongId",
                principalTable: "Phong",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Phong_LoaiPhong_LoaiPhongId",
                table: "Phong",
                column: "LoaiPhongId",
                principalTable: "LoaiPhong",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
