using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Help_desk_db
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Slug { get; set; }

        public List<GroupsPermission> GroupsPermissions { get; set; }
        public Permission()
        {
            GroupsPermissions = new List<GroupsPermission>();
        }
    }
}
