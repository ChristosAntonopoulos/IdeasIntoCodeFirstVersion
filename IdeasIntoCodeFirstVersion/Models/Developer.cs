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

       

        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime BirthDate { get; set; }
          
        public string GitHub { get; set; }   
        
        public DateTime DateCreated { get; set; }

        [Display(Name = "User ID")]
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        public  ICollection<Project> ProjectsOwned { get; set; }
        public ICollection<Team> TeamParicipating { get; set; }

        public ICollection<Comment> Comments { get; set; }

        [ForeignKey("SenderID")]
        public ICollection<Message> SendMessages { get; set; }

       [ForeignKey("ReceiverID")]
       public ICollection<Message> RecievedMessages { get; set; }

        public ICollection<DeveloperNotification> DeveloperNotifications { get; set; }


        public ICollection<Follow> Followers { get; set; }

        
        public ICollection<Follow> Following { get; set; }

        public string Picture { get; set; }

        public Developer()
        {
            ProjectsOwned = new List<Project>();
            TeamParicipating = new List<Team>();
            Comments = new List<Comment>();
            SendMessages = new List<Message>();
            RecievedMessages = new List<Message>();
            Followers = new List<Follow>();
            Following = new List<Follow>();
            ProgrammingLanguages = new List<ProgrammingLanguage>();

        }

        public void SendMessage(Message message)
        {
            SendMessages.Add(message);
        }


    }
}