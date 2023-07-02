using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrustBank_DataAccessLayer.Migrations
{
    public partial class mig_Relation_CustomerAccount_CustomerAccountActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceiverID",
                table: "CustomerAccountsActivities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderID",
                table: "CustomerAccountsActivities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccountsActivities_ReceiverID",
                table: "CustomerAccountsActivities",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccountsActivities_SenderID",
                table: "CustomerAccountsActivities",
                column: "SenderID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccountsActivities_CustomerAccounts_ReceiverID",
                table: "CustomerAccountsActivities",
                column: "ReceiverID",
                principalTable: "CustomerAccounts",
                principalColumn: "CustomerAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccountsActivities_CustomerAccounts_SenderID",
                table: "CustomerAccountsActivities",
                column: "SenderID",
                principalTable: "CustomerAccounts",
                principalColumn: "CustomerAccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccountsActivities_CustomerAccounts_ReceiverID",
                table: "CustomerAccountsActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccountsActivities_CustomerAccounts_SenderID",
                table: "CustomerAccountsActivities");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccountsActivities_ReceiverID",
                table: "CustomerAccountsActivities");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccountsActivities_SenderID",
                table: "CustomerAccountsActivities");

            migrationBuilder.DropColumn(
                name: "ReceiverID",
                table: "CustomerAccountsActivities");

            migrationBuilder.DropColumn(
                name: "SenderID",
                table: "CustomerAccountsActivities");
        }
    }
}
