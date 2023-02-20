using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NegoSudApi.Models;

#nullable disable

namespace NegoSudApi.Migrations
{
    /// <inheritdoc />
    public partial class timestamp : Migration
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 616, DateTimeKind.Utc).AddTicks(6793),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 616, DateTimeKind.Utc).AddTicks(6564),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 623, DateTimeKind.Utc).AddTicks(7151),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 623, DateTimeKind.Utc).AddTicks(6828),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 995, DateTimeKind.Utc).AddTicks(893));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "SupplierOrderLine",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 623, DateTimeKind.Utc).AddTicks(1241),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 994, DateTimeKind.Utc).AddTicks(4294));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "SupplierOrderLine",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 623, DateTimeKind.Utc).AddTicks(847),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 994, DateTimeKind.Utc).AddTicks(3547));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "SupplierOrder",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 622, DateTimeKind.Utc).AddTicks(6236),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 993, DateTimeKind.Utc).AddTicks(7690));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "SupplierOrder",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 622, DateTimeKind.Utc).AddTicks(5899),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 993, DateTimeKind.Utc).AddTicks(6919));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Supplier",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 624, DateTimeKind.Utc).AddTicks(7185),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 624, DateTimeKind.Utc).AddTicks(6857),
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
                defaultValueSql: "NOW()",
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 624, DateTimeKind.Utc).AddTicks(1487),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 624, DateTimeKind.Utc).AddTicks(1254),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 619, DateTimeKind.Utc).AddTicks(4868),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 619, DateTimeKind.Utc).AddTicks(4474),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 619, DateTimeKind.Utc).AddTicks(14),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 618, DateTimeKind.Utc).AddTicks(9704),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 624, DateTimeKind.Utc).AddTicks(5804),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 624, DateTimeKind.Utc).AddTicks(5566),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 617, DateTimeKind.Utc).AddTicks(8093),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 617, DateTimeKind.Utc).AddTicks(7840),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 986, DateTimeKind.Utc).AddTicks(1281));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "CustomerOrderLine",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 622, DateTimeKind.Utc).AddTicks(2400),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 993, DateTimeKind.Utc).AddTicks(3285));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "CustomerOrderLine",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 622, DateTimeKind.Utc).AddTicks(2096),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 993, DateTimeKind.Utc).AddTicks(2570));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "CustomerOrder",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 621, DateTimeKind.Utc).AddTicks(7159),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 992, DateTimeKind.Utc).AddTicks(6331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "CustomerOrder",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 621, DateTimeKind.Utc).AddTicks(6858),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 992, DateTimeKind.Utc).AddTicks(5434));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Country",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 617, DateTimeKind.Utc).AddTicks(3733),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 617, DateTimeKind.Utc).AddTicks(3412),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 619, DateTimeKind.Utc).AddTicks(9413),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 619, DateTimeKind.Utc).AddTicks(9105),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 618, DateTimeKind.Utc).AddTicks(4203),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 618, DateTimeKind.Utc).AddTicks(3952),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 621, DateTimeKind.Utc).AddTicks(97),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 620, DateTimeKind.Utc).AddTicks(9717),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 616, DateTimeKind.Utc).AddTicks(7915),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 616, DateTimeKind.Utc).AddTicks(7663),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 616, DateTimeKind.Utc).AddTicks(3263),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 616, DateTimeKind.Utc).AddTicks(2933),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 620, DateTimeKind.Utc).AddTicks(4092),
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
                defaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 620, DateTimeKind.Utc).AddTicks(3783),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 990, DateTimeKind.Utc).AddTicks(3635));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 616, DateTimeKind.Utc).AddTicks(6793));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 616, DateTimeKind.Utc).AddTicks(6564));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 623, DateTimeKind.Utc).AddTicks(7151));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 623, DateTimeKind.Utc).AddTicks(6828));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "SupplierOrderLine",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 994, DateTimeKind.Utc).AddTicks(4294),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 623, DateTimeKind.Utc).AddTicks(1241));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "SupplierOrderLine",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 994, DateTimeKind.Utc).AddTicks(3547),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 623, DateTimeKind.Utc).AddTicks(847));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "SupplierOrder",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 993, DateTimeKind.Utc).AddTicks(7690),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 622, DateTimeKind.Utc).AddTicks(6236));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "SupplierOrder",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 993, DateTimeKind.Utc).AddTicks(6919),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 622, DateTimeKind.Utc).AddTicks(5899));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 624, DateTimeKind.Utc).AddTicks(7185));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 624, DateTimeKind.Utc).AddTicks(6857));

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
                oldNullable: true);

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
                oldDefaultValueSql: "NOW()");

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 624, DateTimeKind.Utc).AddTicks(1487));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 624, DateTimeKind.Utc).AddTicks(1254));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 619, DateTimeKind.Utc).AddTicks(4868));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 619, DateTimeKind.Utc).AddTicks(4474));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 619, DateTimeKind.Utc).AddTicks(14));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 618, DateTimeKind.Utc).AddTicks(9704));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 624, DateTimeKind.Utc).AddTicks(5804));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 624, DateTimeKind.Utc).AddTicks(5566));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 617, DateTimeKind.Utc).AddTicks(8093));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 617, DateTimeKind.Utc).AddTicks(7840));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "CustomerOrderLine",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 993, DateTimeKind.Utc).AddTicks(3285),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 622, DateTimeKind.Utc).AddTicks(2400));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "CustomerOrderLine",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 993, DateTimeKind.Utc).AddTicks(2570),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 622, DateTimeKind.Utc).AddTicks(2096));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "CustomerOrder",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 992, DateTimeKind.Utc).AddTicks(6331),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 621, DateTimeKind.Utc).AddTicks(7159));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "CustomerOrder",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 31, 9, 20, 36, 992, DateTimeKind.Utc).AddTicks(5434),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 621, DateTimeKind.Utc).AddTicks(6858));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 617, DateTimeKind.Utc).AddTicks(3733));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 617, DateTimeKind.Utc).AddTicks(3412));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 619, DateTimeKind.Utc).AddTicks(9413));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 619, DateTimeKind.Utc).AddTicks(9105));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 618, DateTimeKind.Utc).AddTicks(4203));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 618, DateTimeKind.Utc).AddTicks(3952));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 621, DateTimeKind.Utc).AddTicks(97));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 620, DateTimeKind.Utc).AddTicks(9717));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 616, DateTimeKind.Utc).AddTicks(7915));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 616, DateTimeKind.Utc).AddTicks(7663));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 616, DateTimeKind.Utc).AddTicks(3263));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 616, DateTimeKind.Utc).AddTicks(2933));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 620, DateTimeKind.Utc).AddTicks(4092));

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
                oldDefaultValue: new DateTime(2023, 2, 2, 7, 54, 9, 620, DateTimeKind.Utc).AddTicks(3783));



        }
    }
}
