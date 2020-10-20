using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VirtualClassroom.Common.Entities
{
    public class District
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} must contain less tha {1} characteres.")]
        [Required]
        public string Name {get; set;}

        public ICollection<Church> Churches { get; set; }

        [DisplayName("Churches Number")]
        public int ChurchesNumber => Churches == null ? 0 : Churches.Count;


        //with this we can know what district is in field
        [JsonIgnore]
        [NotMapped]
        public int IdField { get; set; }


        [JsonIgnore]
        public Field Field { get; set; }

    }
}
