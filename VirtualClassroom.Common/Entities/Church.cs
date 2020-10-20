
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;




namespace VirtualClassroom.Common.Entities 
{
    public class Church 
    {
        public int Id { get; set; }

        [DisplayName("Church Name")]
        [MaxLength(50, ErrorMessage = "The field {0} must contain less tha {1} characteres.")]
        [Required]
        public string Name { get; set; }

        //with this we can know which district is that church in
        [JsonIgnore]
        [NotMapped]
        public int IdDistrict { get; set; }


        [JsonIgnore]
        public District District { get; set; }




    }
}
