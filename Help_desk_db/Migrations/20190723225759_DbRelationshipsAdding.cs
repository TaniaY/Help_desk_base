using Microsoft.EntityFrameworkCore.Migrations;

namespace Help_desk_db.Migrations
{
    public partial class DbRelationshipsAdding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_invites_DepartmentId",
                table: "invites");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "tickets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TemplatesCategoryId",
                table: "templates",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_DepartmentId",
                table: "users",
                column: "DepartmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tickets_PriorityId",
                table: "tickets",
                column: "PriorityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tickets_StatusId",
                table: "tickets",
                column: "StatusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tickets_TemplateId",
                table: "tickets",
                column: "TemplateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tickets_UserId",
                table: "tickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_templates_GroupId",
                table: "templates",
                column: "GroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_templates_TemplatesCategoryId",
                table: "templates",
                column: "TemplatesCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_invites_DepartmentId",
                table: "invites",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_TicketId",
                table: "comments",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_attachments_CommentId",
                table: "attachments",
                column: "CommentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_attachments_comments_CommentId",
                table: "attachments",
                column: "CommentId",
                principalTable: "comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_tickets_TicketId",
                table: "comments",
                column: "TicketId",
                principalTable: "tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_templates_groups_GroupId",
                table: "templates",
                column: "GroupId",
                principalTable: "groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_templates_templates_categories_TemplatesCategoryId",
                table: "templates",
                column: "TemplatesCategoryId",
                principalTable: "templates_categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_priorities_PriorityId",
                table: "tickets",
                column: "PriorityId",
                principalTable: "priorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_statuses_StatusId",
                table: "tickets",
                column: "StatusId",
                principalTable: "statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_templates_TemplateId",
                table: "tickets",
                column: "TemplateId",
                principalTable: "templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_users_UserId",
                table: "tickets",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_departments_DepartmentId",
                table: "users",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attachments_comments_CommentId",
                table: "attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_tickets_TicketId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_templates_groups_GroupId",
                table: "templates");

            migrationBuilder.DropForeignKey(
                name: "FK_templates_templates_categories_TemplatesCategoryId",
                table: "templates");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_priorities_PriorityId",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_statuses_StatusId",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_templates_TemplateId",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_users_UserId",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_users_departments_DepartmentId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_DepartmentId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_tickets_PriorityId",
                table: "tickets");

            migrationBuilder.DropIndex(
                name: "IX_tickets_StatusId",
                table: "tickets");

            migrationBuilder.DropIndex(
                name: "IX_tickets_TemplateId",
                table: "tickets");

            migrationBuilder.DropIndex(
                name: "IX_tickets_UserId",
                table: "tickets");

            migrationBuilder.DropIndex(
                name: "IX_templates_GroupId",
                table: "templates");

            migrationBuilder.DropIndex(
                name: "IX_templates_TemplatesCategoryId",
                table: "templates");

            migrationBuilder.DropIndex(
                name: "IX_invites_DepartmentId",
                table: "invites");

            migrationBuilder.DropIndex(
                name: "IX_comments_TicketId",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_attachments_CommentId",
                table: "attachments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tickets");

            migrationBuilder.DropColumn(
                name: "TemplatesCategoryId",
                table: "templates");

            migrationBuilder.CreateIndex(
                name: "IX_invites_DepartmentId",
                table: "invites",
                column: "DepartmentId",
                unique: true);
        }
    }
}
