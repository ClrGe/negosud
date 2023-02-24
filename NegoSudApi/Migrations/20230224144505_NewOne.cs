using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NegoSudApi.Migrations
{
    /// <inheritdoc />
    public partial class NewOne : Migration
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
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValueSql: "NOW()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "text", nullable: true)
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
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValueSql: "NOW()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
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
                    access = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValueSql: "NOW()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
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
                    name = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValueSql: "NOW()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
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
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValueSql: "NOW()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_storage_location", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "VAT",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    value = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vat", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WineLabel",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    label = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValueSql: "NOW()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_wine_label", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    zipcode = table.Column<int>(name: "zip_code", type: "integer", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValueSql: "NOW()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    countryid = table.Column<int>(name: "country_id", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_city", x => x.id);
                    table.ForeignKey(
                        name: "fk_city_country_country_id",
                        column: x => x.countryid,
                        principalTable: "Country",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValueSql: "NOW()"),
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
                name: "PermissionRole",
                columns: table => new
                {
                    permissionid = table.Column<int>(name: "permission_id", type: "integer", nullable: false),
                    roleid = table.Column<int>(name: "role_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permission_role", x => new { x.permissionid, x.roleid });
                    table.ForeignKey(
                        name: "fk_permission_role_permission_permission_id",
                        column: x => x.permissionid,
                        principalTable: "Permission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_permission_role_role_role_id",
                        column: x => x.roleid,
                        principalTable: "Role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstname = table.Column<string>(name: "first_name", type: "text", nullable: true),
                    lastname = table.Column<string>(name: "last_name", type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValueSql: "NOW()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    refreshtoken = table.Column<string>(name: "refresh_token", type: "text", nullable: true),
                    refreshtokenexpirytime = table.Column<DateTime>(name: "refresh_token_expiry_time", type: "timestamp with time zone", nullable: true),
                    roleid = table.Column<int>(name: "role_id", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_roles_role_id",
                        column: x => x.roleid,
                        principalTable: "Role",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    label = table.Column<string>(type: "text", nullable: true),
                    firstline = table.Column<string>(name: "first_line", type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValueSql: "NOW()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
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
                    table.ForeignKey(
                        name: "fk_address_users_user_id",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrder",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    reference = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValueSql: "NOW()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    cancelledat = table.Column<DateTime>(name: "cancelled_at", type: "timestamp with time zone", nullable: true),
                    dateorder = table.Column<DateTime>(name: "date_order", type: "timestamp with time zone", nullable: true),
                    datedelivery = table.Column<DateTime>(name: "date_delivery", type: "timestamp with time zone", nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    cancelledby = table.Column<string>(name: "cancelled_by", type: "text", nullable: true),
                    deliveryaddressid = table.Column<int>(name: "delivery_address_id", type: "integer", nullable: true),
                    customerid = table.Column<int>(name: "customer_id", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customer_order", x => x.id);
                    table.ForeignKey(
                        name: "fk_customer_order_address_delivery_address_id",
                        column: x => x.deliveryaddressid,
                        principalTable: "Address",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_customer_order_users_customer_id",
                        column: x => x.customerid,
                        principalTable: "User",
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
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValueSql: "NOW()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    regionid = table.Column<int>(name: "region_id", type: "integer", nullable: true),
                    addressid = table.Column<int>(name: "address_id", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_producer", x => x.id);
                    table.ForeignKey(
                        name: "fk_producer_addresses_address_id",
                        column: x => x.addressid,
                        principalTable: "Address",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_producer_regions_region_id",
                        column: x => x.regionid,
                        principalTable: "Region",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    details = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValueSql: "NOW()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_supplier", x => x.id);
                    table.ForeignKey(
                        name: "fk_supplier_address_id",
                        column: x => x.id,
                        principalTable: "Address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    supplierprice = table.Column<decimal>(name: "supplier_price", type: "numeric", nullable: true),
                    customerprice = table.Column<decimal>(name: "customer_price", type: "numeric", nullable: true),
                    winetype = table.Column<string>(name: "wine_type", type: "text", nullable: true),
                    thresholdtoorder = table.Column<int>(name: "threshold_to_order", type: "integer", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValueSql: "NOW()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    vatid = table.Column<int>(name: "vat_id", type: "integer", nullable: true),
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
                        name: "fk_bottle_vat_vat_id",
                        column: x => x.vatid,
                        principalTable: "VAT",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_bottle_wine_labels_wine_label_id",
                        column: x => x.winelabelid,
                        principalTable: "WineLabel",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "SupplierOrder",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValueSql: "NOW()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    cancelledat = table.Column<DateTime>(name: "cancelled_at", type: "timestamp with time zone", nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    cancelledby = table.Column<string>(name: "cancelled_by", type: "text", nullable: true),
                    reference = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    dateorder = table.Column<DateTime>(name: "date_order", type: "timestamp with time zone", nullable: true),
                    datedelivery = table.Column<DateTime>(name: "date_delivery", type: "timestamp with time zone", nullable: true),
                    supplierid = table.Column<int>(name: "supplier_id", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_supplier_order", x => x.id);
                    table.ForeignKey(
                        name: "fk_supplier_order_suppliers_supplier_id",
                        column: x => x.supplierid,
                        principalTable: "Supplier",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "BottleGrape",
                columns: table => new
                {
                    grapeid = table.Column<int>(name: "grape_id", type: "integer", nullable: false),
                    bottleid = table.Column<int>(name: "bottle_id", type: "integer", nullable: false),
                    grapepercentage = table.Column<decimal>(name: "grape_percentage", type: "numeric", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValueSql: "NOW()"),
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
                name: "BottleStorageLocation",
                columns: table => new
                {
                    storagelocationid = table.Column<int>(name: "storage_location_id", type: "integer", nullable: false),
                    bottleid = table.Column<int>(name: "bottle_id", type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValueSql: "NOW()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
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

            migrationBuilder.CreateTable(
                name: "BottleSupplier",
                columns: table => new
                {
                    bottleid = table.Column<int>(name: "bottle_id", type: "integer", nullable: false),
                    supplierid = table.Column<int>(name: "supplier_id", type: "integer", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValueSql: "NOW()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bottle_supplier", x => new { x.bottleid, x.supplierid });
                    table.ForeignKey(
                        name: "fk_bottle_supplier_bottle_bottle_id",
                        column: x => x.bottleid,
                        principalTable: "Bottle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_bottle_supplier_suppliers_supplier_id",
                        column: x => x.supplierid,
                        principalTable: "Supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrderLine",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantity = table.Column<int>(type: "integer", nullable: true),
                    bottleid = table.Column<int>(name: "bottle_id", type: "integer", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValueSql: "NOW()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    customerorderid = table.Column<int>(name: "customer_order_id", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customer_order_line", x => x.id);
                    table.ForeignKey(
                        name: "fk_customer_order_line_bottle_bottle_id",
                        column: x => x.bottleid,
                        principalTable: "Bottle",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_customer_order_line_customer_order_customer_order_id",
                        column: x => x.customerorderid,
                        principalTable: "CustomerOrder",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "SupplierOrderLine",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantity = table.Column<int>(type: "integer", nullable: true),
                    bottleid = table.Column<int>(name: "bottle_id", type: "integer", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValueSql: "NOW()"),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    supplierorderid = table.Column<int>(name: "supplier_order_id", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_supplier_order_line", x => x.id);
                    table.ForeignKey(
                        name: "fk_supplier_order_line_bottle_bottle_id",
                        column: x => x.bottleid,
                        principalTable: "Bottle",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_supplier_order_line_supplier_order_supplier_order_id",
                        column: x => x.supplierorderid,
                        principalTable: "SupplierOrder",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrderLineStorageLocation",
                columns: table => new
                {
                    customerorderlineid = table.Column<int>(name: "customer_order_line_id", type: "integer", nullable: false),
                    storagelocationid = table.Column<int>(name: "storage_location_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customer_order_line_storage_location", x => new { x.customerorderlineid, x.storagelocationid });
                    table.ForeignKey(
                        name: "fk_customer_order_line_storage_location_customer_order_line_customer",
                        column: x => x.customerorderlineid,
                        principalTable: "CustomerOrderLine",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_customer_order_line_storage_location_storage_location_storage_lo",
                        column: x => x.storagelocationid,
                        principalTable: "StorageLocation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierOrderLineStorageLocation",
                columns: table => new
                {
                    supplierorderlineid = table.Column<int>(name: "supplier_order_line_id", type: "integer", nullable: false),
                    storagelocationid = table.Column<int>(name: "storage_location_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_supplier_order_line_storage_location", x => new { x.supplierorderlineid, x.storagelocationid });
                    table.ForeignKey(
                        name: "fk_supplier_order_line_storage_location_storage_location_storage_lo",
                        column: x => x.storagelocationid,
                        principalTable: "StorageLocation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_supplier_order_line_storage_location_supplier_order_line_supplier",
                        column: x => x.supplierorderlineid,
                        principalTable: "SupplierOrderLine",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_address_city_id",
                table: "Address",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "ix_address_user_id",
                table: "Address",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_bottle_producer_id",
                table: "Bottle",
                column: "producer_id");

            migrationBuilder.CreateIndex(
                name: "ix_bottle_vat_id",
                table: "Bottle",
                column: "vat_id");

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
                name: "ix_bottle_supplier_supplier_id",
                table: "BottleSupplier",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "ix_city_country_id",
                table: "City",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "ix_customer_order_customer_id",
                table: "CustomerOrder",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ix_customer_order_delivery_address_id",
                table: "CustomerOrder",
                column: "delivery_address_id");

            migrationBuilder.CreateIndex(
                name: "ix_customer_order_line_bottle_id",
                table: "CustomerOrderLine",
                column: "bottle_id");

            migrationBuilder.CreateIndex(
                name: "ix_customer_order_line_customer_order_id",
                table: "CustomerOrderLine",
                column: "customer_order_id");

            migrationBuilder.CreateIndex(
                name: "ix_customer_order_line_storage_location_storage_location_id",
                table: "CustomerOrderLineStorageLocation",
                column: "storage_location_id");

            migrationBuilder.CreateIndex(
                name: "ix_permission_role_role_id",
                table: "PermissionRole",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_producer_address_id",
                table: "Producer",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "ix_producer_region_id",
                table: "Producer",
                column: "region_id");

            migrationBuilder.CreateIndex(
                name: "ix_region_country_id",
                table: "Region",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "ix_supplier_order_supplier_id",
                table: "SupplierOrder",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "ix_supplier_order_line_bottle_id",
                table: "SupplierOrderLine",
                column: "bottle_id");

            migrationBuilder.CreateIndex(
                name: "ix_supplier_order_line_supplier_order_id",
                table: "SupplierOrderLine",
                column: "supplier_order_id");

            migrationBuilder.CreateIndex(
                name: "ix_supplier_order_line_storage_location_storage_location_id",
                table: "SupplierOrderLineStorageLocation",
                column: "storage_location_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_role_id",
                table: "User",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BottleGrape");

            migrationBuilder.DropTable(
                name: "BottleStorageLocation");

            migrationBuilder.DropTable(
                name: "BottleSupplier");

            migrationBuilder.DropTable(
                name: "CustomerOrderLineStorageLocation");

            migrationBuilder.DropTable(
                name: "PermissionRole");

            migrationBuilder.DropTable(
                name: "SupplierOrderLineStorageLocation");

            migrationBuilder.DropTable(
                name: "Grape");

            migrationBuilder.DropTable(
                name: "CustomerOrderLine");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "StorageLocation");

            migrationBuilder.DropTable(
                name: "SupplierOrderLine");

            migrationBuilder.DropTable(
                name: "CustomerOrder");

            migrationBuilder.DropTable(
                name: "Bottle");

            migrationBuilder.DropTable(
                name: "SupplierOrder");

            migrationBuilder.DropTable(
                name: "Producer");

            migrationBuilder.DropTable(
                name: "VAT");

            migrationBuilder.DropTable(
                name: "WineLabel");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
