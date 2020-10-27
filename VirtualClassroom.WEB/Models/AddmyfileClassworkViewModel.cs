using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VirtualClassroom.WEB.Data.Entities;

namespace VirtualClassroom.WEB.Models
{
    public class AddmyfileClassworkViewModel
    {
        //public string Id { get; set; }
        public int Id { get; set; }
        public int grade { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Subject")]
        [JsonIgnore]
        public Subject Subject { get; set; }


        [Display(Name = "File")]
        public string FileId { get; set; }


        [Display(Name = "File full path")]
        public string FileFullPath = "https://webiglesia.blob.core.windows.net/files/";


        [Display(Name = "FILE")]
        public IFormFile Myfile { get; set; }
    }
}
