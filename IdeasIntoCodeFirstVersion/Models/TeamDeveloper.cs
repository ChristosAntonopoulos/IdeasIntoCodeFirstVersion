using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Models
{
    public class TeamDeveloper
    {
        [Key]
        [Column(Order = 1)]
        public int ProjectID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int DeveloperID { get; set; }
    }
}