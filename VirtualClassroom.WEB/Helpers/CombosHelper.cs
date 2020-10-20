using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassroom.Common.Entities;
using VirtualClassroom.WEB.Data;
using VirtualClassroom.WEB.Data.Entities;

namespace VirtualClassroom.WEB.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;
        public CombosHelper(DataContext context)

        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetComboChurches(int districtId)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            District district = _context.Districts
                .Include(d => d.Churches)
                .FirstOrDefault(d => d.Id == districtId);
            if (district != null)
            {
                list = district.Churches.Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = $"{t.Id}"
                })
                    .OrderBy(t => t.Text)
                    .ToList();
            }

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a Church...]",
                Value = "0"
            });

            return list;

        }

        public IEnumerable<SelectListItem> GetComboDistricts(int fieldId)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            Field field = _context.Fields
                .Include(f => f.Districts)
                .FirstOrDefault(f => f.Id == fieldId);
            if (field != null)
            {
                list = field.Districts.Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = $"{t.Id}"
                })
                    .OrderBy(t => t.Text)
                    .ToList();
            }

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a District...]",
                Value = "0"
            });

            return list;

        }

        public IEnumerable<SelectListItem> GetComboFields()
        {
            List<SelectListItem> list = _context.Fields.Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = $"{t.Id}"
            })
            .OrderBy(t => t.Text)
            .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a Field...]",
                Value = "0"
            });

            return list;

        }

        public IEnumerable<SelectListItem> GetComboProfessions()
        {
            //Here we avoid that any user could creates a proffesor/teacher user type
            
            List<SelectListItem> list = _context.Professions.Where(p => p.Name != "Proffesor").Select(t => new SelectListItem
            {

                Text = t.Name,
                Value = $"{t.Id}"
            })
                .OrderBy(t => t.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a Profession...]",
                Value = "0"
            });

            return list;



            /*
             *             
            List<SelectListItem> list = new List<SelectListItem>();
            Field field = _context.Fields
                .Include(f => f.Districts)
                .FirstOrDefault(f => f.Id == fieldId);
            if (field != null)
            {
                list = field.Districts.Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = $"{t.Id}"
                })
                    .OrderBy(t => t.Text)
                    .ToList();
            }

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a District...]",
                Value = "0"
            });

            return list;
             */

        }

        public IEnumerable<SelectListItem> GetComboProfessions2(User user1 )
        {
            //Here we avoid that any user could creates a proffesor/teacher user type
            //TODO: Able this profession when the admin needs to create a proffesor/teacher

            //await _context.Users.Where(u => u.Church.Id == user.Church.Id).Include(u => u.Profession).ToListAsync()
            //await _context.Professions.FirstOrDefaultAsync(p => p.Users.FirstOrDefault(u => u.Id == user.Id) != null);
            //List<SelectListItem> list = new List<SelectListItem>();
            User user = user1;
            //later edit the second where, it does that the combo doesn't shows all the professions


            List<SelectListItem> list = _context.Professions.Where(p => p.Name != "Proffesor").
                //Where(p => p.Users.FirstOrDefault(u => u.Id == user.Id) != null).
                Select(t => new SelectListItem
            {

                Text = t.Name,
                Value = $"{t.Id}"
            })
                .OrderBy(t => t.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a Profession...]",
                Value = "0"
            });

            return list;



            /*
             *             
            List<SelectListItem> list = new List<SelectListItem>();
            Field field = _context.Fields
                .Include(f => f.Districts)
                .FirstOrDefault(f => f.Id == fieldId);
            if (field != null)
            {
                list = field.Districts.Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = $"{t.Id}"
                })
                    .OrderBy(t => t.Text)
                    .ToList();
            }

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a District...]",
                Value = "0"
            });

            return list;
             */

        }



    }
}
