using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TenderApp.Migrations
{
    public partial class RestoreMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_AspNetUsers_ApplicationUserId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Posts_PostId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Meta_Posts_PostId",
                table: "Post_Meta");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Subs_SubGroups_SubGroupId",
                table: "Subs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subs",
                table: "Subs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubGroups",
                table: "SubGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attachments",
                table: "Attachments");

            migrationBuilder.RenameTable(
                name: "Subs",
                newName: "Sub");

            migrationBuilder.RenameTable(
                name: "SubGroups",
                newName: "SubGroup");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "Attachments",
                newName: "Attachment");

            migrationBuilder.RenameIndex(
                name: "IX_Subs_SubGroupId",
                table: "Sub",
                newName: "IX_Sub_SubGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AuthorId",
                table: "Post",
                newName: "IX_Post_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Category",
                newName: "IX_Category_ParentCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_PostId",
                table: "Attachment",
                newName: "IX_Attachment_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_ApplicationUserId",
                table: "Attachment",
                newName: "IX_Attachment_ApplicationUserId");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Sub",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ForType",
                table: "SubGroup",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sub",
                table: "Sub",
                column: "SubId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubGroup",
                table: "SubGroup",
                column: "SubGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "CategoryId");

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
                name: "FK_Attachment_Post_PostId",
                table: "Attachment",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_ParentCategoryId",
                table: "Category",
                column: "ParentCategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_AuthorId",
                table: "Post",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Meta_Post_PostId",
                table: "Post_Meta",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sub_SubGroup_SubGroupId",
                table: "Sub",
                column: "SubGroupId",
                principalTable: "SubGroup",
                principalColumn: "SubGroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_AspNetUsers_ApplicationUserId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Post_PostId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_ParentCategoryId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_AuthorId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Meta_Post_PostId",
                table: "Post_Meta");

            migrationBuilder.DropForeignKey(
                name: "FK_Sub_SubGroup_SubGroupId",
                table: "Sub");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubGroup",
                table: "SubGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sub",
                table: "Sub");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attachment",
                table: "Attachment");

            migrationBuilder.RenameTable(
                name: "SubGroup",
                newName: "SubGroups");

            migrationBuilder.RenameTable(
                name: "Sub",
                newName: "Subs");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Attachment",
                newName: "Attachments");

            migrationBuilder.RenameIndex(
                name: "IX_Sub_SubGroupId",
                table: "Subs",
                newName: "IX_Subs_SubGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_AuthorId",
                table: "Posts",
                newName: "IX_Posts_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_ParentCategoryId",
                table: "Categories",
                newName: "IX_Categories_ParentCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachment_PostId",
                table: "Attachments",
                newName: "IX_Attachments_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachment_ApplicationUserId",
                table: "Attachments",
                newName: "IX_Attachments_ApplicationUserId");

            migrationBuilder.AlterColumn<string>(
                name: "ForType",
                table: "SubGroups",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Subs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubGroups",
                table: "SubGroups",
                column: "SubGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subs",
                table: "Subs",
                column: "SubId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Meta_Posts_PostId",
                table: "Post_Meta",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
