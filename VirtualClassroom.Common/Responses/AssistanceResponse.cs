using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VirtualClassroom.Common.Responses
{
    public class AssistanceResponse
    {
        public int Id { get; set; }


        public bool IsPresent { get; set; }


        //[JsonIgnore]
        //[NotMapped]
        //public int IdUser { get; set; }


        //[Required]
        //[Display(Name = "User")]
        //[JsonIgnore]
        public UserResponse User { get; set; }


        //[Required]
        //[Display(Name = "Meeting date")]
        //[JsonIgnore]
        public MeetingResponse Meeting { get; set; }
    }
}
