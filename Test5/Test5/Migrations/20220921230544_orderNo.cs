using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test5.Migrations
{
    public partial class orderNo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrderNo",
                table: "Orders",
                type: "int",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrderNo",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValueSql: "NULL",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "NULL");
        }
    }
}
