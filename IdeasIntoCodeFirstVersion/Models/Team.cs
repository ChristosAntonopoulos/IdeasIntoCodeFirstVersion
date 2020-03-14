using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Models
{
    public class Team
    {
        [Key]
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        public  Project Project { get; set; }

        public ICollection<Developer> TeamMembers { get; set; }

        public Team()
        {
            TeamMembers = new List<Developer>();
        }

    }
}