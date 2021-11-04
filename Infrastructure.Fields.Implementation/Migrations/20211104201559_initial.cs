using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Fields.Implementation.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeField",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeField", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Validation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValidationEnum = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Validation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Field",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Field_TypeField_TypeFieldId",
                        column: x => x.TypeFieldId,
                        principalTable: "TypeField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ValidationInField",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValidationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidationInField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValidationInField_TypeField_TypeFieldId",
                        column: x => x.TypeFieldId,
                        principalTable: "TypeField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ValidationInField_Validation_ValidationId",
                        column: x => x.ValidationId,
                        principalTable: "Validation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Validation",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "Description", "IsDelete", "ValidationEnum", "Value" },
                values: new object[] { new Guid("8389d2d7-988c-457c-8959-3a1c53d304d9"), new DateTime(2021, 11, 4, 15, 15, 59, 462, DateTimeKind.Local).AddTicks(3734), null, "prueba", false, 0, "OK" });

            migrationBuilder.CreateIndex(
                name: "IX_Field_Key",
                table: "Field",
                column: "Key",
                unique: true,
                filter: "[Key] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Field_TypeFieldId",
                table: "Field",
                column: "TypeFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeField_TypeName",
                table: "TypeField",
                column: "TypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ValidationInField_TypeFieldId",
                table: "ValidationInField",
                column: "TypeFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_ValidationInField_ValidationId",
                table: "ValidationInField",
                column: "ValidationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Field");

            migrationBuilder.DropTable(
                name: "ValidationInField");

            migrationBuilder.DropTable(
                name: "TypeField");

            migrationBuilder.DropTable(
                name: "Validation");
        }
    }
}
