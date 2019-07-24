using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Help_desk_db
{
    public class TemplatesCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int ParentId { get; set; }
        public int Order { get; set; }

        public List<Template> Templates { get; set; }
    }
}
