using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VirtualClassroom.WEB.Data.Entities
{
    public class Classwork
    {
        public int Id { get; set; }

        [DisplayName("Classwork Name")]
        [MaxLength(50, ErrorMessage = "The field {0} must contain less tha {1} characteres.")]
        //[Required]

        public string Name { get; set; }

        //public string Homework { get; set; }



        //[Display(Name = "File")]
        //public Guid FileId { get; set; }

        //[Display(Name = "File")]
        //public string FileFullPath => FileId == Guid.Empty
        //    ? $"https://webiglesia.azurewebsites.net/images/noimage.png"
        //    : $"https://virtualclassroom1.blob.core.windows.net/subjectfiles/{FileId}";


        //[Display(Name = "Owner Name")]
        //public User User { get; set; }

        //Wich profession that user has
        [JsonIgnore]
        [NotMapped]
        public int IdUser { get; set; }


        public ICollection<UserClassWork> UserClassWorks { get; set; }

        [DisplayName("UserClassWorks Number")]
        public int UserClassWorksNumber => UserClassWorks == null ? 0 : UserClassWorks.Count;

        //[Required]
        //[Display(Name = "User")]
        //[JsonIgnore]
        //public User User { get; set; }


        [Required]
        [Display(Name = "Subject")]
        [JsonIgnore]
        public Subject Subject { get; set; }

    }
}
