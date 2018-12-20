using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PAdmins",
                columns: table => new
                {
                    SchoolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SchoolName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAdmins", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    FamilyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentName = table.Column<string>(nullable: false),
                    ChildFirstName = table.Column<string>(nullable: false),
                    ChildLastName = table.Column<string>(nullable: false),
                    RoomNo = table.Column<int>(nullable: false),
                    TeacherName = table.Column<string>(nullable: false),
                    SchoolName = table.Column<string>(nullable: true),
                    PAdminSchoolId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.FamilyId);
                    table.ForeignKey(
                        name: "FK_Parents_PAdmins_PAdminSchoolId",
                        column: x => x.PAdminSchoolId,
                        principalTable: "PAdmins",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    ItemName = table.Column<string>(nullable: true),
                    CardNo = table.Column<int>(nullable: false),
                    PaymentTypeName = table.Column<string>(nullable: true),
                    ChildFirstName = table.Column<string>(nullable: true),
                    ChildLasttName = table.Column<string>(nullable: true),
                    RoomNo = table.Column<int>(nullable: false),
                    TeacherName = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ParentFamilyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Parents_ParentFamilyId",
                        column: x => x.ParentFamilyId,
                        principalTable: "Parents",
                        principalColumn: "FamilyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Qty = table.Column<int>(nullable: false),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    ItemName = table.Column<string>(nullable: true),
                    CardNo = table.Column<int>(nullable: false),
                    PaymentTypeName = table.Column<string>(nullable: true),
                    ChildFirstName = table.Column<string>(nullable: true),
                    ChildLasttName = table.Column<string>(nullable: true),
                    RoomNo = table.Column<int>(nullable: false),
                    TeacherName = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ParentFamilyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Parents_ParentFamilyId",
                        column: x => x.ParentFamilyId,
                        principalTable: "Parents",
                        principalColumn: "FamilyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemName = table.Column<string>(nullable: false),
                    ItemDescription = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    LunchDate = table.Column<DateTime>(nullable: false),
                    SchoolId = table.Column<string>(nullable: true),
                    PAdminSchoolId = table.Column<int>(nullable: true),
                    InvoiceId = table.Column<int>(nullable: true),
                    OrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Menus_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menus_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menus_PAdmins_PAdminSchoolId",
                        column: x => x.PAdminSchoolId,
                        principalTable: "PAdmins",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ParentFamilyId",
                table: "Invoices",
                column: "ParentFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_InvoiceId",
                table: "Menus",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_OrderId",
                table: "Menus",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_PAdminSchoolId",
                table: "Menus",
                column: "PAdminSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ParentFamilyId",
                table: "Orders",
                column: "ParentFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_PAdminSchoolId",
                table: "Parents",
                column: "PAdminSchoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "PAdmins");
        }
    }
}
