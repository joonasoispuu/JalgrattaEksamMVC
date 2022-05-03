using Microsoft.EntityFrameworkCore.Migrations;

namespace JalgrattaEksamMVC.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "jalgrattaeksam",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eesnimi = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    perekonnanimi = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    teooriatulemus = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((-1))"),
                    slaalom = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((-1))"),
                    ringtee = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((-1))"),
                    tanav = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((-1))"),
                    luba = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((-1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jalgrattaeksam", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jalgrattaeksam");
        }
    }
}
