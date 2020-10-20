using System;
using System.Collections.Generic;
using System.Text;
using VirtualClassroom.Common.Entities;
using VirtualClassroom.Common.Enums;

namespace VirtualClassroom.Common.Responses
{
    public class UserResponse
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Document { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public Guid ImageId { get; set; }

        //public string ImageFacebook { get; set; }

        //public LoginType LoginType { get; set; }

        //public string ImageFullPath
        //{
        //    get
        //    {
        //        if (LoginType == LoginType.Facebook && string.IsNullOrEmpty(ImageFacebook) ||
        //            LoginType == LoginType.OnSale && ImageId == Guid.Empty)
        //        {
        //            return $"https://onsaleprepweb.azurewebsites.net/images/noimage.png";
        //        }

        //        if (LoginType == LoginType.Facebook)
        //        {
        //            return ImageFacebook;
        //        }

        //        return $"https://onsale.blob.core.windows.net/users/{ImageId}";
        //    }
        //}

        //public UserType UserType { get; set; }

        //public City City { get; set; }

        //public string FullName => $"{FirstName} {LastName}";

        //public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";


























        //public string Document { get; set; }


        //public string FirstName { get; set; }

        //public string LastName { get; set; }


        //public string Address { get; set; }


        //public Guid ImageId { get; set; }



        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://spiritualhealing.azurewebsites.net/images/noimage.png"
            : $"https://webiglesia.blob.core.windows.net/users/{ImageId}";




        public UserType UserType { get; set; }


        ////Wich church that user is in
        ////we can inherit from web to common, but not from common to web

        public Church Church { get; set; }



        public ProfessionResponse Profession { get; set; }



        public int ChurchId { get; set; }


        //Wich profession that user has

        public int IdProfession { get; set; }



        public string FullName => $"{FirstName} {LastName}";


        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";


        public ICollection<AssistanceResponse> Assistances { get; set; }

        public byte[] ImageArray { get; set; }

    }
}
