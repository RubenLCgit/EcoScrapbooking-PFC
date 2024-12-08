using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoScrapbookingAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorPublication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$2cBKSXiVd3eLMJPvLj0fOOKBhjTJ8iCQi.G3AazgomxnSuwMdWL9i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$46NCLQ8RnGKwPwHMtKnKOOdHeVRu30PcsLVxL9rMpVV0zzQT1MLjG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$g2A9Rm6SwbYFykdAgbhs0OpWn4WMl8W3QBexTarho0h5zbB.ltzJa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$D2h2a7dlZueAjnA6s3QAjOaisYZxMKpNaF0n/BIOCN5/AEF5/JHMy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$JXjkEOFqvABvmVGYIsKva.RY9jRtQ/.adDlccTaPGd2B2S37yNLeu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$Pp9pQam0ruqIXultJd.V8eEB/TdKDPgxZVWEusseEOB13Fz.Myiee");
        }
    }
}
