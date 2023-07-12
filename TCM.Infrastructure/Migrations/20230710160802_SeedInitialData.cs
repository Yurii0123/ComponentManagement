using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TCM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainComponentRelations");

            migrationBuilder.CreateTable(
                name: "TrainComponentTrainComponent",
                columns: table => new
                {
                    ChildrenId = table.Column<int>(type: "int", nullable: false),
                    ParentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainComponentTrainComponent", x => new { x.ChildrenId, x.ParentsId });
                    table.ForeignKey(
                        name: "FK_TrainComponentTrainComponent_TrainComponents_ChildrenId",
                        column: x => x.ChildrenId,
                        principalTable: "TrainComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainComponentTrainComponent_TrainComponents_ParentsId",
                        column: x => x.ParentsId,
                        principalTable: "TrainComponents",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "TrainComponents",
                columns: new[] { "Id", "CanAssignQuantity", "Name", "UniqueNumber" },
                values: new object[,]
                {
                    { 1, false, "Engine", "ENG123" },
                    { 2, false, "Passenger Car", "PAS456" },
                    { 3, false, "Freight Car", "FRT789" },
                    { 4, true, "Wheel", "WHL101" },
                    { 5, true, "Seat", "STS234" },
                    { 6, true, "Window", "WIN567" },
                    { 7, true, "Door", "DR123" },
                    { 8, true, "Control Panel", "CTL987" },
                    { 9, true, "Light", "LGT456" },
                    { 10, true, "Brake", "BRK789" },
                    { 11, true, "Bolt", "BLT321" },
                    { 12, true, "Nut", "NUT654" },
                    { 13, false, "Engine Hood", "EH789" },
                    { 14, false, "Axle", "AX456" },
                    { 15, false, "Piston", "PST789" },
                    { 16, true, "Handrail", "HND234" },
                    { 17, true, "Step", "STP567" },
                    { 18, false, "Roof", "RF123" },
                    { 19, false, "Air Conditioner", "AC789" },
                    { 20, false, "Flooring", "FLR456" },
                    { 21, true, "Mirror", "MRR789" },
                    { 22, false, "Horn", "HRN321" },
                    { 23, false, "Coupler", "CPL654" },
                    { 24, true, "Hinge", "HNG987" },
                    { 25, true, "Ladder", "LDR456" },
                    { 26, false, "Paint", "PNT789" },
                    { 27, true, "Decal", "DCL321" },
                    { 28, true, "Gauge", "GGS654" },
                    { 29, false, "Battery", "BTR987" },
                    { 30, false, "Radiator", "RDR456" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainComponentTrainComponent_ParentsId",
                table: "TrainComponentTrainComponent",
                column: "ParentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainComponentTrainComponent");

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TrainComponents",
                keyColumn: "Id",
                keyValue: 30);

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
    }
}
