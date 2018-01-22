using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TenderApp.Migrations
{
    public partial class SubsKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sub_SubGroup_SubGroupId",
                table: "Sub");

            migrationBuilder.RenameColumn(
                name: "SubGroupId",
                table: "Sub",
                newName: "GroupSubGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Sub_SubGroupId",
                table: "Sub",
                newName: "IX_Sub_GroupSubGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sub_SubGroup_GroupSubGroupId",
                table: "Sub",
                column: "GroupSubGroupId",
                principalTable: "SubGroup",
                principalColumn: "SubGroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sub_SubGroup_GroupSubGroupId",
                table: "Sub");

            migrationBuilder.RenameColumn(
                name: "GroupSubGroupId",
                table: "Sub",
                newName: "SubGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Sub_GroupSubGroupId",
                table: "Sub",
                newName: "IX_Sub_SubGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sub_SubGroup_SubGroupId",
                table: "Sub",
                column: "SubGroupId",
                principalTable: "SubGroup",
                principalColumn: "SubGroupId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
