using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassroom.WEB.Data.Entities
{
    public class Profession
    {
        public int Id { get; set; }

        [DisplayName("Profession Name")]
        [MaxLength(50, ErrorMessage = "The field {0} must contain less tha {1} characteres.")]
        [Required]
   
        public string Name { get; set; }


        public ICollection<User> Users { get; set; }

        [DisplayName("Users Number")]
        public int UsersNumber => Users == null ? 0 : Users.Count;
    }
}
