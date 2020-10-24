using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassroom.WEB.Data.Entities
{
    public class FileClassroom
    {


        public int Id { get; set; }

        [Display(Name = "File")]
        public Guid FileId { get; set; }

        [Display(Name = "File")]
        public string FileFullPath => FileId == Guid.Empty
            ? $"https://webiglesia.azurewebsites.net/images/noimage.png"
            : $"https://virtualclassroom1.blob.core.windows.net/subjectfiles/{FileId}";



        public ICollection<UserClassWork> UserClassWorks { get; set; }

        [DisplayName("UserClassWorks Number")]
        public int UserClassWorksNumber => UserClassWorks == null ? 0 : UserClassWorks.Count;
    }
}
