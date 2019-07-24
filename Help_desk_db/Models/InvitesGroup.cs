using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Help_desk_db
{
    public class InvitesGroup
    {
        [Key]
        public int Id { get; set; }

        public int InviteId { get; set; }
        public Invite Invite { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
