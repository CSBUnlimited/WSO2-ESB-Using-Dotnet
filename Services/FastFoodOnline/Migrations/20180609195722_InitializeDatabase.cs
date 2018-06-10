using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FastFoodOnline.Migrations
{
    public partial class InitializeDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<float>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(maxLength: 2, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(maxLength: 20, nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Gender = table.Column<byte>(nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Mobile = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false),
                    LoyaltyPoints = table.Column<float>(nullable: false, defaultValue: 0f),
                    RegisteredDate = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime('now','localtime')"),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: false),
                    PaymentMethodId = table.Column<int>(nullable: false),
                    ReferenceNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    EarnedLoyaltyPoints = table.Column<float>(nullable: false),
                    PayedDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime('now','localtime')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FoodId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    PaymentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodOrders_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodOrders_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SentEmails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PaymentId = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    SentDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime('now','localtime')"),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentEmails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SentEmails_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SentEmails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SentMessages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PaymentId = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    SentDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime('now','localtime')"),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SentMessages_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SentMessages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrders_FoodId",
                table: "FoodOrders",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrders_PaymentId",
                table: "FoodOrders",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_Code",
                table: "PaymentMethods",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentMethodId",
                table: "Payments",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SentEmails_PaymentId",
                table: "SentEmails",
                column: "PaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SentEmails_UserId",
                table: "SentEmails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SentMessages_PaymentId",
                table: "SentMessages",
                column: "PaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SentMessages_UserId",
                table: "SentMessages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodOrders");

            migrationBuilder.DropTable(
                name: "SentEmails");

            migrationBuilder.DropTable(
                name: "SentMessages");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
