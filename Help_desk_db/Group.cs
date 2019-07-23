using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Help_desk_db
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }

        public int PriorityId { get; set; }

        public List<GroupsPermission> GroupsPermissions { get; set; }
        public List<UsersGroup> UsersGroups { get; set; }
        public List<InvitesGroup> InvitesGroups { get; set; }
        public Group()
        {
            GroupsPermissions = new List<GroupsPermission>();
            UsersGroups = new List<UsersGroup>();
            InvitesGroups = new List<InvitesGroup>();
        }

        public Template Template { get; set; }
    }
}
