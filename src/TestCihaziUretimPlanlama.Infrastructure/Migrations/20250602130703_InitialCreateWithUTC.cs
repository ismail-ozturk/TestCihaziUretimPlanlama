using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestCihaziUretimPlanlama.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateWithUTC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "VardiyaTanimlari",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "VardiyaTanimlari",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "UretimGorevleri",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PlanlananBitis",
                table: "UretimGorevleri",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PlanlananBaslangic",
                table: "UretimGorevleri",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "GercekBitis",
                table: "UretimGorevleri",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "GercekBaslangic",
                table: "UretimGorevleri",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UretimGorevleri",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "UretimGorevBagimliliklari",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UretimGorevBagimliliklari",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Siparisler",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SonTeslimTarihi",
                table: "Siparisler",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IstenilenBaslangicTarihi",
                table: "Siparisler",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Siparisler",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PlanDisiTarihler",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Tarih",
                table: "PlanDisiTarihler",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PlanDisiTarihler",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Personeller",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DonerVardiyaBaslangicTarihi",
                table: "Personeller",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Personeller",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PersonelIzinleri",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PersonelIzinleri",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BitisTarihi",
                table: "PersonelIzinleri",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BaslangicTarihi",
                table: "PersonelIzinleri",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PersonelGorevYetkinlikleri",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PersonelGorevYetkinlikleri",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Kategoriler",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Kategoriler",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "KategoriGorevSablonlari",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "KategoriGorevSablonlari",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "KategoriGorevBagimliliklari",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "KategoriGorevBagimliliklari",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Gorevler",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Gorevler",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Departmanlar",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Departmanlar",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "Departmanlar",
                columns: new[] { "Id", "Aciklama", "Ad", "Aktif", "CreatedDate", "IsDeleted", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "PMD Test Departmanı", "PMD", true, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5456), false, null },
                    { 2, "CNC İşleme Departmanı", "CNC", true, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5458), false, null },
                    { 3, "Test Tamir Bakım Departmanı", "Teknik", true, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5459), false, null }
                });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "Id", "Aciklama", "Ad", "Aktif", "CreatedDate", "IsDeleted", "UpdatedDate" },
                values: new object[] { 1, "İğne plakası üretim kategorisi", "İğne Plakası", true, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5621), false, null });

            migrationBuilder.InsertData(
                table: "VardiyaTanimlari",
                columns: new[] { "Id", "Aktif", "BaslangicSaati", "BitisSaati", "CreatedDate", "IsDeleted", "UpdatedDate", "VardiyaTipi" },
                values: new object[] { 1, true, new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 17, 0, 0, 0), new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5523), false, null, 1 });

            migrationBuilder.InsertData(
                table: "VardiyaTanimlari",
                columns: new[] { "Id", "Aktif", "BaslangicSaati", "BitisSaati", "CreatedDate", "CumartesiCalismasi", "IsDeleted", "UpdatedDate", "VardiyaTipi" },
                values: new object[,]
                {
                    { 2, true, new TimeSpan(0, 7, 0, 0, 0), new TimeSpan(0, 15, 0, 0, 0), new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5525), true, false, null, 2 },
                    { 3, true, new TimeSpan(0, 7, 0, 0, 0), new TimeSpan(0, 15, 0, 0, 0), new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5526), true, false, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "VardiyaTanimlari",
                columns: new[] { "Id", "Aktif", "BaslangicSaati", "BitisSaati", "CreatedDate", "IsDeleted", "UpdatedDate", "VardiyaTipi" },
                values: new object[] { 4, true, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 23, 0, 0, 0), new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5527), false, null, 4 });

            migrationBuilder.InsertData(
                table: "Gorevler",
                columns: new[] { "Id", "Aciklama", "Ad", "Aktif", "CreatedDate", "DepartmanId", "IsDeleted", "Sure", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "PV hazırlama işlemleri", "PV Hazırlama", true, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5576), 1, false, 32, null },
                    { 2, "Şematik çizim ve malzeme kontrol işlemleri", "Şematik Çizme ve Eksik Malzeme Kontrolü", true, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5578), 1, false, 32, null },
                    { 3, "Test programı hazırlama işlemleri", "Test Programı Hazırlama", true, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5579), 1, false, 40, null },
                    { 4, "Malzeme hazırlık işlemleri", "Malzeme Hazırlık", true, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5590), 3, false, 3, null },
                    { 5, "CNC ile PCB sabitleme işlemleri", "CNC Test Cihazı PCB Sabitleme", true, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5582), 2, false, 3, null },
                    { 6, "Teknik kontrol listesi işlemleri", "Teknik Checklist", true, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5591), 3, false, 8, null },
                    { 7, "Kablolama ve el ölçümü kontrol işlemleri", "Kablolama ve test adımları tek adım modunda kontrol (El Ölçümü)", true, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5581), 1, false, 5, null },
                    { 8, "Test programı kontrol ve iğne yerleştirme", "TP Kontrol ve İğne yerleştirme", true, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5592), 3, false, 4, null },
                    { 9, "Pertenax ve devre hazırlık işlemleri", "Pertenax ve Devre Hazırlığı", true, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5593), 3, false, 10, null },
                    { 10, "Malzeme sağlamlık test işlemleri", "Malzeme Sağlamlık Testi", true, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5595), 3, false, 2, null },
                    { 11, "Ürün etiketleme işlemleri", "Etiketleme", true, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5596), 3, false, 3, null },
                    { 12, "CNC ile üst baskı işlemleri", "CNC Test Cihazı Üst Baskı", true, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5583), 2, false, 8, null },
                    { 13, "Test cihazı kablolama ve montaj işlemleri", "Test Cihazı Kablolama ve Montaj", true, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5597), 3, false, 24, null },
                    { 14, "Test cihazı malzeme yerleştirme işlemleri", "Test Cihazı Malzeme Yerleştirme", true, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5598), 3, false, 3, null },
                    { 15, "Şema ve test cihazı kontrol işlemleri", "Şema ve Test Cihazı Kontrolü", true, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5599), 3, false, 15, null },
                    { 16, "CNC manuel işleme", "CNC Manuel İş", true, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5585), 2, false, 32, null },
                    { 17, "CNC konsept adaptör işleme", "CNC Konsept Adaptör İşleme", true, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5586), 2, false, 32, null },
                    { 18, "CNC test cihazı plakası işleme", "CNC Test Cihazı Plakası İşleme", true, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5587), 2, false, 16, null },
                    { 19, "CNC test cihazı kontrol ve ayar işlemleri", "CNC Test Cihazı Kontrol / Ayar", true, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5588), 2, false, 32, null }
                });

            migrationBuilder.InsertData(
                table: "Personeller",
                columns: new[] { "Id", "Ad", "Aktif", "CalismaSekli", "CreatedDate", "DepartmanId", "DonerVardiyaBaslangicTarihi", "DonerVardiyaBaslangicTipi", "IsDeleted", "PersonelNo", "SabitVardiyaTipi", "Soyad", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Kaan", true, 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5740), 1, null, null, false, "P001", 1, "Karamancı", null },
                    { 2, "Mert", true, 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5742), 1, null, null, false, "P002", 1, "Göncü", null },
                    { 3, "Kadir", true, 2, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5747), 2, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false, "P003", null, "Vural", null },
                    { 4, "Ramazan", true, 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5749), 2, null, null, false, "P004", 2, "Öztürk", null },
                    { 5, "Adem", true, 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5750), 2, null, null, false, "P005", 2, "Yüksel", null },
                    { 6, "Sinan", true, 2, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5752), 3, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false, "P006", null, "Tekyol", null },
                    { 7, "Emre", true, 2, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5754), 3, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, false, "P007", null, "Kahveci", null },
                    { 8, "Nuri", true, 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5755), 3, null, null, false, "P008", 1, "Ersipahi", null },
                    { 9, "Mustafa", true, 2, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5757), 1, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false, "P009", null, "Durgun", null },
                    { 10, "Mehmet Ali", true, 2, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5759), 1, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, false, "P010", null, "Binici", null },
                    { 11, "İbrahim", true, 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5760), 3, null, null, false, "P011", 1, "Gelen", null }
                });

            migrationBuilder.InsertData(
                table: "KategoriGorevSablonlari",
                columns: new[] { "Id", "CreatedDate", "GorevId", "IsDeleted", "KategoriId", "OzelSure", "Sira", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5638), 1, false, 1, 32, 1, null },
                    { 2, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5639), 2, false, 1, 32, 2, null },
                    { 3, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5640), 3, false, 1, 40, 3, null },
                    { 4, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5642), 18, false, 1, 16, 4, null },
                    { 5, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5643), 8, false, 1, 4, 5, null },
                    { 6, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5645), 4, false, 1, 3, 6, null },
                    { 7, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5646), 9, false, 1, 10, 7, null },
                    { 8, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5648), 10, false, 1, 2, 8, null },
                    { 9, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5649), 12, false, 1, 8, 9, null },
                    { 10, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5650), 14, false, 1, 3, 10, null },
                    { 11, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5651), 13, false, 1, 24, 11, null },
                    { 12, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5653), 11, false, 1, 3, 12, null },
                    { 13, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5654), 15, false, 1, 15, 13, null },
                    { 14, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5656), 6, false, 1, 8, 14, null },
                    { 15, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5657), 7, false, 1, 5, 15, null }
                });

            migrationBuilder.InsertData(
                table: "PersonelGorevYetkinlikleri",
                columns: new[] { "Id", "CreatedDate", "GorevId", "IsDeleted", "PersonelId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5769), 1, false, 1, null },
                    { 2, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5770), 2, false, 1, null },
                    { 3, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5771), 3, false, 1, null },
                    { 4, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5772), 7, false, 1, null },
                    { 5, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5775), 1, false, 2, null },
                    { 6, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5776), 2, false, 2, null },
                    { 7, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5776), 3, false, 2, null },
                    { 8, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5777), 7, false, 2, null },
                    { 9, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5779), 5, false, 3, null },
                    { 10, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5780), 12, false, 3, null },
                    { 11, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5781), 16, false, 3, null },
                    { 12, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5781), 17, false, 3, null },
                    { 13, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5782), 18, false, 3, null },
                    { 14, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5783), 19, false, 3, null },
                    { 15, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5785), 5, false, 4, null },
                    { 16, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5785), 5, false, 5, null },
                    { 17, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5786), 4, false, 6, null },
                    { 18, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5787), 8, false, 6, null },
                    { 19, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5788), 9, false, 6, null },
                    { 20, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5789), 10, false, 6, null },
                    { 21, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5790), 11, false, 6, null },
                    { 22, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5790), 13, false, 6, null },
                    { 23, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5791), 14, false, 6, null },
                    { 24, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5792), 15, false, 6, null },
                    { 25, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5806), 4, false, 7, null },
                    { 26, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5807), 8, false, 7, null },
                    { 27, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5807), 9, false, 7, null },
                    { 28, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5808), 10, false, 7, null },
                    { 29, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5809), 11, false, 7, null },
                    { 30, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5810), 13, false, 7, null },
                    { 31, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5811), 14, false, 7, null },
                    { 32, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5812), 15, false, 7, null },
                    { 33, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5813), 6, false, 8, null }
                });

            migrationBuilder.InsertData(
                table: "KategoriGorevBagimliliklari",
                columns: new[] { "Id", "ArdilKategoriGorevSablonuId", "BagimlilikTipi", "CreatedDate", "IsDeleted", "OncuKategoriGorevSablonuId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 2, 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5697), false, 1, null },
                    { 2, 3, 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5698), false, 2, null },
                    { 3, 4, 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5699), false, 1, null },
                    { 4, 5, 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5700), false, 2, null },
                    { 5, 5, 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5701), false, 4, null },
                    { 6, 6, 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5702), false, 5, null },
                    { 7, 7, 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5703), false, 6, null },
                    { 8, 8, 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5704), false, 7, null },
                    { 9, 9, 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5705), false, 8, null },
                    { 10, 10, 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5707), false, 9, null },
                    { 11, 11, 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5708), false, 10, null },
                    { 12, 12, 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5709), false, 11, null },
                    { 13, 13, 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5710), false, 12, null },
                    { 14, 14, 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5711), false, 13, null },
                    { 15, 15, 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5714), false, 3, null },
                    { 16, 15, 1, new DateTime(2025, 6, 2, 13, 7, 3, 539, DateTimeKind.Utc).AddTicks(5715), false, 14, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "KategoriGorevBagimliliklari",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "PersonelGorevYetkinlikleri",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "VardiyaTanimlari",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VardiyaTanimlari",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VardiyaTanimlari",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VardiyaTanimlari",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "KategoriGorevSablonlari",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Gorevler",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Kategoriler",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "VardiyaTanimlari",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "VardiyaTanimlari",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "UretimGorevleri",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PlanlananBitis",
                table: "UretimGorevleri",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PlanlananBaslangic",
                table: "UretimGorevleri",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "GercekBitis",
                table: "UretimGorevleri",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "GercekBaslangic",
                table: "UretimGorevleri",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UretimGorevleri",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "UretimGorevBagimliliklari",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UretimGorevBagimliliklari",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Siparisler",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SonTeslimTarihi",
                table: "Siparisler",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IstenilenBaslangicTarihi",
                table: "Siparisler",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Siparisler",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PlanDisiTarihler",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Tarih",
                table: "PlanDisiTarihler",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PlanDisiTarihler",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Personeller",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DonerVardiyaBaslangicTarihi",
                table: "Personeller",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Personeller",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PersonelIzinleri",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PersonelIzinleri",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BitisTarihi",
                table: "PersonelIzinleri",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BaslangicTarihi",
                table: "PersonelIzinleri",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PersonelGorevYetkinlikleri",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PersonelGorevYetkinlikleri",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Kategoriler",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Kategoriler",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "KategoriGorevSablonlari",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "KategoriGorevSablonlari",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "KategoriGorevBagimliliklari",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "KategoriGorevBagimliliklari",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Gorevler",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Gorevler",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Departmanlar",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Departmanlar",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
