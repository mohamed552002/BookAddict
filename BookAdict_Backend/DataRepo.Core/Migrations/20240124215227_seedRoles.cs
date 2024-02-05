using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataRepo.Ef.Migrations
{
    /// <inheritdoc />
    public partial class seedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                schema: "security",
                columns: new[] {"Id", "Name" , "NormalizedName", "ConcurrencyStamp"},
                values: new object[] {Guid.NewGuid().ToString(),"user" , "user".ToUpper() , Guid.NewGuid().ToString() }
                );

            migrationBuilder.InsertData(
                table: "Roles",
                schema: "security",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "admin", "admin".ToUpper(), Guid.NewGuid().ToString() }
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Roles]");
        }
    }
}
