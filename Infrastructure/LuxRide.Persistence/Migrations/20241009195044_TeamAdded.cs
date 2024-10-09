using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LuxRide.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TeamAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "activated",
                table: "users",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "OTPExpireAt",
                table: "users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "otp",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    path = table.Column<string>(type: "text", nullable: false),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    RecordDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateById = table.Column<int>(type: "integer", nullable: true),
                    LastUpdateDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "experiences",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    jobTitle = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    jobDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    companyName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    isPresent = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    RecordDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateById = table.Column<int>(type: "integer", nullable: true),
                    LastUpdateDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_experiences", x => x.id);
                    table.ForeignKey(
                        name: "FK_experiences_teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_experiences_TeamId",
                table: "experiences",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "experiences");

            migrationBuilder.DropTable(
                name: "teams");

            migrationBuilder.DropColumn(
                name: "OTPExpireAt",
                table: "users");

            migrationBuilder.DropColumn(
                name: "otp",
                table: "users");

            migrationBuilder.AlterColumn<bool>(
                name: "activated",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }
    }
}
