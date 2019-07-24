using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Help_desk_db
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public Attachment Attachment { get; set; }
    }
}
