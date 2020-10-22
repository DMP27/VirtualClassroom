//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;



//using VirtualClassroom.WEB.Data;

//using Microsoft.EntityFrameworkCore;




//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
////using System.Data.Entity;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;
//using System.Threading.Tasks;
//using VirtualClassroom.WEB.Data;

//using VirtualClassroom.Common.Entities;
//using VirtualClassroom.WEB.Data.Entities;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using System.Security.Claims;
//using VirtualClassroom.WEB.Helpers;

//namespace VirtualClassroom.WEB.Controllers.API
//{

//    [ApiController]
//    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
//    [Route("api/[controller]")]
//    public class MeetingController : ControllerBase
//    {
//        private readonly IUserHelper _userHelper;
//        private readonly DataContext _context;
//        public MeetingController(DataContext context, IUserHelper userHelper)
//        {
//            _context = context;
//            _userHelper = userHelper;
//        }


//        //[HttpGet]
//        //public async Task<IActionResult>  GetMeeting()
//        //{
//        //    User user = await _userHelper.GetUserAsync(User.Identity.Name);
//        //    if (user == null)
//        //    {
//        //        return NotFound();
//        //    }
//        //    //return Ok(_context.Meetings
//        //    //    .Include(m => m.Assistances)
//        //    //    .ThenInclude(a => a.User).
//        //    //    ThenInclude(u => u.Profession).ToListAsync()
//        //    //    );

//        //    return Ok(_context.Meetings.Where(m => m.Church.Id == user.Church.Id).Include(m => m.Assistances).ToListAsync());
//        //}



//        [HttpGet]
//        public IActionResult GetMeetings()
//        {
//            //string email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
//            //User user = await _userHelper.GetUserAsync("cml@gmail.com");
//            //if (user == null)
//            //{
//            //    return NotFound("Error001");
//            //}

//            //User user = await _userHelper.GetUserAsync("cml@yopmail.com");
//            //if (user == null)
//            //{
//            //    return NotFound();
//            //}


//            //List<Order> orders = await _context.Orders
//            //    .Include(o => o.User)
//            //    .ThenInclude(u => u.City)
//            //    .Include(o => o.OrderDetails)
//            //    .ThenInclude(od => od.Product)
//            //    .ThenInclude(od => od.Category)
//            //    .Include(o => o.OrderDetails)
//            //    .ThenInclude(od => od.Product)
//            //    .ThenInclude(od => od.ProductImages)
//            //    .Where(o => o.User.Id == user.Id)
//            //    .OrderByDescending(o => o.Date)
//            //    .ToListAsync();
//            //return Ok(orders);

//            return Ok(_context.Fields
//                .Include(c => c.Districts)
//                .ThenInclude(d => d.Churches));
//        }

//    }
//}



//using Microsoft.AspNetCore.Mvc;

//using VirtualClassroom.WEB.Helpers;

//using VirtualClassroom.WEB.Data;

//using Microsoft.EntityFrameworkCore;
//using VirtualClassroom.WEB.Data.Entities;
//using System.Linq;
//using System.Security.Claims;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using System.Threading.Tasks;
//using System.Collections.Generic;
//using VirtualClassroom.Common.Requests;

//namespace VirtualClassroom.WEB.Controllers.API
//{

//    [ApiController]
//    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
//    [Route("api/[controller]")]
//    public class MeetingController : ControllerBase
//    {
//        private readonly DataContext _context;
//        private readonly IUserHelper _userHelper;
//        public MeetingController(DataContext context, IUserHelper userHelper)
//        {
//            _context = context;
//            _userHelper = userHelper;
//        }
//        // public Assistance assistance;


//        [HttpGet]
//        public async Task<IActionResult> GetMeeting([FromBody] EmailRequest requestl)
//        {
//            //string email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
//            User user = await _userHelper.GetUserAsync(requestl.Email);
//            if (user == null)
//            {
//                return NotFound("Error001");
//            }


//            //User user = await _userHelper.GetUserAsync(User.Identity.Name);
//            //if (user == null)
//            //{
//            //    return NotFound();
//            //}


//            //List<Meeting> Meetings = await _context.Meetings.Where(m => m.Church.Id == user.Church.Id).Include(m => m.Assistances).ToListAsync();
//            //Where(m => m.Assistances.FirstOrDefault().Id == 11)
//            //List<Meeting> Meetings = await _context.Meetings.Where(m => m.Church.Id == user.Church.Id).ToListAsync();
//           // var Meeting = await _context.Meetings.Include(m => m.Church).ToListAsync();
//            //return Ok(Meetings);
//                        return Ok(_context.Fields
//                .Include(c => c.Districts)
//                .ThenInclude(d => d.Churches));


//                /*
//                 *             
//            string email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
//            User user = await _userHelper.GetUserAsync(email);
//            if (user == null)
//            {
//                return NotFound("Error001");
//            }

//            List<Order> orders = await _context.Orders
//                .Include(o => o.User)
//                .ThenInclude(u => u.City)
//                .Include(o => o.OrderDetails)
//                .ThenInclude(od => od.Product)
//                .ThenInclude(od => od.Category)
//                .Include(o => o.OrderDetails)
//                .ThenInclude(od => od.Product)
//                .ThenInclude(od => od.ProductImages)
//                .Where(o => o.User.Id == user.Id)
//                .OrderByDescending(o => o.Date)
//                .ToListAsync();
//            return Ok(orders);
//                 */
//        }



//        //[HttpGet]
//        //[Route("GetAssistance")]
//        //public async Task<IActionResult> GetAssistance(int idmeeting)
//        //{
//        //    //string email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;



//        //    //User user = await _userHelper.GetUserAsync(User.Identity.Name);
//        //    //if (user == null)
//        //    //{
//        //    //    return NotFound();
//        //    //}


//        //    //List<Meeting> Meetings = await _context.Meetings.Where(m => m.Church.Id == user.Church.Id).Include(m => m.Assistances).ToListAsync();
//        //    //Where(m => m.Assistances.FirstOrDefault().Id == 11)
//        //    //List<Meeting> Meetings = await _context.Meetings.Where(m => m.Church.Id == user.Church.Id).ToListAsync();
//        //    // var Meeting = await _context.Meetings.Include(m => m.Church).ToListAsync();

//        //    //var Meeting = await _context.Meetings
//        //    //    .Include(m => m.Assistances)
//        //    //    .ThenInclude(a => a.User)
//        //    //    .ThenInclude(u => u.Profession)
//        //    //   .FirstOrDefaultAsync(m => m.Id == idmeeting);
//        //    //if (Meeting == null)
//        //    //{
//        //    //    return NotFound();
//        //    //}

//        //   var Meeting =  _context.Assistances;
//        //    if (Meeting == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    //return View(Meeting);
//        //    return Ok(Meeting);


//        //    /*
//        //     *             
//        //string email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
//        //User user = await _userHelper.GetUserAsync(email);
//        //if (user == null)
//        //{
//        //    return NotFound("Error001");
//        //}

//        //List<Order> orders = await _context.Orders
//        //    .Include(o => o.User)
//        //    .ThenInclude(u => u.City)
//        //    .Include(o => o.OrderDetails)
//        //    .ThenInclude(od => od.Product)
//        //    .ThenInclude(od => od.Category)
//        //    .Include(o => o.OrderDetails)
//        //    .ThenInclude(od => od.Product)
//        //    .ThenInclude(od => od.ProductImages)
//        //    .Where(o => o.User.Id == user.Id)
//        //    .OrderByDescending(o => o.Date)
//        //    .ToListAsync();
//        //return Ok(orders);
//        //     */
//        //}




//    }
//}




//using Microsoft.AspNetCore.Mvc;



//using VirtualClassroom.WEB.Data;

//using Microsoft.EntityFrameworkCore;
//using System.Linq;
//using System.Data.Entity;
//using System.Threading.Tasks;




using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



using VirtualClassroom.WEB.Data;

using Microsoft.EntityFrameworkCore;




using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassroom.WEB.Data;

using VirtualClassroom.Common.Entities;
using VirtualClassroom.WEB.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using VirtualClassroom.WEB.Helpers;
using VirtualClassroom.Common.Requests;

namespace VirtualClassroom.WEB.Controllers.API
{

    [ApiController]
    [Route("api/[controller]")]
    public class MeetingController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        public MeetingController(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpGet]
        ////[Route("GetMeetingu")]
        //public async Task<IActionResult> GetMeeting([FromBody] EmailRequest requestl)
        //{
            

        //    User user = await _userHelper.GetUserAsync(requestl.Email);
        //    if (user == null)
        //    {
        //        return NotFound("Error001");
        //    }



        //    return Ok (await _context.Meetings.Where(m => m.Church.Id == user.Church.Id).Include(m => m.Assistances).ToListAsync());
        //}

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpGet]
        ////[Route("GetMeetingu")]
        //public async Task<IActionResult> GetMeeting()
        //{


        //    string email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
        //    User user = await _userHelper.GetUserAsync(email);
        //    if (user == null)
        //    {
        //        return NotFound("Error001");
        //    }



        //    return Ok(await _context.Meetings.Where(m => m.Church.Id == user.Church.Id).Include(m => m.Assistances).ToListAsync());
        //}

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpGet]
        //[Route("GetAssistances")]
        //public async Task<IActionResult> GetAssistances([FromBody] String id)
        //{
        //    String id2 = id;
        //    //return Ok(await _context.Assistances.Where(a => a.User.Id == "478").Include(a => a.Meeting.Church).Include(a => a.User).ToListAsync());
        //    return Ok(await _context.Assistances.Where(a => a.User.Id == id2).ToListAsync());
        //}

    }
}
