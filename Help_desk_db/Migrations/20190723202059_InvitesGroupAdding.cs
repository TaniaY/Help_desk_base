using Microsoft.EntityFrameworkCore.Migrations;

namespace Help_desk_db.Migrations
{
    public partial class InvitesGroupAdding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "invites_groups",
                columns: table => new
                {
                    InviteId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invites_groups", x => new { x.InviteId, x.GroupId });
                    table.UniqueConstraint("AK_invites_groups_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_invites_groups_groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_invites_groups_invites_InviteId",
                        column: x => x.InviteId,
                        principalTable: "invites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_invites_groups_GroupId",
                table: "invites_groups",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "invites_groups");
        }
    }
}
