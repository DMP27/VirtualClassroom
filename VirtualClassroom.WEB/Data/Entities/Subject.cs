using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassroom.WEB.Data.Entities
{
    public class Subject
    {
        public int Id { get; set; }

        [DisplayName("Subject Name")]
        [MaxLength(50, ErrorMessage = "The field {0} must contain less tha {1} characteres.")]
        [Required]

        public string Name { get; set; }



        public ICollection<UserSubject> UserSubjects { get; set; }
        [DisplayName("Subjects Number")]
        public int UserSubjectsNumber => UserSubjects == null ? 0 : UserSubjects.Count;
    }
}
