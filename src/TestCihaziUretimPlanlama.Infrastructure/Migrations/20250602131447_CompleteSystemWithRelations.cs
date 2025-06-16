using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestCihaziUretimPlanlama.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CompleteSystemWithRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6373));

            migrationBuilder.UpdateData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6385));

            migrationBuilder.UpdateData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6387));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6481));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6482));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6484));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6494));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6486));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6495));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6485));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6496));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6497));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6499));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6501));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6502));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6503));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6489));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6490));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6491));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6493));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6605));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6606));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6607));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6608));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6609));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6610));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6611));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6612));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6613));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6614));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6615));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6615));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6616));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6617));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6618));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6619));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6541));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6543));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6544));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6546));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6547));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6548));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6550));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6577));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6579));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6580));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6581));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6582));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6583));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6584));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6585));

            migrationBuilder.UpdateData(
                table: "Kategoriler",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6525));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6673));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6674));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6675));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6676));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6680));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6681));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6682));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6682));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6684));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6685));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6686));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6713));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6714));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6714));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6717));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6718));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6719));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6721));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6723));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6724));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6725));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6727));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6727));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6728));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6729));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6730));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6731));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6732));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6733));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6735));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6644));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6646));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6652));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6654));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6655));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6658));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6659));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6661));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6662));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6664));

            migrationBuilder.UpdateData(
                table: "VardiyaTanimlari",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6461));

            migrationBuilder.UpdateData(
                table: "VardiyaTanimlari",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6463));

            migrationBuilder.UpdateData(
                table: "VardiyaTanimlari",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6464));

            migrationBuilder.UpdateData(
                table: "VardiyaTanimlari",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 14, 47, 725, DateTimeKind.Utc).AddTicks(6465));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5456));

            migrationBuilder.UpdateData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5458));

            migrationBuilder.UpdateData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5459));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5576));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5578));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5579));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5590));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5582));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5591));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5581));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5592));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5593));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5595));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5596));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5583));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5597));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5598));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5599));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5585));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5586));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5587));

            migrationBuilder.UpdateData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5588));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5697));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5698));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5699));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5700));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5701));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5702));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5703));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5704));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5705));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5707));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5708));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5709));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5710));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5711));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5714));

            migrationBuilder.UpdateData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5715));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5638));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5639));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5640));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5642));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5643));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5645));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5646));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5648));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5649));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5650));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5651));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5653));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5654));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5656));

            migrationBuilder.UpdateData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5657));

            migrationBuilder.UpdateData(
                table: "Kategoriler",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5621));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5769));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5770));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5771));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5772));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5775));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5776));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5776));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5777));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5780));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5781));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5781));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5782));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5783));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5785));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5785));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5786));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5787));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5788));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5789));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5791));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5792));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5806));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5807));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5807));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5808));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5809));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5811));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5812));

            migrationBuilder.UpdateData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5813));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5740));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5742));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5747));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5749));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5750));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5752));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5754));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5755));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5757));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5759));

            migrationBuilder.UpdateData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5760));

            migrationBuilder.UpdateData(
                table: "VardiyaTanimlari",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5523));

            migrationBuilder.UpdateData(
                table: "VardiyaTanimlari",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5525));

            migrationBuilder.UpdateData(
                table: "VardiyaTanimlari",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5526));

            migrationBuilder.UpdateData(
                table: "VardiyaTanimlari",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5527));
        }
    }
}
