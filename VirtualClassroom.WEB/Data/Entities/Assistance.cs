using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassroom.WEB.Data.Entities
{
    public class Assistance
    {
        public int Id { get; set; }


        public bool IsPresent { get; set; }


        //[JsonIgnore]
        //[NotMapped]
        //public int IdUser { get; set; }


        [Required]
        [Display(Name = "User")]
        [JsonIgnore]
        public User User { get; set; }


        [Required]
        [Display(Name = "Meeting date")]
        [JsonIgnore]
        public Meeting Meeting { get; set; }

        //[JsonIgnore]
        //[NotMapped]
        //public int IdMeeting { get; set; }
    }
}
