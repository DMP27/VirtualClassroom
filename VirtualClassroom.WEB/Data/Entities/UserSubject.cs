using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VirtualClassroom.WEB.Data.Entities
{
    public class UserSubject
    {
        public int Id { get; set; }


        //[JsonIgnore]
        //[NotMapped]
        //public int IdUser { get; set; }


        [Required]
        [Display(Name = "User")]
        [JsonIgnore]
        public User User { get; set; }


        [Required]
        [Display(Name = "Subject")]
        [JsonIgnore]
        public Subject Subject { get; set; }
    }
}
