using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TestCihaziUretimPlanlama.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departmanlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Aciklama = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Aktif = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmanlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Aciklama = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Aktif = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanDisiTarihler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Aciklama = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    TekrarliMi = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanDisiTarihler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VardiyaTanimlari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VardiyaTipi = table.Column<int>(type: "integer", nullable: false),
                    BaslangicSaati = table.Column<TimeSpan>(type: "interval", nullable: false),
                    BitisSaati = table.Column<TimeSpan>(type: "interval", nullable: false),
                    CumartesiCalismasi = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Aktif = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VardiyaTanimlari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gorevler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Aciklama = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    DepartmanId = table.Column<int>(type: "integer", nullable: false),
                    Sure = table.Column<int>(type: "integer", nullable: false),
                    Aktif = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gorevler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gorevler_Departmanlar_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "Departmanlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Personeller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Soyad = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PersonelNo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DepartmanId = table.Column<int>(type: "integer", nullable: false),
                    CalismaSekli = table.Column<int>(type: "integer", nullable: false),
                    SabitVardiyaTipi = table.Column<int>(type: "integer", nullable: true),
                    DonerVardiyaBaslangicTipi = table.Column<int>(type: "integer", nullable: true),
                    DonerVardiyaBaslangicTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Aktif = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personeller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personeller_Departmanlar_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "Departmanlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Siparisler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UretimNumarasi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Musteri = table.Column<int>(type: "integer", nullable: false),
                    IstenilenBaslangicTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    KategoriId = table.Column<int>(type: "integer", nullable: true),
                    KategoriSablonuKullan = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Durum = table.Column<int>(type: "integer", nullable: false),
                    Oncelik = table.Column<int>(type: "integer", nullable: false, defaultValue: 5),
                    SonTeslimTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Notlar = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Siparisler_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "KategoriGorevSablonlari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KategoriId = table.Column<int>(type: "integer", nullable: false),
                    GorevId = table.Column<int>(type: "integer", nullable: false),
                    Sira = table.Column<int>(type: "integer", nullable: false),
                    OzelSure = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategoriGorevSablonlari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KategoriGorevSablonlari_Gorevler_GorevId",
                        column: x => x.GorevId,
                        principalTable: "Gorevler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KategoriGorevSablonlari_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonelGorevYetkinlikleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonelId = table.Column<int>(type: "integer", nullable: false),
                    GorevId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelGorevYetkinlikleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonelGorevYetkinlikleri_Gorevler_GorevId",
                        column: x => x.GorevId,
                        principalTable: "Gorevler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonelGorevYetkinlikleri_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonelIzinleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonelId = table.Column<int>(type: "integer", nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Aciklama = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelIzinleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonelIzinleri_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UretimGorevleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SiparisId = table.Column<int>(type: "integer", nullable: false),
                    GorevId = table.Column<int>(type: "integer", nullable: false),
                    AtananPersonelId = table.Column<int>(type: "integer", nullable: true),
                    Sure = table.Column<int>(type: "integer", nullable: false),
                    PlanlananBaslangic = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PlanlananBitis = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GercekBaslangic = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GercekBitis = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Durum = table.Column<int>(type: "integer", nullable: false),
                    Notlar = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UretimGorevleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UretimGorevleri_Gorevler_GorevId",
                        column: x => x.GorevId,
                        principalTable: "Gorevler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UretimGorevleri_Personeller_AtananPersonelId",
                        column: x => x.AtananPersonelId,
                        principalTable: "Personeller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_UretimGorevleri_Siparisler_SiparisId",
                        column: x => x.SiparisId,
                        principalTable: "Siparisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KategoriGorevBagimliliklari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OncuKategoriGorevSablonuId = table.Column<int>(type: "integer", nullable: false),
                    ArdilKategoriGorevSablonuId = table.Column<int>(type: "integer", nullable: false),
                    BagimlilikTipi = table.Column<int>(type: "integer", nullable: false),
                    GecikmeGunu = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategoriGorevBagimliliklari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KategoriGorevBagimliliklari_KategoriGorevSablonlari_ArdilKa~",
                        column: x => x.ArdilKategoriGorevSablonuId,
                        principalTable: "KategoriGorevSablonlari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KategoriGorevBagimliliklari_KategoriGorevSablonlari_OncuKat~",
                        column: x => x.OncuKategoriGorevSablonuId,
                        principalTable: "KategoriGorevSablonlari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UretimGorevBagimliliklari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OncuUretimGoreviId = table.Column<int>(type: "integer", nullable: false),
                    ArdilUretimGoreviId = table.Column<int>(type: "integer", nullable: false),
                    BagimlilikTipi = table.Column<int>(type: "integer", nullable: false),
                    GecikmeGunu = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UretimGorevBagimliliklari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UretimGorevBagimliliklari_UretimGorevleri_ArdilUretimGorevi~",
                        column: x => x.ArdilUretimGoreviId,
                        principalTable: "UretimGorevleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UretimGorevBagimliliklari_UretimGorevleri_OncuUretimGoreviId",
                        column: x => x.OncuUretimGoreviId,
                        principalTable: "UretimGorevleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departmanlar_Ad",
                table: "Departmanlar",
                column: "Ad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gorevler_DepartmanId",
                table: "Gorevler",
                column: "DepartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Gorevler_DepartmanId_Ad",
                table: "Gorevler",
                columns: new[] { "DepartmanId", "Ad" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KategoriGorevBagimliliklari_ArdilKategoriGorevSablonuId",
                table: "KategoriGorevBagimliliklari",
                column: "ArdilKategoriGorevSablonuId");

            migrationBuilder.CreateIndex(
                name: "IX_KategoriGorevBagimliliklari_Oncu_Ardil",
                table: "KategoriGorevBagimliliklari",
                columns: new[] { "OncuKategoriGorevSablonuId", "ArdilKategoriGorevSablonuId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KategoriGorevSablonlari_GorevId",
                table: "KategoriGorevSablonlari",
                column: "GorevId");

            migrationBuilder.CreateIndex(
                name: "IX_KategoriGorevSablonlari_KategoriId_GorevId",
                table: "KategoriGorevSablonlari",
                columns: new[] { "KategoriId", "GorevId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KategoriGorevSablonlari_KategoriId_Sira",
                table: "KategoriGorevSablonlari",
                columns: new[] { "KategoriId", "Sira" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kategoriler_Ad",
                table: "Kategoriler",
                column: "Ad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonelGorevYetkinlikleri_GorevId",
                table: "PersonelGorevYetkinlikleri",
                column: "GorevId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelGorevYetkinlikleri_PersonelId_GorevId",
                table: "PersonelGorevYetkinlikleri",
                columns: new[] { "PersonelId", "GorevId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonelIzinleri_PersonelId",
                table: "PersonelIzinleri",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelIzinleri_Tarih",
                table: "PersonelIzinleri",
                columns: new[] { "BaslangicTarihi", "BitisTarihi" });

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_DepartmanId",
                table: "Personeller",
                column: "DepartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_PersonelNo",
                table: "Personeller",
                column: "PersonelNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanDisiTarihler_Tarih",
                table: "PlanDisiTarihler",
                column: "Tarih");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_Durum",
                table: "Siparisler",
                column: "Durum");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_IstenilenBaslangicTarihi",
                table: "Siparisler",
                column: "IstenilenBaslangicTarihi");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_KategoriId",
                table: "Siparisler",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_UretimNumarasi",
                table: "Siparisler",
                column: "UretimNumarasi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UretimGorevBagimliliklari_ArdilUretimGoreviId",
                table: "UretimGorevBagimliliklari",
                column: "ArdilUretimGoreviId");

            migrationBuilder.CreateIndex(
                name: "IX_UretimGorevBagimliliklari_Oncu_Ardil",
                table: "UretimGorevBagimliliklari",
                columns: new[] { "OncuUretimGoreviId", "ArdilUretimGoreviId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UretimGorevleri_AtananPersonelId",
                table: "UretimGorevleri",
                column: "AtananPersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_UretimGorevleri_Durum",
                table: "UretimGorevleri",
                column: "Durum");

            migrationBuilder.CreateIndex(
                name: "IX_UretimGorevleri_GorevId",
                table: "UretimGorevleri",
                column: "GorevId");

            migrationBuilder.CreateIndex(
                name: "IX_UretimGorevleri_PlanlananBaslangic",
                table: "UretimGorevleri",
                column: "PlanlananBaslangic");

            migrationBuilder.CreateIndex(
                name: "IX_UretimGorevleri_SiparisId",
                table: "UretimGorevleri",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_VardiyaTanimlari_VardiyaTipi",
                table: "VardiyaTanimlari",
                column: "VardiyaTipi",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KategoriGorevBagimliliklari");

            migrationBuilder.DropTable(
                name: "PersonelGorevYetkinlikleri");

            migrationBuilder.DropTable(
                name: "PersonelIzinleri");

            migrationBuilder.DropTable(
                name: "PlanDisiTarihler");

            migrationBuilder.DropTable(
                name: "UretimGorevBagimliliklari");

            migrationBuilder.DropTable(
                name: "VardiyaTanimlari");

            migrationBuilder.DropTable(
                name: "KategoriGorevSablonlari");

            migrationBuilder.DropTable(
                name: "UretimGorevleri");

            migrationBuilder.DropTable(
                name: "Gorevler");

            migrationBuilder.DropTable(
                name: "Personeller");

            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.DropTable(
                name: "Departmanlar");

            migrationBuilder.DropTable(
                name: "Kategoriler");
        }
    }
}
