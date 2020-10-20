using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassroom.Common.Entities;

namespace VirtualClassroom.WEB.Data.Entities
{
    public class Meeting
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }


        /*
         *     
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
    public DateTime Date { get; set; }

    [Display(Name = "Date")]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
    public DateTime DateLocal => Date.ToLocalTime();

         */

        public ICollection<Assistance> Assistances { get; set; }
        [DisplayName("Assistances Number")]
        public int AssistancesNumber => Assistances == null ? 0 : Assistances.Count;





        [Display(Name = "Church Name")]
        [JsonIgnore]
        public Church Church { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int IdChurch { get; set; }

   

    }
}
