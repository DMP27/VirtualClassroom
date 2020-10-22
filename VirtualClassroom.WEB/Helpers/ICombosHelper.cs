using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassroom.WEB.Data.Entities;

namespace VirtualClassroom.WEB.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboSubjects();

        IEnumerable<SelectListItem> GetComboSubjects2(String userId);

        //IEnumerable<SelectListItem> GetComboDistricts(int fieldId);

        //IEnumerable<SelectListItem> GetComboChurches(int districtId);

        IEnumerable<SelectListItem> GetComboProfessions();
        IEnumerable<SelectListItem> GetComboProfessions2(User user1);
 


    }
}
