using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Help_desk_db
{
    public class Attachment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Src { get; set; }
        [Required]
        public string Title { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
