using Microsoft.EntityFrameworkCore.Migrations;

namespace AnuitexTraining.DataAccessLayer.Migrations
{
    public partial class dataseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "PrintingEditions");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "PrintingEditions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "Count",
                table: "OrderItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "PrintingEditions",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "PrintingEditions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "OrderItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
