﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VirtualClassroom.Common.Requests
{
    public class ChangePasswordRequest
    {
        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string NewPassword { get; set; }
    }

}
