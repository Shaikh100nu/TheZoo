using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_crud_sonu_.Migrations
{
    /// <inheritdoc />
    public partial class addedtwomoretables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuestServiceAgent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceAgentFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceAgentLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceAgentAge = table.Column<int>(type: "int", nullable: false),
                    ServiceAgentBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestServiceAgent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zookeeper",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZookeeperFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZookeeperLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZookeeperAge = table.Column<int>(type: "int", nullable: false),
                    ZookeeperBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zookeeper", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestServiceAgent");

            migrationBuilder.DropTable(
                name: "Zookeeper");
        }
    }
}
