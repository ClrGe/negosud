using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NegoSudApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
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
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_grape", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_location", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role_claims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roleid = table.Column<string>(name: "role_id", type: "text", nullable: true),
                    claimtype = table.Column<string>(name: "claim_type", type: "text", nullable: true),
                    claimvalue = table.Column<string>(name: "claim_value", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_claims", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    normalizedname = table.Column<string>(name: "normalized_name", type: "text", nullable: true),
                    concurrencystamp = table.Column<string>(name: "concurrency_stamp", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_claims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<string>(name: "user_id", type: "text", nullable: true),
                    claimtype = table.Column<string>(name: "claim_type", type: "text", nullable: true),
                    claimvalue = table.Column<string>(name: "claim_value", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_claims", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_logins",
                columns: table => new
                {
                    loginprovider = table.Column<string>(name: "login_provider", type: "text", nullable: false),
                    providerkey = table.Column<string>(name: "provider_key", type: "text", nullable: false),
                    providerdisplayname = table.Column<string>(name: "provider_display_name", type: "text", nullable: true),
                    userid = table.Column<string>(name: "user_id", type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    userid = table.Column<string>(name: "user_id", type: "text", nullable: true),
                    roleid = table.Column<string>(name: "role_id", type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "user_tokens",
                columns: table => new
                {
                    userid = table.Column<string>(name: "user_id", type: "text", nullable: true),
                    loginprovider = table.Column<string>(name: "login_provider", type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(name: "user_name", type: "text", nullable: true),
                    normalizedusername = table.Column<string>(name: "normalized_user_name", type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    normalizedemail = table.Column<string>(name: "normalized_email", type: "text", nullable: true),
                    emailconfirmed = table.Column<bool>(name: "email_confirmed", type: "boolean", nullable: false),
                    passwordhash = table.Column<string>(name: "password_hash", type: "text", nullable: true),
                    securitystamp = table.Column<string>(name: "security_stamp", type: "text", nullable: true),
                    concurrencystamp = table.Column<string>(name: "concurrency_stamp", type: "text", nullable: true),
                    phonenumber = table.Column<string>(name: "phone_number", type: "text", nullable: true),
                    phonenumberconfirmed = table.Column<bool>(name: "phone_number_confirmed", type: "boolean", nullable: false),
                    twofactorenabled = table.Column<bool>(name: "two_factor_enabled", type: "boolean", nullable: false),
                    lockoutend = table.Column<DateTimeOffset>(name: "lockout_end", type: "timestamp with time zone", nullable: true),
                    lockoutenabled = table.Column<bool>(name: "lockout_enabled", type: "boolean", nullable: false),
                    accessfailedcount = table.Column<int>(name: "access_failed_count", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
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
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
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
                    label = table.Column<string>(type: "text", nullable: true),
                    volume = table.Column<decimal>(type: "numeric", nullable: true),
                    picture = table.Column<byte[]>(type: "bytea", nullable: true),
                    yearproduced = table.Column<int>(name: "year_produced", type: "integer", nullable: true),
                    alcoholpercentage = table.Column<decimal>(name: "alcohol_percentage", type: "numeric", nullable: true),
                    currentprice = table.Column<decimal>(name: "current_price", type: "numeric", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    producerid = table.Column<int>(name: "producer_id", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bottle", x => x.id);
                    table.ForeignKey(
                        name: "fk_bottle_producers_producer_id",
                        column: x => x.producerid,
                        principalTable: "Producer",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "BottleGrape",
                columns: table => new
                {
                    grapeid = table.Column<int>(name: "grape_id", type: "integer", nullable: false),
                    bottleid = table.Column<int>(name: "bottle_id", type: "integer", nullable: false),
                    grapepercentage = table.Column<int>(name: "grape_percentage", type: "integer", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
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
                name: "BottleLocation",
                columns: table => new
                {
                    locationid = table.Column<int>(name: "location_id", type: "integer", nullable: false),
                    bottleid = table.Column<int>(name: "bottle_id", type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bottle_location", x => new { x.bottleid, x.locationid });
                    table.ForeignKey(
                        name: "fk_bottle_location_bottle_bottle_id",
                        column: x => x.bottleid,
                        principalTable: "Bottle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_bottle_location_location_location_id",
                        column: x => x.locationid,
                        principalTable: "Location",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_bottle_producer_id",
                table: "Bottle",
                column: "producer_id");

            migrationBuilder.CreateIndex(
                name: "ix_bottle_grape_grape_id",
                table: "BottleGrape",
                column: "grape_id");

            migrationBuilder.CreateIndex(
                name: "ix_bottle_location_location_id",
                table: "BottleLocation",
                column: "location_id");

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
                name: "BottleGrape");

            migrationBuilder.DropTable(
                name: "BottleLocation");

            migrationBuilder.DropTable(
                name: "role_claims");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "user_claims");

            migrationBuilder.DropTable(
                name: "user_logins");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "user_tokens");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Grape");

            migrationBuilder.DropTable(
                name: "Bottle");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Producer");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
