using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoScrapbookingAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Gender", "Password" },
                values: new object[] { "Male", "$2a$11$GU39vtbQv1rnPaT5uyQdvORPJftghNEEtzJrQQdxr8NaUILlmpuUS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Gender", "Password" },
                values: new object[] { "Female", "$2a$11$jbXfbmA851xV1nuIDIW05eInj/Trs6vw9EH1XCqVuJ2jCZCS1ZHXm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "Gender", "Password" },
                values: new object[] { "Male", "$2a$11$XNQTI2JnE4UnWPfSJSPcleo0Y8UC.HgQwuYPNrU3ZMveHQi8BXBJ6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "Gender", "Password" },
                values: new object[] { "Female", "$2a$11$bV7ZPpGT2hKMevYtUfUqcuBFGk7qO/fSvIuXVZbjK2Mn2Io0gEuVa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "Gender", "Password" },
                values: new object[] { "Male", "$2a$11$Tl32fBc97R/cR/mbNw4K3ewfZYVuHpPgmVPYShfgiDJFkphXFADO." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "Gender", "Password" },
                values: new object[] { "Female", "$2a$11$pgopqyHWFbzbjnbO6aRxV.3FcY3006qaIZi81mFsJbosEMWjmZnvK" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Gender", "Password" },
                values: new object[] { "Masculino", "$2a$11$b7IeG6h8KY6f/NfGhJ52UuwQdBq7y8iqMaIMeRUOP7OsJ6vijbWHO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Gender", "Password" },
                values: new object[] { "Femenino", "$2a$11$0U2mDw72kBb7FdUernDFmOCDeo8V.WxtIfpD/BMiZSKa.flNB/coK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "Gender", "Password" },
                values: new object[] { "Masculino", "$2a$11$qu/qL7rS.SV9BR2/XkYpmeSsgkNJWL9uBir8EbHWIrfRxRoGXNbWm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "Gender", "Password" },
                values: new object[] { "Femenino", "$2a$11$Gq8sLxEdc7oskVAbLPfn6unjnzbREU6nta2siZtXBB577QYKfX27O" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "Gender", "Password" },
                values: new object[] { "Masculino", "$2a$11$UqS.Z44YJrKOx3oHTg9kW.Q5EmksIQH5pDk9NgKGLhWZFfGzoalJq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "Gender", "Password" },
                values: new object[] { "Femenino", "$2a$11$cynxkthyHmzB3jr7tycqFOwK83m7Fb7v5NueB6xEDnRnbuzKY9XC6" });
        }
    }
}
