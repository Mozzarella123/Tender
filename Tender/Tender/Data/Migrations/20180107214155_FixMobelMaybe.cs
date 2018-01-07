using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TenderApp.Data.Migrations
{
    public partial class FixMobelMaybe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subs_SubGroups_SubGroupId",
                table: "Subs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubGroups",
                table: "SubGroups");
            

            migrationBuilder.AddColumn<int>(
                name: "OrganizationPostId",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenderPostId",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostId1",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Offer_OrganizationPostId",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Posts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Mark",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Review_OrganizationPostId",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tender_OrganizationPostId",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubGroups",
                table: "SubGroups",
                column: "SubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_OrganizationPostId",
                table: "Posts",
                column: "OrganizationPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TenderPostId",
                table: "Posts",
                column: "TenderPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostId1",
                table: "Posts",
                column: "PostId1");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Offer_OrganizationPostId",
                table: "Posts",
                column: "Offer_OrganizationPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Review_OrganizationPostId",
                table: "Posts",
                column: "Review_OrganizationPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Tender_OrganizationPostId",
                table: "Posts",
                column: "Tender_OrganizationPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Posts_OrganizationPostId",
                table: "Posts",
                column: "OrganizationPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Posts_TenderPostId",
                table: "Posts",
                column: "TenderPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Posts_PostId1",
                table: "Posts",
                column: "PostId1",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Posts_Offer_OrganizationPostId",
                table: "Posts",
                column: "Offer_OrganizationPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Posts_Review_OrganizationPostId",
                table: "Posts",
                column: "Review_OrganizationPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Posts_Tender_OrganizationPostId",
                table: "Posts",
                column: "Tender_OrganizationPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subs_SubGroups_SubGroupId",
                table: "Subs",
                column: "SubGroupId",
                principalTable: "SubGroups",
                principalColumn: "SubGroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Posts_OrganizationPostId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Posts_TenderPostId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Posts_PostId1",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Posts_Offer_OrganizationPostId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Posts_Review_OrganizationPostId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Posts_Tender_OrganizationPostId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Subs_SubGroups_SubGroupId",
                table: "Subs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubGroups",
                table: "SubGroups");

            migrationBuilder.DropIndex(
                name: "IX_Posts_OrganizationPostId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_TenderPostId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PostId1",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_Offer_OrganizationPostId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_Review_OrganizationPostId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_Tender_OrganizationPostId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "OrganizationPostId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "TenderPostId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostId1",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Offer_OrganizationPostId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Mark",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Review_OrganizationPostId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Tender_OrganizationPostId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Posts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubGroups",
                table: "SubGroups",
                column: "SubGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subs_SubGroups_SubGroupId",
                table: "Subs",
                column: "SubGroupId",
                principalTable: "SubGroups",
                principalColumn: "SubGroupId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
