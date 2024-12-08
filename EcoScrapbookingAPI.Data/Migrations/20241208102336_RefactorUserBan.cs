using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoScrapbookingAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorUserBan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBan",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "IsBan", "Password" },
                values: new object[] { false, "$2a$11$P3j0gWRWNsryioOpQg6nj.uLaRXW47ugcCKi8UpRLxWIP9yQf/T9G" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "IsBan", "Password" },
                values: new object[] { false, "$2a$11$JkQaNQK4twQTjCr1rTkV9.b/1zTMlqvjSwV8CwY5mKKoSsG6VP1Ga" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "IsBan", "Password" },
                values: new object[] { false, "$2a$11$oZpWhvnqTGiE7T4JB.2zl.TqBPWZumDc5fb3/5ra7bH5.sZEfQYTm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "IsBan", "Password" },
                values: new object[] { false, "$2a$11$1ZvlviGq58nuhJucivOYLOjT39UNZK120vh5hlxXN3yQP4Q8BNIWK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "IsBan", "Password" },
                values: new object[] { false, "$2a$11$cmJC6.iocGDnCfNXeADKy.j9LMvuanUcYVxZy4pEl27HXCe4ifW46" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "IsBan", "Password" },
                values: new object[] { false, "$2a$11$b9qeV9XANZf3qYCXKwVDz.e/UiAMNpegIWaCyN8StBLSpCPbdF1ei" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBan",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$kQ1xHN69JpF8cZafw.Ip1OMtNyZIswsjhDSYjcavq/8mPU/Kknzdy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$uQ6HUgtX7vWPDJx1ut3deu5AaXSC0n0f8lz4NwFcS7oLvt46vbMI2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$k.TuDQiVxGt.2jz6dP1E9.yjhKdG9.Z87hkd71bVCGFZ6y5OIznS6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$AIXDLSLnGjU1XXeSfv7a8.IiaDBIvS9livqnif6wexkywDKC.I4YW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$CMVkAZy16MriOqhtvpZ3M.iStAotbdW03KPWf0gDfbagiYIKb7BJ6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$tpkj85VURdDIr1PSewF6OupgM538IZcJ70zI6BvMKNsNENe/S8yka");
        }
    }
}
