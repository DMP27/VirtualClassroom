﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VirtualClassroom.Common.Entities
{
    public class Field
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} must contain less tha {1} characteres.")]
        [Required]
        public string Name { get; set; }

        public ICollection<District> Districts { get; set; }

        [DisplayName("Districts Number")]
        public int DistrictsNumber => Districts == null ? 0 : Districts.Count;
    }
}
