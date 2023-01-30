using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NegoSudApi.Migrations
{
    /// <inheritdoc />
    public partial class AddOrdersTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "WineLabel",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 52, DateTimeKind.Utc).AddTicks(6983),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 373, DateTimeKind.Utc).AddTicks(5810));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "WineLabel",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 52, DateTimeKind.Utc).AddTicks(6759),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 373, DateTimeKind.Utc).AddTicks(5638));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "User",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 58, DateTimeKind.Utc).AddTicks(143),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 376, DateTimeKind.Utc).AddTicks(6176));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "User",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 57, DateTimeKind.Utc).AddTicks(9896),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 376, DateTimeKind.Utc).AddTicks(5985));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "StorageLocation",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 54, DateTimeKind.Utc).AddTicks(1695),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(6210));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "StorageLocation",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 54, DateTimeKind.Utc).AddTicks(1403),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(5949));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Role",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 58, DateTimeKind.Utc).AddTicks(4861),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 376, DateTimeKind.Utc).AddTicks(8354));

            migrationBuilder.AlterColumn<int>(
                name: "permission_id",
                table: "Role",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Role",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Role",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 58, DateTimeKind.Utc).AddTicks(3791),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 376, DateTimeKind.Utc).AddTicks(8156));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Region",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 54, DateTimeKind.Utc).AddTicks(9841),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 375, DateTimeKind.Utc).AddTicks(1989));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Region",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 54, DateTimeKind.Utc).AddTicks(9556),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 375, DateTimeKind.Utc).AddTicks(1758));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Producer",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 54, DateTimeKind.Utc).AddTicks(5130),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(8473));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Producer",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 54, DateTimeKind.Utc).AddTicks(4841),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(8227));

            migrationBuilder.AddColumn<int>(
                name: "address_id",
                table: "Producer",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Permission",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 58, DateTimeKind.Utc).AddTicks(8500),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 377, DateTimeKind.Utc).AddTicks(483));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Permission",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 58, DateTimeKind.Utc).AddTicks(8276),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 377, DateTimeKind.Utc).AddTicks(315));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Grape",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 53, DateTimeKind.Utc).AddTicks(8462),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(3997));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Grape",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 53, DateTimeKind.Utc).AddTicks(8212),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(3811));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Country",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 53, DateTimeKind.Utc).AddTicks(4061),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(963));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Country",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 53, DateTimeKind.Utc).AddTicks(3800),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(650));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "City",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 55, DateTimeKind.Utc).AddTicks(4371),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 375, DateTimeKind.Utc).AddTicks(5105));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "City",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 55, DateTimeKind.Utc).AddTicks(4116),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 375, DateTimeKind.Utc).AddTicks(4869));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "BottleStorageLocation",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 56, DateTimeKind.Utc).AddTicks(2551),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 376, DateTimeKind.Utc).AddTicks(594));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "BottleStorageLocation",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 56, DateTimeKind.Utc).AddTicks(2266),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 376, DateTimeKind.Utc).AddTicks(376));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "BottleGrape",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 52, DateTimeKind.Utc).AddTicks(7999),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 373, DateTimeKind.Utc).AddTicks(6635));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "BottleGrape",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 52, DateTimeKind.Utc).AddTicks(7721),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 373, DateTimeKind.Utc).AddTicks(6405));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Bottle",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 52, DateTimeKind.Utc).AddTicks(3394),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 373, DateTimeKind.Utc).AddTicks(3336));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Bottle",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 52, DateTimeKind.Utc).AddTicks(3052),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 373, DateTimeKind.Utc).AddTicks(3085));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Address",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 55, DateTimeKind.Utc).AddTicks(9219),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 375, DateTimeKind.Utc).AddTicks(8313));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Address",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 55, DateTimeKind.Utc).AddTicks(8792),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 375, DateTimeKind.Utc).AddTicks(8061));

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullname = table.Column<string>(name: "full_name", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SupplierOrder",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 57, DateTimeKind.Utc).AddTicks(3025)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 57, DateTimeKind.Utc).AddTicks(3307)),
                    cancelledat = table.Column<DateTime>(name: "cancelled_at", type: "timestamp with time zone", nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    cancelledby = table.Column<string>(name: "cancelled_by", type: "text", nullable: true),
                    reference = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    dateorder = table.Column<DateTime>(name: "date_order", type: "timestamp with time zone", nullable: true),
                    datedelivery = table.Column<DateTime>(name: "date_delivery", type: "timestamp with time zone", nullable: true),
                    producerid = table.Column<int>(name: "producer_id", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_supplier_order", x => x.id);
                    table.ForeignKey(
                        name: "fk_supplier_order_producer_producer_id",
                        column: x => x.producerid,
                        principalTable: "Producer",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrder",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 56, DateTimeKind.Utc).AddTicks(8250)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 56, DateTimeKind.Utc).AddTicks(8544)),
                    cancelledat = table.Column<DateTime>(name: "cancelled_at", type: "timestamp with time zone", nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    cancelledby = table.Column<string>(name: "cancelled_by", type: "text", nullable: true),
                    reference = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    dateorder = table.Column<DateTime>(name: "date_order", type: "timestamp with time zone", nullable: true),
                    datedelivery = table.Column<DateTime>(name: "date_delivery", type: "timestamp with time zone", nullable: true),
                    customerid = table.Column<int>(name: "customer_id", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customer_order", x => x.id);
                    table.ForeignKey(
                        name: "fk_customer_order_customer_customer_id",
                        column: x => x.customerid,
                        principalTable: "customer",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "SupplierOrderLine",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 57, DateTimeKind.Utc).AddTicks(5954)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 57, DateTimeKind.Utc).AddTicks(6288)),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    quantity = table.Column<decimal>(type: "numeric", nullable: true),
                    bottleid = table.Column<int>(name: "bottle_id", type: "integer", nullable: true),
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
                name: "CustomerOrderLine",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 57, DateTimeKind.Utc).AddTicks(1192)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 57, DateTimeKind.Utc).AddTicks(1571)),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    quantity = table.Column<decimal>(type: "numeric", nullable: true),
                    bottleid = table.Column<int>(name: "bottle_id", type: "integer", nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "ix_role_permission_id",
                table: "Role",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "ix_producer_address_id",
                table: "Producer",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "ix_address_user_id",
                table: "Address",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_customer_order_customer_id",
                table: "CustomerOrder",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ix_customer_order_line_bottle_id",
                table: "CustomerOrderLine",
                column: "bottle_id");

            migrationBuilder.CreateIndex(
                name: "ix_customer_order_line_customer_order_id",
                table: "CustomerOrderLine",
                column: "customer_order_id");

            migrationBuilder.CreateIndex(
                name: "ix_supplier_order_producer_id",
                table: "SupplierOrder",
                column: "producer_id");

            migrationBuilder.CreateIndex(
                name: "ix_supplier_order_line_bottle_id",
                table: "SupplierOrderLine",
                column: "bottle_id");

            migrationBuilder.CreateIndex(
                name: "ix_supplier_order_line_supplier_order_id",
                table: "SupplierOrderLine",
                column: "supplier_order_id");

            migrationBuilder.AddForeignKey(
                name: "fk_address_users_user_id",
                table: "Address",
                column: "user_id",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_producer_addresses_address_id",
                table: "Producer",
                column: "address_id",
                principalTable: "Address",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_role_permissions_permission_id",
                table: "Role",
                column: "permission_id",
                principalTable: "Permission",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_address_users_user_id",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "fk_producer_addresses_address_id",
                table: "Producer");

            migrationBuilder.DropForeignKey(
                name: "fk_role_permissions_permission_id",
                table: "Role");

            migrationBuilder.DropTable(
                name: "CustomerOrderLine");

            migrationBuilder.DropTable(
                name: "SupplierOrderLine");

            migrationBuilder.DropTable(
                name: "CustomerOrder");

            migrationBuilder.DropTable(
                name: "SupplierOrder");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropIndex(
                name: "ix_role_permission_id",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "ix_producer_address_id",
                table: "Producer");

            migrationBuilder.DropIndex(
                name: "ix_address_user_id",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "address_id",
                table: "Producer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "WineLabel",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 373, DateTimeKind.Utc).AddTicks(5810),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 52, DateTimeKind.Utc).AddTicks(6983));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "WineLabel",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 373, DateTimeKind.Utc).AddTicks(5638),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 52, DateTimeKind.Utc).AddTicks(6759));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "User",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 376, DateTimeKind.Utc).AddTicks(6176),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 58, DateTimeKind.Utc).AddTicks(143));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "User",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 376, DateTimeKind.Utc).AddTicks(5985),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 57, DateTimeKind.Utc).AddTicks(9896));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "StorageLocation",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(6210),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 54, DateTimeKind.Utc).AddTicks(1695));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "StorageLocation",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(5949),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 54, DateTimeKind.Utc).AddTicks(1403));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Role",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 376, DateTimeKind.Utc).AddTicks(8354),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 58, DateTimeKind.Utc).AddTicks(4861));

            migrationBuilder.AlterColumn<int>(
                name: "permission_id",
                table: "Role",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Role",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Role",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 376, DateTimeKind.Utc).AddTicks(8156),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 58, DateTimeKind.Utc).AddTicks(3791));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Region",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 375, DateTimeKind.Utc).AddTicks(1989),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 54, DateTimeKind.Utc).AddTicks(9841));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Region",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 375, DateTimeKind.Utc).AddTicks(1758),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 54, DateTimeKind.Utc).AddTicks(9556));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Producer",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(8473),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 54, DateTimeKind.Utc).AddTicks(5130));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Producer",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(8227),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 54, DateTimeKind.Utc).AddTicks(4841));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Permission",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 377, DateTimeKind.Utc).AddTicks(483),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 58, DateTimeKind.Utc).AddTicks(8500));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Permission",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 377, DateTimeKind.Utc).AddTicks(315),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 58, DateTimeKind.Utc).AddTicks(8276));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Grape",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(3997),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 53, DateTimeKind.Utc).AddTicks(8462));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Grape",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(3811),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 53, DateTimeKind.Utc).AddTicks(8212));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Country",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(963),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 53, DateTimeKind.Utc).AddTicks(4061));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Country",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 374, DateTimeKind.Utc).AddTicks(650),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 53, DateTimeKind.Utc).AddTicks(3800));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "City",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 375, DateTimeKind.Utc).AddTicks(5105),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 55, DateTimeKind.Utc).AddTicks(4371));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "City",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 375, DateTimeKind.Utc).AddTicks(4869),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 55, DateTimeKind.Utc).AddTicks(4116));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "BottleStorageLocation",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 376, DateTimeKind.Utc).AddTicks(594),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 56, DateTimeKind.Utc).AddTicks(2551));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "BottleStorageLocation",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 376, DateTimeKind.Utc).AddTicks(376),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 56, DateTimeKind.Utc).AddTicks(2266));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "BottleGrape",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 373, DateTimeKind.Utc).AddTicks(6635),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 52, DateTimeKind.Utc).AddTicks(7999));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "BottleGrape",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 373, DateTimeKind.Utc).AddTicks(6405),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 52, DateTimeKind.Utc).AddTicks(7721));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Bottle",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 373, DateTimeKind.Utc).AddTicks(3336),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 52, DateTimeKind.Utc).AddTicks(3394));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Bottle",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 373, DateTimeKind.Utc).AddTicks(3085),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 52, DateTimeKind.Utc).AddTicks(3052));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Address",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 375, DateTimeKind.Utc).AddTicks(8313),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 55, DateTimeKind.Utc).AddTicks(9219));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Address",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 375, DateTimeKind.Utc).AddTicks(8061),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 10, 40, 1, 55, DateTimeKind.Utc).AddTicks(8792));
        }
    }
}
