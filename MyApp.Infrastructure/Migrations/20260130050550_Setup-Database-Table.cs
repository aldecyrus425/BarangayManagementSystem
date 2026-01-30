using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SetupDatabaseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RQ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RA = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Activitys",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activitys", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activitys_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Complainants",
                columns: table => new
                {
                    ComplainantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplainantFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplainantLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplainantAge = table.Column<int>(type: "int", nullable: false),
                    ComplainantAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplainantContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complainants", x => x.ComplainantId);
                    table.ForeignKey(
                        name: "FK_Complainants_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Defendant",
                columns: table => new
                {
                    DefendantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefendantFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefendantLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefendantAge = table.Column<int>(type: "int", nullable: false),
                    DefendantAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefendantContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defendant", x => x.DefendantId);
                    table.ForeignKey(
                        name: "FK_Defendant_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Log_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogAction = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_Logs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordinances",
                columns: table => new
                {
                    OrdinanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdinanceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntroducedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateEnacted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approved_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordinances", x => x.OrdinanceId);
                    table.ForeignKey(
                        name: "FK_Ordinances_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Residents",
                columns: table => new
                {
                    ResidentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CivilStatus = table.Column<int>(type: "int", nullable: false),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residents", x => x.ResidentId);
                    table.ForeignKey(
                        name: "FK_Residents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blotters",
                columns: table => new
                {
                    BlotterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlotterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BlotterComplaint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlotterActionTaken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlotterStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationOfIncidence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SettlementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComplainantId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blotters", x => x.BlotterId);
                    table.ForeignKey(
                        name: "FK_Blotters_Complainants_ComplainantId",
                        column: x => x.ComplainantId,
                        principalTable: "Complainants",
                        principalColumn: "ComplainantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Blotters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlottersResident",
                columns: table => new
                {
                    BlotterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResidentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlottersResident", x => x.BlotterId);
                    table.ForeignKey(
                        name: "FK_BlottersResident_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "ResidentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlottersResident_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BlottersDefendant",
                columns: table => new
                {
                    BlotterDefendantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlotterId = table.Column<int>(type: "int", nullable: false),
                    DefendantId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlottersDefendant", x => x.BlotterDefendantId);
                    table.ForeignKey(
                        name: "FK_BlottersDefendant_Blotters_BlotterId",
                        column: x => x.BlotterId,
                        principalTable: "Blotters",
                        principalColumn: "BlotterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlottersDefendant_Defendant_DefendantId",
                        column: x => x.DefendantId,
                        principalTable: "Defendant",
                        principalColumn: "DefendantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlottersDefendant_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activitys_UserId",
                table: "Activitys",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Blotters_ComplainantId",
                table: "Blotters",
                column: "ComplainantId");

            migrationBuilder.CreateIndex(
                name: "IX_Blotters_UserId",
                table: "Blotters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlottersDefendant_BlotterId",
                table: "BlottersDefendant",
                column: "BlotterId");

            migrationBuilder.CreateIndex(
                name: "IX_BlottersDefendant_DefendantId",
                table: "BlottersDefendant",
                column: "DefendantId");

            migrationBuilder.CreateIndex(
                name: "IX_BlottersDefendant_UserId",
                table: "BlottersDefendant",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlottersResident_ResidentId",
                table: "BlottersResident",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_BlottersResident_UserId",
                table: "BlottersResident",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Complainants_UserId",
                table: "Complainants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Defendant_UserId",
                table: "Defendant",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UserId",
                table: "Logs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordinances_UserId",
                table: "Ordinances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Residents_UserId",
                table: "Residents",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activitys");

            migrationBuilder.DropTable(
                name: "BlottersDefendant");

            migrationBuilder.DropTable(
                name: "BlottersResident");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Ordinances");

            migrationBuilder.DropTable(
                name: "Blotters");

            migrationBuilder.DropTable(
                name: "Defendant");

            migrationBuilder.DropTable(
                name: "Residents");

            migrationBuilder.DropTable(
                name: "Complainants");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
