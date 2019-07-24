using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Help_desk_db
{
    public class Template
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int CategoryId { get; set; }
        public TemplatesCategory TemplatesCategory { get; set; }

        public Ticket Ticket { get; set; }
    }
}
