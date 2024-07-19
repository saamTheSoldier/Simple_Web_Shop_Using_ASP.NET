using Microsoft.EntityFrameworkCore.Migrations;

namespace PajoPhone.Migrations;

    public partial class RemoveImageDataNotNullConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the NOT NULL constraint
            migrationBuilder.AlterColumn<byte[]>(
                name: "ImageData",
                table: "PhoneModels",
                type: "bytea",
                nullable: true,  // Allow NULL values
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Re-add the NOT NULL constraint
            migrationBuilder.AlterColumn<byte[]>(
                name: "ImageData",
                table: "PhoneModels",
                type: "bytea",
                nullable: false,  // Disallow NULL values
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);
        }
    }
