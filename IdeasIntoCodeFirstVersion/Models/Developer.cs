using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Models
{
    public class Developer
    {
        public int ID { get; set; }

        public string FullName
        {
            get
            {
                return LastName + " " + Name;
            }
        }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime BirthDate { get; set; }
        [Required]
        [Display(Name="E-mail")]
        [EmailAddress]
        public string Email { get; set; }        
        public string GitHub { get; set; }      

        public ApplicationUser User { get; set; }

        public List<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        public  ICollection<Project> ProjectsOwned { get; set; }
        public ICollection<Team> TeamParicipating { get; set; }

        public ICollection<Comment> Comments { get; set; }

        [ForeignKey("SenderID")]
        public ICollection<Message> SendMessages { get; set; }

       [ForeignKey("ReceiverID")]
       public ICollection<Message> RecievedMessages { get; set; }

        
       public ICollection<Follow> Followers { get; set; }

        
        public ICollection<Follow> Following { get; set; }


    }
}