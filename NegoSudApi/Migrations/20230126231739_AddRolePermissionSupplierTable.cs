using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NegoSudApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRolePermissionSupplierTable : Migration
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 532, DateTimeKind.Utc).AddTicks(3907),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 532, DateTimeKind.Utc).AddTicks(3697),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 535, DateTimeKind.Utc).AddTicks(7359),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 535, DateTimeKind.Utc).AddTicks(6981),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 533, DateTimeKind.Utc).AddTicks(4478),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 533, DateTimeKind.Utc).AddTicks(4231),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 536, DateTimeKind.Utc).AddTicks(1220),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 536, DateTimeKind.Utc).AddTicks(1007),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 534, DateTimeKind.Utc).AddTicks(577),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 534, DateTimeKind.Utc).AddTicks(272),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 533, DateTimeKind.Utc).AddTicks(6967),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 533, DateTimeKind.Utc).AddTicks(6720),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 536, DateTimeKind.Utc).AddTicks(8900),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 536, DateTimeKind.Utc).AddTicks(8726),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 377, DateTimeKind.Utc).AddTicks(315));

            migrationBuilder.AlterColumn<string>(
                name: "access",
                table: "Permission",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Permission",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Grape",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 533, DateTimeKind.Utc).AddTicks(2257),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 533, DateTimeKind.Utc).AddTicks(2031),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 532, DateTimeKind.Utc).AddTicks(8965),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 532, DateTimeKind.Utc).AddTicks(8779),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 534, DateTimeKind.Utc).AddTicks(3890),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 534, DateTimeKind.Utc).AddTicks(3644),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 534, DateTimeKind.Utc).AddTicks(9809),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 534, DateTimeKind.Utc).AddTicks(9620),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 532, DateTimeKind.Utc).AddTicks(4668),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 532, DateTimeKind.Utc).AddTicks(4483),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 532, DateTimeKind.Utc).AddTicks(1383),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 532, DateTimeKind.Utc).AddTicks(1104),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 534, DateTimeKind.Utc).AddTicks(7426),
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
                defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 534, DateTimeKind.Utc).AddTicks(7201),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 1, 24, 14, 29, 55, 375, DateTimeKind.Utc).AddTicks(8061));

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    details = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 537, DateTimeKind.Utc).AddTicks(988)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 537, DateTimeKind.Utc).AddTicks(1247)),
                    createdby = table.Column<string>(name: "created_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    updatedby = table.Column<string>(name: "updated_by", type: "character varying(200)", maxLength: 200, nullable: true),
                    addressid = table.Column<int>(name: "address_id", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_supplier", x => x.id);
                    table.ForeignKey(
                        name: "fk_supplier_address_address_id",
                        column: x => x.addressid,
                        principalTable: "Address",
                        principalColumn: "id");
                });
            

            migrationBuilder.CreateTable(
                name: "BottleSupplier",
                columns: table => new
                {
                    bottleid = table.Column<int>(name: "bottle_id", type: "integer", nullable: false),
                    supplierid = table.Column<int>(name: "supplier_id", type: "integer", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 536, DateTimeKind.Utc).AddTicks(2923)),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 536, DateTimeKind.Utc).AddTicks(3155)),
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

            migrationBuilder.CreateIndex(
                name: "ix_user_role_id",
                table: "User",
                column: "role_id");

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
                name: "ix_bottle_supplier_supplier_id",
                table: "BottleSupplier",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "ix_supplier_address_id",
                table: "Supplier",
                column: "address_id");

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

            migrationBuilder.AddForeignKey(
                name: "fk_user_roles_role_id",
                table: "User",
                column: "role_id",
                principalTable: "Role",
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

            migrationBuilder.DropForeignKey(
                name: "fk_user_roles_role_id",
                table: "User");

            migrationBuilder.DropTable(
                name: "BottleSupplier");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropIndex(
                name: "ix_user_role_id",
                table: "User");

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

            migrationBuilder.DropColumn(
                name: "name",
                table: "Permission");

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 532, DateTimeKind.Utc).AddTicks(3907));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 532, DateTimeKind.Utc).AddTicks(3697));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 535, DateTimeKind.Utc).AddTicks(7359));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 535, DateTimeKind.Utc).AddTicks(6981));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 533, DateTimeKind.Utc).AddTicks(4478));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 533, DateTimeKind.Utc).AddTicks(4231));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 536, DateTimeKind.Utc).AddTicks(1220));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 536, DateTimeKind.Utc).AddTicks(1007));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 534, DateTimeKind.Utc).AddTicks(577));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 534, DateTimeKind.Utc).AddTicks(272));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 533, DateTimeKind.Utc).AddTicks(6967));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 533, DateTimeKind.Utc).AddTicks(6720));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 536, DateTimeKind.Utc).AddTicks(8900));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 536, DateTimeKind.Utc).AddTicks(8726));

            migrationBuilder.AlterColumn<string>(
                name: "access",
                table: "Permission",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 533, DateTimeKind.Utc).AddTicks(2257));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 533, DateTimeKind.Utc).AddTicks(2031));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 532, DateTimeKind.Utc).AddTicks(8965));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 532, DateTimeKind.Utc).AddTicks(8779));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 534, DateTimeKind.Utc).AddTicks(3890));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 534, DateTimeKind.Utc).AddTicks(3644));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 534, DateTimeKind.Utc).AddTicks(9809));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 534, DateTimeKind.Utc).AddTicks(9620));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 532, DateTimeKind.Utc).AddTicks(4668));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 532, DateTimeKind.Utc).AddTicks(4483));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 532, DateTimeKind.Utc).AddTicks(1383));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 532, DateTimeKind.Utc).AddTicks(1104));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 534, DateTimeKind.Utc).AddTicks(7426));

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
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 17, 39, 534, DateTimeKind.Utc).AddTicks(7201));
        }
    }
}
