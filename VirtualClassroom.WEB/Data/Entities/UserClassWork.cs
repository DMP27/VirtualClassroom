using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VirtualClassroom.WEB.Data.Entities
{
    public class UserClassWork
    {
        public int Id { get; set; }

        public int grade { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "User")]
        [JsonIgnore]
        public User User { get; set; }


        [Required]
        [Display(Name = "File")]
        [JsonIgnore]
        public FileClassroom FileClassroom { get; set; }


        [Required]
        [Display(Name = "ClassWork")]
        [JsonIgnore]
        public Classwork Classwork { get; set; }
    }
}
