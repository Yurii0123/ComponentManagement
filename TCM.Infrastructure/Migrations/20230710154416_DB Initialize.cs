using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DBInitialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniqueNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanAssignQuantity = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int",nullable: false,defaultValue: 0),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainComponents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainComponentRelations",
                columns: table => new
                {
                    ChildrenId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainComponentRelations", x => new { x.ChildrenId, x.ParentId });
                    table.ForeignKey(
                        name: "FK_TrainComponentRelations_TrainComponents_ChildrenId",
                        column: x => x.ChildrenId,
                        principalTable: "TrainComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainComponentRelations_TrainComponents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TrainComponents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainComponentRelations_ParentId",
                table: "TrainComponentRelations",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainComponentRelations");

            migrationBuilder.DropTable(
                name: "TrainComponents");
        }
    }
}
