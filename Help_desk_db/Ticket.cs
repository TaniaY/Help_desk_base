using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Help_desk_db
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeadlineDate { get; set; }

        public int AuthorId { get; set; }
        public User User { get; set; }

        public int StatusId { get; set; }
        public Statuse Statuse { get; set; }

        public int AssigneeId { get; set; }

        public int PriorityId { get; set; }
        public Priority Priority { get; set; }

        public int TemplateId { get; set; }
        public Template Template { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
