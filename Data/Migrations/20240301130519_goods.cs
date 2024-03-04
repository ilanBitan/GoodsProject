using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodsProject.Data.Migrations
{
    public partial class goods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BPType",
                columns: table => new
                {
                    TypeCode = table.Column<string>(maxLength: 1, nullable: false),
                    TypeName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BPType", x => x.TypeCode);
                });

            migrationBuilder.CreateTable(
                name: "BusinessPartner",
                columns: table => new
                {
                    BPCode = table.Column<string>(maxLength: 128, nullable: false),
                    BPName = table.Column<string>(maxLength: 254, nullable: false),
                    BPType = table.Column<string>(maxLength: 1, nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPartner", x => x.BPCode);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemCode = table.Column<string>(maxLength: 128, nullable: false),
                    ItemName = table.Column<string>(maxLength: 254, nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemCode);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BPCode = table.Column<string>(maxLength: 128, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderLine",
                columns: table => new
                {
                    LineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocID = table.Column<int>(nullable: false),
                    ItemCode = table.Column<string>(maxLength: 128, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(38,18)", nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderLine", x => x.LineID);
                });

            migrationBuilder.CreateTable(
                name: "SaleOrder",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BPCode = table.Column<string>(maxLength: 128, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrder", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SaleOrderLine",
                columns: table => new
                {
                    LineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocID = table.Column<int>(nullable: false),
                    ItemCode = table.Column<string>(maxLength: 128, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(38,18)", nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrderLine", x => x.LineID);
                });

            migrationBuilder.CreateTable(
                name: "SaleOrderLineComment",
                columns: table => new
                {
                    CommentLineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocID = table.Column<int>(nullable: false),
                    LineID = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrderLineComment", x => x.CommentLineID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(maxLength: 1024, nullable: false),
                    UserName = table.Column<string>(maxLength: 254, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BPType");

            migrationBuilder.DropTable(
                name: "BusinessPartner");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "PurchaseOrderLine");

            migrationBuilder.DropTable(
                name: "SaleOrder");

            migrationBuilder.DropTable(
                name: "SaleOrderLine");

            migrationBuilder.DropTable(
                name: "SaleOrderLineComment");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
