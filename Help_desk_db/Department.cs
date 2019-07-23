using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Help_desk_db
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string Slug { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public List<Invite> Invite { get; set; }

        public User User { get; set; }
    }
}
