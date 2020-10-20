using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassroom.WEB.Data;
using VirtualClassroom.WEB.Helpers;
using VirtualClassroom.Common.Entities;
using VirtualClassroom.WEB.Data.Entities;
using VirtualClassroom.Common.Enums;

namespace VirtualClassroom.WEB.Controllers
{
    [Authorize(Roles = "Teacher,User")]
    //[Authorize(Roles = "User")]
    public class MeetingController : Controller
    {

        private readonly IUserHelper _userHelper;
        private readonly DataContext _context;
       // private readonly ICombosHelper _combosHelper;
        private readonly IBlobHelper _blobHelper;
        //private readonly IMailHelper _mailHelper;

        public MeetingController(DataContext context, IUserHelper userHelper, IBlobHelper blobHelper)
        {
            _context = context;
            _userHelper = userHelper;
            //_combosHelper = combosHelper;
            _blobHelper = blobHelper;
            //_mailHelper = mailHelper;

            
        }

        //public async Task<IActionResult> Index()
        //{
        //    return View();

        //}
        public Church Churcht { get; set; }

        public async Task<IActionResult> Index()
        {





            User user = await _userHelper.GetUserAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            
            //return View(await _context.Meetings.ToListAsync());

            //await _context.Fields.FirstOrDefaultAsync(f => f.Districts.FirstOrDefault(d => d.Id == district.Id) != null);
            // await _context.Professions.FirstOrDefaultAsync(p => p.Users.FirstOrDefault(u => u.Id == user.Id) != null);
            //await _context.Meetings.Where(m => m.IdChurch == user.IdChurch).ToListAsync()
            return View(await _context.Meetings.Where(m => m.Church.Id == user.Church.Id).Include(m => m.Assistances).ToListAsync());
            // await _context.Users.Where(u => u.Church.Id == user.Church.Id).Include(u => u.Profession).ToListAsync()
        }






        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Meeting = await _context.Meetings
                 .Include(m => m.Assistances)
                 .ThenInclude(a => a.User)
                 .ThenInclude(u => u.Profession)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Meeting == null)
            {
                return NotFound();
            }

            return View(Meeting);
        }






        private async Task CheckMeetingAsync()
        {
            //public DateTime d = Convert.ToDateTime("27-04-1997");



            //TODO: Before publish en azure put this if statement again
            //if (!_context.Meetings.Any())
            //{
            if (!_context.Meetings.Any())
            {
                _context.Meetings.Add(new Meeting
                {

                    Date = Convert.ToDateTime("27-04-2022"),

                    Church = await _context.Churches.FindAsync(6),
                    Assistances = new List<Assistance>
                        {
                            new Assistance {
                                IsPresent = true,
                                               User = await _context.Users.FindAsync("788") },

                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("789") }
                        }


                    //IdChurch = 1
                    //Church = 1
                    //Church.Id = 1


                }); ;
                _context.Meetings.Add(new Meeting
                {

                    Date = Convert.ToDateTime("27-02-2022"),
                    Church = await _context.Churches.FindAsync(6),

                    Assistances = new List<Assistance>
                        {
                            new Assistance {IsPresent = false,
                                               User = await _context.Users.FindAsync("788")},

                            new Assistance {  IsPresent = false,
                                               User = await _context.Users.FindAsync("789") }
                        }

                    //IdChurch = 7
                });
                _context.Meetings.Add(new Meeting
                {


                    Date = Convert.ToDateTime("18-09-2022"),
                    Church = await _context.Churches.FindAsync(6),

                    Assistances = new List<Assistance>
                        {
                            new Assistance { IsPresent = true,
                                               User = await _context.Users.FindAsync("788") },

                            new Assistance {  IsPresent = false,
                                               User = await _context.Users.FindAsync("789") }
                        }

                    //IdChurch = 7
                });

                await _context.SaveChangesAsync();
            }


        }






    }
}
