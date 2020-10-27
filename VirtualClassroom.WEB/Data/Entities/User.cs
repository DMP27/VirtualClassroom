using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassroom.Common.Entities;
using VirtualClassroom.Common.Enums;

namespace VirtualClassroom.WEB.Data.Entities
{
    public class User : IdentityUser
    {

        //[MaxLength(20)]
        //[Required]
        //public string Document { get; set; }

        //[Display(Name = "First Name")]
        //[MaxLength(50)]
        //[Required]
        //public string FirstName { get; set; }

        //[Display(Name = "Last Name")]
        //[MaxLength(50)]
        //[Required]
        //public string LastName { get; set; }

        //[MaxLength(100)]
        //public string Address { get; set; }

        //[Display(Name = "Image")]
        //public Guid ImageId { get; set; }


        //[Display(Name = "Image")]
        //public string ImageFullPath => ImageId == Guid.Empty
        //    ? $"https://spiritualhealing.azurewebsites.net/images/noimage.png"
        //    : $"https://webiglesia.blob.core.windows.net/users/{ImageId}";



        //[Display(Name = "User Type")]
        //public UserType UserType { get; set; }


        ////Wich church that user is in
        ////we can inherit from web to common, but not from common to web
        //[Display(Name = "Church Name")]
        //public Church Church { get; set; }


        //[Display(Name = "Profession Name")]
        //public Profession Profession { get; set; }


        //[JsonIgnore]
        //[NotMapped]
        //public int IdChurch { get; set; }


        ////Wich profession that user has
        //[JsonIgnore]
        //[NotMapped]
        //public int IdProfession { get; set; }


        //[Display(Name = "User")]
        //public string FullName => $"{FirstName} {LastName}";

        //[Display(Name = "User")]
        //public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";


        //public ICollection<Assistance> Assistances { get; set; }

        ////[DisplayName("Assistances Number")]
        ////public int AssistancesNumber => Assistances == null ? 0 : Assistances.Count;
        ///
        [MaxLength(20)]
        [Required]
        public string Document { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [Display(Name = "Image")]
        public Guid ImageId { get; set; }

        [Display(Name = "Image")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://virtualweb.azurewebsites.net/images/noimage.png"
            : $"https://virtualclassroom1.blob.core.windows.net/users/{ImageId}";

        [Display(Name = "User Type")]
        public UserType UserType { get; set; }


        [Display(Name = "User")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "User")]
        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";


        public ICollection<UserClassWork> UserClassWorks { get; set; }

        [DisplayName("UserClassWorks Number")]
        public int UserClassWorksNumber => UserClassWorks == null ? 0 : UserClassWorks.Count;





        public ICollection<UserSubject> UserSubjects { get; set; }
        [DisplayName("Subjects Number")]
        public int UserSubjectsNumber => UserSubjects == null ? 0 : UserSubjects.Count;


        [Display(Name = "Profession Name")]
        public Profession Profession { get; set; }


        [Display(Name = "subject  ID")]
        //[JsonIgnore]
        //[NotMapped]
        public int IdSubject { get; set; }
 


        //Wich profession that user has
        [JsonIgnore]
        [NotMapped]
        public int IdProfession { get; set; }

    }
}
