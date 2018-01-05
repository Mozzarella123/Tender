using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TenderApp.Data.Migrations
{
    public partial class FixAfterNikita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_AspNetUsers_ApplicationUserId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Posts_PostId",
                table: "Attachment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attachment",
                table: "Attachment");

            migrationBuilder.RenameTable(
                name: "Attachment",
                newName: "Attachments");

            migrationBuilder.RenameIndex(
                name: "IX_Attachment_PostId",
                table: "Attachments",
                newName: "IX_Attachments_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachment_ApplicationUserId",
                table: "Attachments",
                newName: "IX_Attachments_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attachments",
                table: "Attachments",
                column: "AttachmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_AspNetUsers_ApplicationUserId",
                table: "Attachments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Posts_PostId",
                table: "Attachments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_AspNetUsers_ApplicationUserId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Posts_PostId",
                table: "Attachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attachments",
                table: "Attachments");

            migrationBuilder.RenameTable(
                name: "Attachments",
                newName: "Attachment");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_PostId",
                table: "Attachment",
                newName: "IX_Attachment_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_ApplicationUserId",
                table: "Attachment",
                newName: "IX_Attachment_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attachment",
                table: "Attachment",
                column: "AttachmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_AspNetUsers_ApplicationUserId",
                table: "Attachment",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Posts_PostId",
                table: "Attachment",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
