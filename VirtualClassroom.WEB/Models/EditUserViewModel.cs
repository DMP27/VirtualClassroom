using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassroom.WEB.Models
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Document { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [Display(Name = "Phone Number")]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Image")]
        public Guid ImageId { get; set; }

        [Display(Name = "Image")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://spiritualhealing.azurewebsites.net/images/noimage.png"
            : $"https://webiglesia.blob.core.windows.net/users/{ImageId}";
        //public string ImageFullPath => ImageId == Guid.Empty
        //    ? $"https://webiglesia.azurewebsites.net/images/noimage.png"
        //    : $"https://webiglesia.blob.core.windows.net/users/{ImageId}";

        

        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

        //[Required]
        //[Display(Name = "Field")]
        //[Range(1, int.MaxValue, ErrorMessage = "You must select a Field.")]
        //public int FieldId { get; set; }

        //public IEnumerable<SelectListItem> Fields { get; set; }

        //[Required]
        //[Display(Name = "District")]
        //[Range(1, int.MaxValue, ErrorMessage = "You must select a District.")]
        //public int DistrictId { get; set; }

        //public IEnumerable<SelectListItem> Districts { get; set; }

        //[Required]
        //[Display(Name = "Church")]
        //[Range(1, int.MaxValue, ErrorMessage = "You must select a Church.")]
        //public int ChurchId { get; set; }

        //public IEnumerable<SelectListItem> Churches { get; set; }



        //[Required]
        [Display(Name = "Profession")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a Profession.")]
        public int ProfessionId { get; set; }

        public IEnumerable<SelectListItem> Professions { get; set; }


        //[Required]
        //[Required]
        [Display(Name = "Subject")]
        //[Range(1, 3, ErrorMessage = "You must select a Subject.")]
        //public int SubjectId { get; set; }
        //public IEnumerable<SelectListItem> SubjectId { get; set; }
        //[Range(2, int.MaxValue, ErrorMessage = "You must select a Subject.")]
        //public MultiSelectList SubjectId { get; set; }
        //public string[] SubjectId { get; set; }


        //[Required]
        public int[] SubjectId { get; set; }

        //[Required]
        public int IdSubject { get; set; }

        //
        public string IdSubjectname { get; set; }
        //public IEnumerable<SelectListItem> SubjectId { get; set; }
        // public IEnumerable<SelectListItem> SubjectId { get; set; }
        //public ICollection<SelectListItem> SubjectId { get; set; }
        //public int UserSubjectsNumber => SubjectId == null ? 0 : SubjectId.Count;



        //public List<SelectListItem> SubjectId { get; set; }


  
        public IEnumerable<SelectListItem> Subjects { get; set; }
    }

}
