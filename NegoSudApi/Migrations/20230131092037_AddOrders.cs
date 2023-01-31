using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NegoSudApi.Migrations
{
    /// <inheritdoc />
    public partial class AddOrders : Migration
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
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 984, DateTimeKind.Utc).AddTicks(1591),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 785, DateTimeKind.Utc).AddTicks(1396));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "WineLabel",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 984, DateTimeKind.Utc).AddTicks(992),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 785, DateTimeKind.Utc).AddTicks(1222));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "User",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 995, DateTimeKind.Utc).AddTicks(1593),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 788, DateTimeKind.Utc).AddTicks(6805));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "User",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 995, DateTimeKind.Utc).AddTicks(893),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 788, DateTimeKind.Utc).AddTicks(6559));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Supplier",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 997, DateTimeKind.Utc).AddTicks(624),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 789, DateTimeKind.Utc).AddTicks(4328));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Supplier",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 996, DateTimeKind.Utc).AddTicks(9893),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 789, DateTimeKind.Utc).AddTicks(4114));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "StorageLocation",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 986, DateTimeKind.Utc).AddTicks(5895),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 786, DateTimeKind.Utc).AddTicks(1700));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "StorageLocation",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 986, DateTimeKind.Utc).AddTicks(5377),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 786, DateTimeKind.Utc).AddTicks(1524));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Role",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 995, DateTimeKind.Utc).AddTicks(9633),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 789, DateTimeKind.Utc).AddTicks(13));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Role",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 995, DateTimeKind.Utc).AddTicks(9015),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 788, DateTimeKind.Utc).AddTicks(9830));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Region",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 988, DateTimeKind.Utc).AddTicks(9066),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 787, DateTimeKind.Utc).AddTicks(1963));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Region",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 988, DateTimeKind.Utc).AddTicks(8415),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 787, DateTimeKind.Utc).AddTicks(1702));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Producer",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 988, DateTimeKind.Utc).AddTicks(1596),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 786, DateTimeKind.Utc).AddTicks(8280));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Producer",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 988, DateTimeKind.Utc).AddTicks(910),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 786, DateTimeKind.Utc).AddTicks(8044));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Permission",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 996, DateTimeKind.Utc).AddTicks(7249),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 789, DateTimeKind.Utc).AddTicks(3283));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Permission",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 996, DateTimeKind.Utc).AddTicks(6620),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 789, DateTimeKind.Utc).AddTicks(3096));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Grape",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 986, DateTimeKind.Utc).AddTicks(1881),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 785, DateTimeKind.Utc).AddTicks(9515));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Grape",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 986, DateTimeKind.Utc).AddTicks(1281),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 785, DateTimeKind.Utc).AddTicks(9319));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Country",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 985, DateTimeKind.Utc).AddTicks(5472),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 785, DateTimeKind.Utc).AddTicks(6401));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Country",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 985, DateTimeKind.Utc).AddTicks(4937),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 785, DateTimeKind.Utc).AddTicks(6167));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "City",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 989, DateTimeKind.Utc).AddTicks(5888),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 787, DateTimeKind.Utc).AddTicks(5205));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "City",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 989, DateTimeKind.Utc).AddTicks(5330),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 787, DateTimeKind.Utc).AddTicks(5010));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "BottleSupplier",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 987, DateTimeKind.Utc).AddTicks(152),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 786, DateTimeKind.Utc).AddTicks(3968));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "BottleSupplier",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 986, DateTimeKind.Utc).AddTicks(9671),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 786, DateTimeKind.Utc).AddTicks(3748));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "BottleStorageLocation",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 991, DateTimeKind.Utc).AddTicks(879),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 788, DateTimeKind.Utc).AddTicks(1065));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "BottleStorageLocation",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 991, DateTimeKind.Utc).AddTicks(206),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 788, DateTimeKind.Utc).AddTicks(876));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "BottleGrape",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 984, DateTimeKind.Utc).AddTicks(3827),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 785, DateTimeKind.Utc).AddTicks(2167));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "BottleGrape",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 984, DateTimeKind.Utc).AddTicks(3362),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 785, DateTimeKind.Utc).AddTicks(1948));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Bottle",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 983, DateTimeKind.Utc).AddTicks(6355),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 784, DateTimeKind.Utc).AddTicks(8855));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Bottle",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 983, DateTimeKind.Utc).AddTicks(5591),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 784, DateTimeKind.Utc).AddTicks(8609));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Address",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 990, DateTimeKind.Utc).AddTicks(4319),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 787, DateTimeKind.Utc).AddTicks(8691));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Address",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 990, DateTimeKind.Utc).AddTicks(3635),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 787, DateTimeKind.Utc).AddTicks(8453));

            migrationBuilder.CreateTable(
                name: "CustomerOrder",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 992, DateTimeKind.Utc).AddTicks(5434)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 992, DateTimeKind.Utc).AddTicks(6331)),
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
                        name: "fk_customer_order_users_customer_id",
                        column: x => x.customerid,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "SupplierOrder",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 993, DateTimeKind.Utc).AddTicks(6919)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 993, DateTimeKind.Utc).AddTicks(7690)),
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
                name: "CustomerOrderLine",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 993, DateTimeKind.Utc).AddTicks(2570)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 993, DateTimeKind.Utc).AddTicks(3285)),
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

            migrationBuilder.CreateTable(
                name: "SupplierOrderLine",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 994, DateTimeKind.Utc).AddTicks(3547)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 994, DateTimeKind.Utc).AddTicks(4294)),
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOrderLine");

            migrationBuilder.DropTable(
                name: "SupplierOrderLine");

            migrationBuilder.DropTable(
                name: "CustomerOrder");

            migrationBuilder.DropTable(
                name: "SupplierOrder");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "WineLabel",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 785, DateTimeKind.Utc).AddTicks(1396),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 984, DateTimeKind.Utc).AddTicks(1591));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "WineLabel",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 785, DateTimeKind.Utc).AddTicks(1222),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 984, DateTimeKind.Utc).AddTicks(992));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "User",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 788, DateTimeKind.Utc).AddTicks(6805),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 995, DateTimeKind.Utc).AddTicks(1593));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "User",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 788, DateTimeKind.Utc).AddTicks(6559),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 995, DateTimeKind.Utc).AddTicks(893));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Supplier",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 789, DateTimeKind.Utc).AddTicks(4328),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 997, DateTimeKind.Utc).AddTicks(624));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Supplier",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 789, DateTimeKind.Utc).AddTicks(4114),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 996, DateTimeKind.Utc).AddTicks(9893));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "StorageLocation",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 786, DateTimeKind.Utc).AddTicks(1700),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 986, DateTimeKind.Utc).AddTicks(5895));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "StorageLocation",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 786, DateTimeKind.Utc).AddTicks(1524),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 986, DateTimeKind.Utc).AddTicks(5377));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Role",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 789, DateTimeKind.Utc).AddTicks(13),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 995, DateTimeKind.Utc).AddTicks(9633));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Role",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 788, DateTimeKind.Utc).AddTicks(9830),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 995, DateTimeKind.Utc).AddTicks(9015));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Region",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 787, DateTimeKind.Utc).AddTicks(1963),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 988, DateTimeKind.Utc).AddTicks(9066));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Region",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 787, DateTimeKind.Utc).AddTicks(1702),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 988, DateTimeKind.Utc).AddTicks(8415));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Producer",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 786, DateTimeKind.Utc).AddTicks(8280),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 988, DateTimeKind.Utc).AddTicks(1596));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Producer",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 786, DateTimeKind.Utc).AddTicks(8044),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 988, DateTimeKind.Utc).AddTicks(910));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Permission",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 789, DateTimeKind.Utc).AddTicks(3283),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 996, DateTimeKind.Utc).AddTicks(7249));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Permission",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 789, DateTimeKind.Utc).AddTicks(3096),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 996, DateTimeKind.Utc).AddTicks(6620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Grape",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 785, DateTimeKind.Utc).AddTicks(9515),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 986, DateTimeKind.Utc).AddTicks(1881));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Grape",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 785, DateTimeKind.Utc).AddTicks(9319),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 986, DateTimeKind.Utc).AddTicks(1281));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Country",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 785, DateTimeKind.Utc).AddTicks(6401),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 985, DateTimeKind.Utc).AddTicks(5472));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Country",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 785, DateTimeKind.Utc).AddTicks(6167),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 985, DateTimeKind.Utc).AddTicks(4937));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "City",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 787, DateTimeKind.Utc).AddTicks(5205),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 989, DateTimeKind.Utc).AddTicks(5888));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "City",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 787, DateTimeKind.Utc).AddTicks(5010),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 989, DateTimeKind.Utc).AddTicks(5330));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "BottleSupplier",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 786, DateTimeKind.Utc).AddTicks(3968),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 987, DateTimeKind.Utc).AddTicks(152));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "BottleSupplier",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 786, DateTimeKind.Utc).AddTicks(3748),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 986, DateTimeKind.Utc).AddTicks(9671));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "BottleStorageLocation",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 788, DateTimeKind.Utc).AddTicks(1065),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 991, DateTimeKind.Utc).AddTicks(879));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "BottleStorageLocation",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 788, DateTimeKind.Utc).AddTicks(876),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 991, DateTimeKind.Utc).AddTicks(206));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "BottleGrape",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 785, DateTimeKind.Utc).AddTicks(2167),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 984, DateTimeKind.Utc).AddTicks(3827));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "BottleGrape",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 785, DateTimeKind.Utc).AddTicks(1948),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 984, DateTimeKind.Utc).AddTicks(3362));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Bottle",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 784, DateTimeKind.Utc).AddTicks(8855),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 983, DateTimeKind.Utc).AddTicks(6355));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Bottle",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 784, DateTimeKind.Utc).AddTicks(8609),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 983, DateTimeKind.Utc).AddTicks(5591));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Address",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 787, DateTimeKind.Utc).AddTicks(8691),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 990, DateTimeKind.Utc).AddTicks(4319));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Address",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 30, 9, 54, 21, 787, DateTimeKind.Utc).AddTicks(8453),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 990, DateTimeKind.Utc).AddTicks(3635));
        }
    }
}
