using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VirtualClassroom.Common.Entities;

namespace VirtualClassroom.Common.Responses
{
    public class MeetingResponse
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }




        public ICollection<AssistanceResponse> Assistances { get; set; }
        //[DisplayName("Assistances Number")]
        public int AssistancesNumber => Assistances == null ? 0 : Assistances.Count;





        //[Display(Name = "Church Name")]
        //[JsonIgnore]
        public Church Church { get; set; }

        //[JsonIgnore]
        //[NotMapped]
        public int IdChurch { get; set; }
    }
}
