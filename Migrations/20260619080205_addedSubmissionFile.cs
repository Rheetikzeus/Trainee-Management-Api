using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace TraineeManagement.Migrations
{
    /// <inheritdoc />
    public partial class addedSubmissionFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubmissionFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SubmissionId = table.Column<int>(type: "int", nullable: false),
                    OriginalFileName = table.Column<string>(type: "longtext", nullable: false),
                    GeneratedStorageName = table.Column<string>(type: "longtext", nullable: false),
                    ContentType = table.Column<string>(type: "longtext", nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    CheckSum = table.Column<string>(type: "longtext", nullable: false),
                    UploadedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmissionFiles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubmissionFiles");
        }
    }
}
