using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PajoPhone.Migrations
{
public partial class UpdateColorFieldToEnum : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        // Add a new column for the enum values
        migrationBuilder.AddColumn<int>(
            name: "ColorTemp",
            table: "PhoneModels",
            nullable: false,
            defaultValue: 0);

        // Convert existing string values to enum values
        migrationBuilder.Sql(
            @"
            UPDATE ""PhoneModels""
            SET ""ColorTemp"" = 
            CASE ""Color""
                WHEN 'Black' THEN 0
                WHEN 'White' THEN 1
                WHEN 'Red' THEN 2
                WHEN 'Blue' THEN 3
                WHEN 'Green' THEN 4
                WHEN 'Yellow' THEN 5
                ELSE 0
            END
            ");

        // Drop the old string column
        migrationBuilder.DropColumn(
            name: "Color",
            table: "PhoneModels");

        // Rename the new enum column to "Color"
        migrationBuilder.RenameColumn(
            name: "ColorTemp",
            table: "PhoneModels",
            newName: "Color");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        // Add the old string column back
        migrationBuilder.AddColumn<string>(
            name: "ColorTemp",
            table: "PhoneModels",
            nullable: true);

        // Convert enum values back to strings
        migrationBuilder.Sql(
            @"
            UPDATE ""PhoneModels""
            SET ""ColorTemp"" = 
            CASE ""Color""
                WHEN 0 THEN 'Black'
                WHEN 1 THEN 'White'
                WHEN 2 THEN 'Red'
                WHEN 3 THEN 'Blue'
                WHEN 4 THEN 'Green'
                WHEN 5 THEN 'Yellow'
                ELSE 'Black'
            END
            ");

        // Drop the new enum column
        migrationBuilder.DropColumn(
            name: "Color",
            table: "PhoneModels");

        // Rename the string column back to "Color"
        migrationBuilder.RenameColumn(
            name: "ColorTemp",
            table: "PhoneModels",
            newName: "Color");
    }
}

}
