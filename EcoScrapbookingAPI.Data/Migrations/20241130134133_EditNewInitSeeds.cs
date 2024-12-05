using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcoScrapbookingAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditNewInitSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 23, 3 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 26, 4 });

            migrationBuilder.InsertData(
                table: "UserActivities",
                columns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 5, 1 },
                    { 9, 6 },
                    { 23, 6 },
                    { 26, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$97FLVsw4wSJkMxEuSbBFROh1i/3VzM8ARcnwnELlEDSV6lrqzYwcG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$l3ux2gX22TcBdxj7xTrqVuDQhefNBbHEXYSaoIZRLEIru0eGx8Qm2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$ljivgwi7HgbHxhTO7aMZE.II.j2irElhnCyzPefQVHgDIxOF0gGMm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$77GF3D3tT0/wikyP.XogG.rrt1WU7QlyvfXgC6Wpe0DVJiwQk1YeC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$aijPI8Kd1rAiXWu0ma217./Tjkhy3r6ckhX817yXcy7.9pUqYZ7.u");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$eOOL/9LclP2CqNm82X4vwebVPY3go9dBwHIDzzdvpX5XrvpWKV2fW");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 9, 6 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 23, 6 });

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                keyValues: new object[] { 26, 3 });

            migrationBuilder.InsertData(
                table: "UserActivities",
                columns: new[] { "ActivitiesParticipatedActivityId", "ParticipantsUserId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 5, 2 },
                    { 9, 3 },
                    { 23, 3 },
                    { 26, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$99MBCG4.LMiInLKOfCcdEO5nWe8jLTK6nljDDj2n4t3XJA7dnabEy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$AFV3kuudAhiI5hv47AhlTOwYrZqdHdVqN.P/b7YnffuyrzToD/Fp.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$WxwwQl/LpTMYJ/KSFLgIKODVcB3CZ.wHm4U2XYNCpqOw37PkxOPzC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$C.yc/.xwtwvNgTnmNTmJYe6nAho5J3mMfjj6g2ATwzpdDILpj27ua");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$UV21bN3624LeJlCouyhjKe1RbDMvon/fFOgYebm/Waz8Iuq5G4VPm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$cRYjbtrE0l/hFwiALzH3quaWJKgVNd6OlZrnX82jl0PTnskHYOsWu");
        }
    }
}
