using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sum = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HighHeels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Heels = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighHeels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HighHeels_Shoes_Id",
                        column: x => x.Id,
                        principalTable: "Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HikingBoots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Traction = table.Column<float>(type: "real", nullable: false),
                    AreWaterproof = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HikingBoots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HikingBoots_Shoes_Id",
                        column: x => x.Id,
                        principalTable: "Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderedShoes",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ShoeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedShoes", x => new { x.OrderId, x.ShoeId });
                    table.ForeignKey(
                        name: "FK_OrderedShoes_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderedShoes_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sandals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Strap = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AreOpenToe = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sandals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sandals_Shoes_Id",
                        column: x => x.Id,
                        principalTable: "Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sneackers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Closure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sneackers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sneackers_Shoes_Id",
                        column: x => x.Id,
                        principalTable: "Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SportShoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Cushioning = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    HaveArchSupport = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportShoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportShoes_Shoes_Id",
                        column: x => x.Id,
                        principalTable: "Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCarts",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ShoeCId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCarts", x => new { x.UserId, x.ShoeCId });
                    table.ForeignKey(
                        name: "FK_UserCarts_Shoes_ShoeCId",
                        column: x => x.ShoeCId,
                        principalTable: "Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCarts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavorites",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ShoeFId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorites", x => new { x.UserId, x.ShoeFId });
                    table.ForeignKey(
                        name: "FK_UserFavorites_Shoes_ShoeFId",
                        column: x => x.ShoeFId,
                        principalTable: "Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderedShoes_ShoeId",
                table: "OrderedShoes",
                column: "ShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCarts_ShoeCId",
                table: "UserCarts",
                column: "ShoeCId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_ShoeFId",
                table: "UserFavorites",
                column: "ShoeFId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HighHeels");

            migrationBuilder.DropTable(
                name: "HikingBoots");

            migrationBuilder.DropTable(
                name: "OrderedShoes");

            migrationBuilder.DropTable(
                name: "Sandals");

            migrationBuilder.DropTable(
                name: "Sneackers");

            migrationBuilder.DropTable(
                name: "SportShoes");

            migrationBuilder.DropTable(
                name: "UserCarts");

            migrationBuilder.DropTable(
                name: "UserFavorites");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Shoes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
