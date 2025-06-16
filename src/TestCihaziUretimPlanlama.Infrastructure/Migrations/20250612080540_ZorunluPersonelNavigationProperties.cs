using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestCihaziUretimPlanlama.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ZorunluPersonelNavigationProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ZorunluCncPersonelId",
                table: "Siparisler",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZorunluPmdPersonelId",
                table: "Siparisler",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZorunluTeknikPersonelId",
                table: "Siparisler",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6170));

            migrationBuilder.UpdateData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6172));

            migrationBuilder.UpdateData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6173));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6276));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6277));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6279));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6281));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6280));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6310));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6311));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6313));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6282));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6316));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6317));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6318));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6303));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6304));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6306));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6387));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6388));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6389));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6390));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6391));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6392));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6393));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6394));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6395));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6395));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6396));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6397));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6434));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6435));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6436));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6437));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6357));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6358));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6359));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6360));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6362));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6363));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6364));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6365));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6366));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6367));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6368));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6369));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6370));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6371));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6372));

            migrationBuilder.UpdateData(
                table: "Kategoriler",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6339));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6491));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6492));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6493));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6494));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6497));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6498));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6499));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6501));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6502));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6503));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6505));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6505));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6506));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6508));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6508));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6509));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6510));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6512));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6512));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6513));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6514));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6515));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6516));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6518));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6518));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6519));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6520));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6521));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6521));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6524));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6526));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6528));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6462));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6464));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6468));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6470));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6471));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6473));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6474));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6476));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6477));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6479));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6480));

            migrationBuilder.UpdateData(
                table: "VardiyaTanimlari",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "VardiyaTanimlari",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6254));

            migrationBuilder.UpdateData(
                table: "VardiyaTanimlari",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6256));

            migrationBuilder.UpdateData(
                table: "VardiyaTanimlari",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 8, 5, 40, 286, DateTimeKind.Utc).AddTicks(6257));

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_ZorunluCncPersonelId",
                table: "Siparisler",
                column: "ZorunluCncPersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_ZorunluPmdPersonelId",
                table: "Siparisler",
                column: "ZorunluPmdPersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_ZorunluTeknikPersonelId",
                table: "Siparisler",
                column: "ZorunluTeknikPersonelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Siparisler_Personeller_ZorunluCncPersonelId",
                table: "Siparisler",
                column: "ZorunluCncPersonelId",
                principalTable: "Personeller",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Siparisler_Personeller_ZorunluPmdPersonelId",
                table: "Siparisler",
                column: "ZorunluPmdPersonelId",
                principalTable: "Personeller",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Siparisler_Personeller_ZorunluTeknikPersonelId",
                table: "Siparisler",
                column: "ZorunluTeknikPersonelId",
                principalTable: "Personeller",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Siparisler_Personeller_ZorunluCncPersonelId",
                table: "Siparisler");

            migrationBuilder.DropForeignKey(
                name: "FK_Siparisler_Personeller_ZorunluPmdPersonelId",
                table: "Siparisler");

            migrationBuilder.DropForeignKey(
                name: "FK_Siparisler_Personeller_ZorunluTeknikPersonelId",
                table: "Siparisler");

            migrationBuilder.DropIndex(
                name: "IX_Siparisler_ZorunluCncPersonelId",
                table: "Siparisler");

            migrationBuilder.DropIndex(
                name: "IX_Siparisler_ZorunluPmdPersonelId",
                table: "Siparisler");

            migrationBuilder.DropIndex(
                name: "IX_Siparisler_ZorunluTeknikPersonelId",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "ZorunluCncPersonelId",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "ZorunluPmdPersonelId",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "ZorunluTeknikPersonelId",
                table: "Siparisler");

            migrationBuilder.UpdateData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2307));

            migrationBuilder.UpdateData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2309));

            migrationBuilder.UpdateData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2310));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2408));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2409));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2411));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2421));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2413));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2422));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2412));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2423));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2424));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2426));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2427));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2415));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2428));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2430));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2431));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2416));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2417));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2420));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2528));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2530));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2530));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2531));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2532));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2533));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2534));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2535));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2536));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2537));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2538));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2539));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2540));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2541));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2542));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2543));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2473));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2475));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2476));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2477));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2478));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2479));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2500));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2501));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2502));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2503));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2505));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2507));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2508));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2509));

            migrationBuilder.UpdateData(
                table: "Kategoriler",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2454));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2594));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2597));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2598));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2598));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2601));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2602));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2603));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2606));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2607));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2626));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2627));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2628));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2629));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2631));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2632));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2633));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2634));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2635));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2636));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2637));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2638));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2638));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2640));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2641));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2642));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2643));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2643));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2644));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2645));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2646));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2647));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2567));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2569));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2573));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2574));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2576));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2578));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2579));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2581));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2582));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2584));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2586));

            migrationBuilder.UpdateData(
                table: "VardiyaTanimlari",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2385));

            migrationBuilder.UpdateData(
                table: "VardiyaTanimlari",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2387));

            migrationBuilder.UpdateData(
                table: "VardiyaTanimlari",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2388));

            migrationBuilder.UpdateData(
                table: "VardiyaTanimlari",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 14, 22, 32, 57, DateTimeKind.Utc).AddTicks(2390));
        }
    }
}
