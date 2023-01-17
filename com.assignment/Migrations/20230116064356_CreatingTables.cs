using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace com.assignment.Migrations
{
    /// <inheritdoc />
    public partial class CreatingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    employeeid = table.Column<int>(name: "employee_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeename = table.Column<string>(name: "employee_name", type: "nvarchar(max)", nullable: false),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    salary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    entryby = table.Column<string>(name: "entry_by", type: "nvarchar(max)", nullable: false),
                    entrydate = table.Column<DateTime>(name: "entry_date", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employee", x => x.employeeid);
                });

            migrationBuilder.CreateTable(
                name: "qualification_list",
                columns: table => new
                {
                    qid = table.Column<int>(name: "q_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    qname = table.Column<string>(name: "q_name", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_qualification_list", x => x.qid);
                });

            migrationBuilder.CreateTable(
                name: "emp_qualification",
                columns: table => new
                {
                    employeeid = table.Column<int>(name: "employee_id", type: "int", nullable: false),
                    qid = table.Column<int>(name: "q_id", type: "int", nullable: false),
                    marks = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_emp_qualification", x => x.employeeid);
                    table.ForeignKey(
                        name: "fk_emp_qualification_employee_employee_id",
                        column: x => x.employeeid,
                        principalTable: "employee",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_emp_qualification_qualification_lists_qualification_list_temp_id",
                        column: x => x.qid,
                        principalTable: "qualification_list",
                        principalColumn: "q_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_emp_qualification_q_id",
                table: "emp_qualification",
                column: "q_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emp_qualification");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "qualification_list");
        }
    }
}
