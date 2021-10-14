using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leads.Api.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TR_WebMethod",
                columns: table => new
                {
                    WebMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TR_WebMethod", x => x.WebMethodId);
                });

            migrationBuilder.CreateTable(
                name: "TM_LogRequestsResponse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestPayload = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsePayload = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResponseTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WebMethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TM_LogRequestsResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WEBMETHOD_LEADSREQUESTRESPONSELOG",
                        column: x => x.WebMethodId,
                        principalTable: "TR_WebMethod",
                        principalColumn: "WebMethodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TM_LogRequestsResponse_WebMethodId",
                table: "TM_LogRequestsResponse",
                column: "WebMethodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TM_LogRequestsResponse");

            migrationBuilder.DropTable(
                name: "TR_WebMethod");
        }
    }
}
