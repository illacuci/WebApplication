using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdersAPI.Insfractucture.Migrations
{
    /// <inheritdoc />
    public partial class NombreDeLaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CentersCosts",
                columns: table => new
                {
                    LogisticCenter = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentersCosts", x => x.LogisticCenter);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRegion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Segments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSegment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameState = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Generics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategory = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UMA = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Generics_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTown = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Towns_States_IdState",
                        column: x => x.IdState,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BrandId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GenericId = table.Column<int>(type: "int", nullable: false),
                    Rounding = table.Column<double>(type: "float", nullable: false),
                    ConversionFactor = table.Column<double>(type: "float", nullable: false),
                    Active = table.Column<bool>(type: "bit", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Generics_GenericId",
                        column: x => x.GenericId,
                        principalTable: "Generics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    LogisticCenter = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdTown = table.Column<int>(type: "int", nullable: false),
                    IdRegion = table.Column<int>(type: "int", nullable: false),
                    IdSegment = table.Column<int>(type: "int", nullable: false),
                    IdCenterCost = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StreetNumber = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.LogisticCenter);
                    table.ForeignKey(
                        name: "FK_Sites_CentersCosts_IdCenterCost",
                        column: x => x.IdCenterCost,
                        principalTable: "CentersCosts",
                        principalColumn: "LogisticCenter",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sites_Regions_IdRegion",
                        column: x => x.IdRegion,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sites_Segments_IdSegment",
                        column: x => x.IdSegment,
                        principalTable: "Segments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sites_Towns_IdTown",
                        column: x => x.IdTown,
                        principalTable: "Towns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CUIT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IdTown = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Towns_IdTown",
                        column: x => x.IdTown,
                        principalTable: "Towns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Packaging",
                columns: table => new
                {
                    PresentacionId = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    IdItem = table.Column<string>(type: "nvarchar(7)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packaging", x => new { x.PresentacionId, x.IdItem });
                    table.ForeignKey(
                        name: "FK_Packaging_Items_IdItem",
                        column: x => x.IdItem,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocs",
                columns: table => new
                {
                    LogisticCenter = table.Column<string>(type: "nvarchar(4)", nullable: false),
                    IdProduct = table.Column<string>(type: "nvarchar(7)", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocs", x => new { x.LogisticCenter, x.IdProduct });
                    table.ForeignKey(
                        name: "FK_Stocs_Items_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocs_Sites_LogisticCenter",
                        column: x => x.LogisticCenter,
                        principalTable: "Sites",
                        principalColumn: "LogisticCenter",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    PurchaseOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogisticCenter = table.Column<string>(type: "nvarchar(4)", nullable: false),
                    SupplierId = table.Column<string>(type: "nvarchar(9)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovementType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.PurchaseOrder);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Sites_LogisticCenter",
                        column: x => x.LogisticCenter,
                        principalTable: "Sites",
                        principalColumn: "LogisticCenter",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrdersDetails",
                columns: table => new
                {
                    DetalleOCId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdItem = table.Column<string>(type: "nvarchar(2)", nullable: false),
                    IdPackaging = table.Column<string>(type: "nvarchar(7)", nullable: false),
                    IdPurchaseOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrdersDetails", x => x.DetalleOCId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrdersDetails_Packaging_IdItem_IdPackaging",
                        columns: x => new { x.IdItem, x.IdPackaging },
                        principalTable: "Packaging",
                        principalColumns: new[] { "PresentacionId", "IdItem" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrdersDetails_PurchaseOrders_IdPurchaseOrder",
                        column: x => x.IdPurchaseOrder,
                        principalTable: "PurchaseOrders",
                        principalColumn: "PurchaseOrder",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Generics_IdCategory",
                table: "Generics",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Items_BrandId",
                table: "Items",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_GenericId",
                table: "Items",
                column: "GenericId");

            migrationBuilder.CreateIndex(
                name: "IX_Packaging_IdItem",
                table: "Packaging",
                column: "IdItem");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_LogisticCenter",
                table: "PurchaseOrders",
                column: "LogisticCenter");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_SupplierId",
                table: "PurchaseOrders",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrdersDetails_IdItem_IdPackaging",
                table: "PurchaseOrdersDetails",
                columns: new[] { "IdItem", "IdPackaging" });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrdersDetails_IdPurchaseOrder",
                table: "PurchaseOrdersDetails",
                column: "IdPurchaseOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_IdCenterCost",
                table: "Sites",
                column: "IdCenterCost");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_IdRegion",
                table: "Sites",
                column: "IdRegion");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_IdSegment",
                table: "Sites",
                column: "IdSegment");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_IdTown",
                table: "Sites",
                column: "IdTown");

            migrationBuilder.CreateIndex(
                name: "IX_Stocs_IdProduct",
                table: "Stocs",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_IdTown",
                table: "Suppliers",
                column: "IdTown");

            migrationBuilder.CreateIndex(
                name: "IX_Towns_IdState",
                table: "Towns",
                column: "IdState");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseOrdersDetails");

            migrationBuilder.DropTable(
                name: "Stocs");

            migrationBuilder.DropTable(
                name: "Packaging");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Generics");

            migrationBuilder.DropTable(
                name: "CentersCosts");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Segments");

            migrationBuilder.DropTable(
                name: "Towns");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
