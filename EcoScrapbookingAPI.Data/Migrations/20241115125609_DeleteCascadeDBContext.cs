using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoScrapbookingAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteCascadeDBContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Addresses_AddressId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityResources_Activities_ActivitiesActivityId",
                table: "ActivityResources");

            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Users_AuthorId",
                table: "Publications");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_InitiatorUserID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserActivities_Activities_ActivitiesParticipatedActivityId",
                table: "UserActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_UserActivities_Users_ParticipantsUserId",
                table: "UserActivities");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Addresses_AddressId",
                table: "Activities",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityResources_Activities_ActivitiesActivityId",
                table: "ActivityResources",
                column: "ActivitiesActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Users_AuthorId",
                table: "Publications",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_InitiatorUserID",
                table: "Transactions",
                column: "InitiatorUserID",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivities_Activities_ActivitiesParticipatedActivityId",
                table: "UserActivities",
                column: "ActivitiesParticipatedActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivities_Users_ParticipantsUserId",
                table: "UserActivities",
                column: "ParticipantsUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Addresses_AddressId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityResources_Activities_ActivitiesActivityId",
                table: "ActivityResources");

            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Users_AuthorId",
                table: "Publications");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_InitiatorUserID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserActivities_Activities_ActivitiesParticipatedActivityId",
                table: "UserActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_UserActivities_Users_ParticipantsUserId",
                table: "UserActivities");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Addresses_AddressId",
                table: "Activities",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityResources_Activities_ActivitiesActivityId",
                table: "ActivityResources",
                column: "ActivitiesActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Users_AuthorId",
                table: "Publications",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_InitiatorUserID",
                table: "Transactions",
                column: "InitiatorUserID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivities_Activities_ActivitiesParticipatedActivityId",
                table: "UserActivities",
                column: "ActivitiesParticipatedActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivities_Users_ParticipantsUserId",
                table: "UserActivities",
                column: "ParticipantsUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
