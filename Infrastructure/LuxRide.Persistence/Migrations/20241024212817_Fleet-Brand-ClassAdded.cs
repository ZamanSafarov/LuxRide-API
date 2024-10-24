using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LuxRide.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FleetBrandClassAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brand",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    RecordDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateById = table.Column<int>(type: "integer", nullable: true),
                    LastUpdateDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brand", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "class",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    RecordDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateById = table.Column<int>(type: "integer", nullable: true),
                    LastUpdateDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_class", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    position = table.Column<string>(type: "text", nullable: false),
                    rate = table.Column<int>(type: "integer", maxLength: 1, nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    RecordDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateById = table.Column<int>(type: "integer", nullable: true),
                    LastUpdateDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fleet",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    brandid = table.Column<int>(type: "integer", nullable: false),
                    classid = table.Column<int>(type: "integer", nullable: false),
                    passangercapacity = table.Column<int>(type: "integer", nullable: false),
                    isavailable = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    hourlyrate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    dailyrate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    airporttransferrate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    RecordDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateById = table.Column<int>(type: "integer", nullable: true),
                    LastUpdateDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fleet", x => x.id);
                    table.ForeignKey(
                        name: "FK_fleet_brand_brandid",
                        column: x => x.brandid,
                        principalTable: "brand",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fleet_class_classid",
                        column: x => x.classid,
                        principalTable: "class",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "fleetavailability",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FleetId = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    isavailable = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    RecordDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateById = table.Column<int>(type: "integer", nullable: true),
                    LastUpdateDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fleetavailability", x => x.id);
                    table.ForeignKey(
                        name: "FK_fleetavailability_fleet_FleetId",
                        column: x => x.FleetId,
                        principalTable: "fleet",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fleetimage",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    path = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ismain = table.Column<bool>(type: "boolean", nullable: false),
                    FleetId = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    RecordDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateById = table.Column<int>(type: "integer", nullable: true),
                    LastUpdateDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fleetimage", x => x.id);
                    table.ForeignKey(
                        name: "FK_fleetimage_fleet_FleetId",
                        column: x => x.FleetId,
                        principalTable: "fleet",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "timeslot",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    starttime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    endtime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    isavailable = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    fleetavailabilityid = table.Column<int>(type: "integer", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    RecordDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateById = table.Column<int>(type: "integer", nullable: true),
                    LastUpdateDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_timeslot", x => x.id);
                    table.ForeignKey(
                        name: "FK_timeslot_fleetavailability_fleetavailabilityid",
                        column: x => x.fleetavailabilityid,
                        principalTable: "fleetavailability",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fleet_brandid",
                table: "fleet",
                column: "brandid");

            migrationBuilder.CreateIndex(
                name: "IX_fleet_classid",
                table: "fleet",
                column: "classid");

            migrationBuilder.CreateIndex(
                name: "IX_fleetavailability_FleetId",
                table: "fleetavailability",
                column: "FleetId");

            migrationBuilder.CreateIndex(
                name: "IX_fleetimage_FleetId",
                table: "fleetimage",
                column: "FleetId");

            migrationBuilder.CreateIndex(
                name: "IX_timeslot_fleetavailabilityid",
                table: "timeslot",
                column: "fleetavailabilityid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fleetimage");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "timeslot");

            migrationBuilder.DropTable(
                name: "fleetavailability");

            migrationBuilder.DropTable(
                name: "fleet");

            migrationBuilder.DropTable(
                name: "brand");

            migrationBuilder.DropTable(
                name: "class");
        }
    }
}
