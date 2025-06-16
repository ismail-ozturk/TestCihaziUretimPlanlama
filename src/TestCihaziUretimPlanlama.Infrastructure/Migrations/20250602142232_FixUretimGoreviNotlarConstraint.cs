using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestCihaziUretimPlanlama.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixUretimGoreviNotlarConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notlar",
                table: "UretimGorevleri",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notlar",
                table: "UretimGorevleri",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

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
    }
}
