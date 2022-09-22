using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test5.Migrations
{
    public partial class orderno2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "OrdersSequence",
                startValue: 1000L);

            migrationBuilder.AlterColumn<int>(
                name: "OrderNo",
                table: "Orders",
                type: "int",
                nullable: true,
                defaultValueSql: "NEXT VALUE FOR OrdersSequence",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "OrdersSequence");

            migrationBuilder.AlterColumn<int>(
                name: "OrderNo",
                table: "Orders",
                type: "int",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "NEXT VALUE FOR OrdersSequence");
        }
    }
}
