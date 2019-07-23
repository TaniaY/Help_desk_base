using Microsoft.EntityFrameworkCore.Migrations;

namespace Help_desk_db.Migrations
{
    public partial class GroupsPermissionsAdding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "groups_permissions",
                columns: table => new
                {
                    PermissionId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups_permissions", x => new { x.GroupId, x.PermissionId });
                    table.UniqueConstraint("AK_groups_permissions_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_groups_permissions_groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_groups_permissions_permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_groups_permissions_PermissionId",
                table: "groups_permissions",
                column: "PermissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "groups_permissions");
        }
    }
}
