using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NegoSudApi.Migrations
{
    /// <inheritdoc />
    public partial class InitNegoSud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    zipcode = table.Column<int>(name: "zip_code", type: "integer", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 375, DateTimeKind.Utc).AddTicks(4869)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 375, DateTimeKind.Utc).AddTicks(5105)),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_city", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(650)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(963)),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Grape",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    grapetype = table.Column<string>(name: "grape_type", type: "text", nullable: true),
                    winetype = table.Column<string>(name: "wine_type", type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(3811)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(3997)),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_grape", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    access = table.Column<string>(type: "text", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 377, DateTimeKind.Utc).AddTicks(315)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 377, DateTimeKind.Utc).AddTicks(483)),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permission", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    permissionid = table.Column<int>(name: "permission_id", type: "integer", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 376, DateTimeKind.Utc).AddTicks(8156)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 376, DateTimeKind.Utc).AddTicks(8354)),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "StorageLocation",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(5949)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(6210)),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_storage_location", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstname = table.Column<string>(name: "first_name", type: "text", nullable: true),
                    lastname = table.Column<string>(name: "last_name", type: "text", nullable: true),
                    roleid = table.Column<int>(name: "role_id", type: "integer", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 376, DateTimeKind.Utc).AddTicks(5985)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 376, DateTimeKind.Utc).AddTicks(6176)),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    refreshtoken = table.Column<string>(name: "refresh_token", type: "text", nullable: true),
                    refreshtokenexpirytime = table.Column<DateTime>(name: "refresh_token_expiry_time", type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WineLabel",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    label = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 373, DateTimeKind.Utc).AddTicks(5638)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 373, DateTimeKind.Utc).AddTicks(5810)),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_wine_label", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    label = table.Column<string>(type: "text", nullable: true),
                    firstline = table.Column<string>(name: "first_line", type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 375, DateTimeKind.Utc).AddTicks(8061)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 375, DateTimeKind.Utc).AddTicks(8313)),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    cityid = table.Column<int>(name: "city_id", type: "integer", nullable: true),
                    userid = table.Column<int>(name: "user_id", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_address", x => x.id);
                    table.ForeignKey(
                        name: "fk_address_city_city_id",
                        column: x => x.cityid,
                        principalTable: "City",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 375, DateTimeKind.Utc).AddTicks(1758)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 375, DateTimeKind.Utc).AddTicks(1989)),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    countryid = table.Column<int>(name: "country_id", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_region", x => x.id);
                    table.ForeignKey(
                        name: "fk_region_country_country_id",
                        column: x => x.countryid,
                        principalTable: "Country",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    details = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(8227)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(8473)),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    regionid = table.Column<int>(name: "region_id", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_producer", x => x.id);
                    table.ForeignKey(
                        name: "fk_producer_regions_region_id",
                        column: x => x.regionid,
                        principalTable: "Region",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Bottle",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullname = table.Column<string>(name: "full_name", type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    volume = table.Column<decimal>(type: "numeric", nullable: true),
                    picture = table.Column<string>(type: "text", nullable: true),
                    yearproduced = table.Column<int>(name: "year_produced", type: "integer", nullable: true),
                    alcoholpercentage = table.Column<decimal>(name: "alcohol_percentage", type: "numeric", nullable: true),
                    currentprice = table.Column<decimal>(name: "current_price", type: "numeric", nullable: true),
                    winetype = table.Column<string>(name: "wine_type", type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 373, DateTimeKind.Utc).AddTicks(3085)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 373, DateTimeKind.Utc).AddTicks(3336)),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    producerid = table.Column<int>(name: "producer_id", type: "integer", nullable: true),
                    winelabelid = table.Column<int>(name: "wine_label_id", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bottle", x => x.id);
                    table.ForeignKey(
                        name: "fk_bottle_producers_producer_id",
                        column: x => x.producerid,
                        principalTable: "Producer",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_bottle_wine_labels_wine_label_id",
                        column: x => x.winelabelid,
                        principalTable: "WineLabel",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "BottleGrape",
                columns: table => new
                {
                    grapeid = table.Column<int>(name: "grape_id", type: "integer", nullable: false),
                    bottleid = table.Column<int>(name: "bottle_id", type: "integer", nullable: false),
                    grapepercentage = table.Column<decimal>(name: "grape_percentage", type: "numeric", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 373, DateTimeKind.Utc).AddTicks(6405)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 373, DateTimeKind.Utc).AddTicks(6635)),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bottle_grape", x => new { x.bottleid, x.grapeid });
                    table.ForeignKey(
                        name: "fk_bottle_grape_bottle_bottle_id",
                        column: x => x.bottleid,
                        principalTable: "Bottle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_bottle_grape_grapes_grape_id",
                        column: x => x.grapeid,
                        principalTable: "Grape",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BottleStorageLocation",
                columns: table => new
                {
                    storagelocationid = table.Column<int>(name: "storage_location_id", type: "integer", nullable: false),
                    bottleid = table.Column<int>(name: "bottle_id", type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 376, DateTimeKind.Utc).AddTicks(376)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 376, DateTimeKind.Utc).AddTicks(594)),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bottle_storage_location", x => new { x.bottleid, x.storagelocationid });
                    table.ForeignKey(
                        name: "fk_bottle_storage_location_bottle_bottle_id",
                        column: x => x.bottleid,
                        principalTable: "Bottle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_bottle_storage_location_storage_location_storage_location_id",
                        column: x => x.storagelocationid,
                        principalTable: "StorageLocation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_address_city_id",
                table: "Address",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "ix_bottle_producer_id",
                table: "Bottle",
                column: "producer_id");

            migrationBuilder.CreateIndex(
                name: "ix_bottle_wine_label_id",
                table: "Bottle",
                column: "wine_label_id");

            migrationBuilder.CreateIndex(
                name: "ix_bottle_wine_type",
                table: "Bottle",
                column: "wine_type");

            migrationBuilder.CreateIndex(
                name: "ix_bottle_grape_grape_id",
                table: "BottleGrape",
                column: "grape_id");

            migrationBuilder.CreateIndex(
                name: "ix_bottle_storage_location_storage_location_id",
                table: "BottleStorageLocation",
                column: "storage_location_id");

            migrationBuilder.CreateIndex(
                name: "ix_producer_region_id",
                table: "Producer",
                column: "region_id");

            migrationBuilder.CreateIndex(
                name: "ix_region_country_id",
                table: "Region",
                column: "country_id");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "BottleGrape");

            migrationBuilder.DropTable(
                name: "BottleStorageLocation");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Grape");

            migrationBuilder.DropTable(
                name: "Bottle");

            migrationBuilder.DropTable(
                name: "StorageLocation");

            migrationBuilder.DropTable(
                name: "Producer");

            migrationBuilder.DropTable(
                name: "WineLabel");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
