using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassroom.Common.Entities;
using VirtualClassroom.Common.Enums;
using VirtualClassroom.Common.Responses;
using VirtualClassroom.WEB.Data;
using VirtualClassroom.WEB.Data.Entities;
using VirtualClassroom.WEB.Helpers;
using VirtualClassroom.WEB.Models;

using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace VirtualClassroom.WEB.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserHelper _userHelper;
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;
        private readonly IBlobHelper _blobHelper;
        private readonly IMailHelper _mailHelper;

        public AccountController(DataContext context,IUserHelper userHelper,ICombosHelper combosHelper,IBlobHelper blobHelper, IMailHelper mailHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _combosHelper = combosHelper;
            _blobHelper = blobHelper;
            _mailHelper = mailHelper;
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.
                Include(u => u.Profession).ToListAsync());


        }

        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> StudentsList()
        {
            User user = await _userHelper.GetUserAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }


            //District district = await _context.Districts.FirstOrDefaultAsync(d => d.Churches.FirstOrDefault(c => c.Id == user.Church.Id) != null);
            //if (district == null)
            //{
            //    district = await _context.Districts.FirstOrDefaultAsync();
            //}

            //Field field = await _context.Fields.FirstOrDefaultAsync(f => f.Districts.FirstOrDefault(d => d.Id == district.Id) != null);
            //if (field == null)
            //{
            //    field = await _context.Fields.FirstOrDefaultAsync();
            //}




            Profession profession = await _context.Professions.FirstOrDefaultAsync(p => p.Users.FirstOrDefault(u => u.Id == user.Id) != null);
            if (profession == null)
            {
                profession = await _context.Professions.FirstOrDefaultAsync();
            }

            //ICollection<UserSubject> UserSubject = (ICollection<UserSubject>)await _context.UserSubjects.FirstOrDefaultAsync(p => p.User.Id == user.Id);

            //UserSubject usersubject = await _context.UserSubjects.FirstOrDefaultAsync(p => p.User.Id == user.Id);

            //IEnumerable<UserSubject> usersubject = await _context.UserSubjects.Where(p => p.Id == user.UserSubjects).ToListAsync();
            //UserSubject usersubject = await _context.UserSubjects.Where(p => p.Subject.Id == usersubject.Subject.Id).ToListAsync();

            //User user2 = await _context.Users.FirstOrDefaultAsync(f => f.UserSubjects.FirstOrDefault(d => d.Id == usersubject.Id) != null);
            // await _context.Users.Where(u => u.IdSubject == usersubject.Id).ToListAsync();

            // User user2 = await _context.Users.FirstOrDefaultAsync(u => u.UserSubjects.FirstOrDefault(a => a.Id == UserSubject)).ToListAsync();

            //return View(await _context.Users.Where(u => u.UserSubjects == usersubject).ToListAsync());
            //return View(await _context.UserSubjects.Where(p => p.Subject.Id == usersubject.Subject.Id).ToListAsync());

            //            return await _context.Users.Include(u => u.UserSubjects.FirstOrDefault(a => a.User.Id == userId.ToString()))

            //.FirstOrDefaultAsync(u => u.Id == userId.ToString());




            //List<SelectListItem> list = _context.UserSubjects.Where(u => u.User.Id == user.Id).

            //    Select(t => new SelectListItem
            //    {
            //        Text = t.Subject.Name,
            //        Value = $"{t.Id}"
            //    })
            //    .ToList();


            ////Subject subject = await _context.Subjects.

            //ICollection<UserSubject> UserSubject2 = (ICollection<UserSubject>)await _context.UserSubjects.FirstOrDefaultAsync(p => p.User.Id == user.Id);

            //return View(await _context.UserSubjects.Where(u => u.User.Id == user.Id).Include(a => a.Subject).ToListAsync());
            //return View(await _context.UserSubjects.Where(u => u.Subject == user.UserSubjects
            //).Include(a => a.Subject).Include(f => f.User).ToListAsync());


            //return View(await _context.Users.Where(u => UserSubject2.Contains(u.UserSubjects) == user.UserSubjects
            //                    ).Include(a => a.Subject).Include(f => f.User).ToListAsync());

            //return View(await _context.UserSubjects.Where(u => u.Subject == user.UserSubjects.Where(k => k.User.Id == user.Id)
            //).Include(a => a.Subject).Include(f => f.User).ToListAsync());

            //Subject subject = await _context.Subjects.FirstOrDefaultAsync(p => p.Id == user.IdSubject);
            ////int prueba = user.IdSubjectname;
            //string prueba = subject.Name;
            return View(await _context.UserSubjects.
                Where(u => u.Subject.Id == user.IdSubject).
                Include(a => a.Subject).Include(f => f.User).ToListAsync());
            //return View(await _context.Users.Where(u => u.UserSubjects) UserSubjects.Where(p => p.Subject.Id == 1
            //).ToListAsync()
            //);
            //return View(await _context.Users.Where(u => u..Subject.Id == usersubject.Subject.Id).ToListAsync());



            //return View( await _context.Users.
            //    FirstOrDefaultAsync(d => d.UserSubjects.FirstOrDefault(c => c.Subject.Id == user.UserSubjects.
            //    FirstOrDefault(u => u.Subject.Id)
            //    ) != null)

            //Where(u => u.IdSubject == user.IdSubject).Include(u => u.Profession).ToListAsync()    );


        }


        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Email or password incorrect.");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }


        public IActionResult NotAuthorized()
        {
            return View();
        }



        public IActionResult Register()
        {
            AddUserViewModel model = new AddUserViewModel
            {
                
                
                //Districts = _combosHelper.GetComboDistricts(0),
                //Churches = _combosHelper.GetComboChurches(0),
                Professions = _combosHelper.GetComboProfessions(),
                Subjects = _combosHelper.GetComboSubjects()

            };

            return View(model);
        }

        public String valueAsString;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AddUserViewModel model)

        {
            //var selected = model.SubjectId.Items.Where(i => i.Selected);

            //foreach (int blah in S.sele)
            //{

            //    MessageBox.Show(blah.ToString());

            //}
            //System.Diagnostics.Debug.WriteLine("ENTRAAA DONDE NO DEBE------------------------>" + UserType.Teacher.ToString());

            //SelectListItem[] items = model.SubjectId.ToArray();
            //SelectListItem selectedItem = items.FirstOrDefault(i => i.Value == valueAsString)
            //    ?? items[0];
            //string selectedText = selectedItem.Text;

            //int p = model.SubjectId.ToArray().Count();

            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("ENTRAAA DONDE NO DEBE------------------------>" + UserType.Teacher.ToString());
                Guid imageId = Guid.Empty;

                if (model.ImageFile != null)
                {
                    imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "users");
                }


                User user = await _userHelper.AddUserAsync(model, imageId, UserType.User);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "This email is already used.");
                    //model.Fields = _combosHelper.GetComboFields();
                    //model.Districts = _combosHelper.GetComboDistricts(model.FieldId);
                    //model.Churches = _combosHelper.GetComboChurches(model.DistrictId);
                    model.Subjects = _combosHelper.GetComboSubjects();
                    model.Professions = _combosHelper.GetComboProfessions();

                    return View(model);
                }

                string myToken = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                string tokenLink = Url.Action("ConfirmEmail", "Account", new
                {
                    userid = user.Id,
                    token = myToken
                }, protocol: HttpContext.Request.Scheme);

                Response response = _mailHelper.SendMail(model.Username, "Email confirmation", $"<h1>Email Confirmation</h1>" +
                    $"To allow the user, " +
                    $"plase click in this link:</br></br><a href = \"{tokenLink}\">Confirm Email</a>");
                if (response.IsSuccess)
                {
                    ViewBag.Message = "The instructions to allow your user has been sent to email.";
                    return View(model);
                }

                ModelState.AddModelError(string.Empty, response.Message);

            }

            //model.Fields = _combosHelper.GetComboFields();
            //model.Districts = _combosHelper.GetComboDistricts(model.FieldId);
            //model.Churches = _combosHelper.GetComboChurches(model.DistrictId);
            model.Subjects = _combosHelper.GetComboSubjects();
            model.Professions = _combosHelper.GetComboProfessions();
            return View(model);
        }



        public JsonResult GetUserSubjects(int subjectId)
        {


            Subject subject = _context.Subjects
                .Include(f => f.UserSubjects)
                .FirstOrDefault(f => f.Id == subjectId);

 
            if (subject == null)
            {
                return null;
            }

            return Json(subject.UserSubjects.OrderBy(d => d.Subject.Name));
        }



        //public JsonResult GetDistricts(int fieldId)
        //{
        //    Field field = _context.Fields
        //        .Include(f => f.Districts)
        //        .FirstOrDefault(f => f.Id == fieldId);
        //    if (field == null)
        //    {
        //        return null;
        //    }

        //    return Json(field.Districts.OrderBy(d => d.Name));
        //}

        //public JsonResult GetChurches(int districtId)
        //{
        //    District district = _context.Districts
        //        .Include(d => d.Churches)
        //        .FirstOrDefault(d => d.Id == districtId);
        //    if (district == null)
        //    {
        //        return null;
        //    }

        //    return Json(district.Churches.OrderBy(c => c.Name));
        //}


        public IEnumerable<SelectListItem> aux { get; set; }
        public IEnumerable<SelectListItem> aux2 { get; set; }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> ChangeUser()
        {
            User user = await _userHelper.GetUserAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            //District district = await _context.Districts.FirstOrDefaultAsync(d => d.Churches.FirstOrDefault(c => c.Id == user.Church.Id) != null);
            //if (district == null)
            //{
            //    district = await _context.Districts.FirstOrDefaultAsync();
            //}

            //Field field = await _context.Fields.FirstOrDefaultAsync(f => f.Districts.FirstOrDefault(d => d.Id == district.Id) != null);
            //if (field == null)
            //{
            //    field = await _context.Fields.FirstOrDefaultAsync();
            //}


            Profession profession = await _context.Professions.FirstOrDefaultAsync(p => p.Users.FirstOrDefault(u => u.Id == user.Id) != null);
            if (profession == null)
            {
                profession = await _context.Professions.FirstOrDefaultAsync();
            }

            Subject subject = await _context.Subjects.FirstOrDefaultAsync(p => p.Id == user.IdSubject);
            if (subject == null)
            {
                subject = await _context.Subjects.FirstOrDefaultAsync();
            }

            if (user.UserType.ToString() == "Teacher")
            {
                aux2 = _context.Subjects.Where(s => s.Id == user.IdSubject).Select(t => new SelectListItem
                {

                    Text = t.Name,
                    Value = $"{t.Id}"
                }).OrderBy(t => t.Text)
                .ToList();



                aux = _context.Professions.Where(p => p.Name == "Proffesor").Select(t => new SelectListItem
                {

                    Text = t.Name,
                    Value = $"{t.Id}"
                }).OrderBy(t => t.Text)
                  .ToList();
            }
            else
            {
                user.IdSubject = 0;
                //subject.Name = "d";
                aux2 = _combosHelper.GetComboSubjects2(user.Id);
                aux = _combosHelper.GetComboProfessions2(user);
            }

            EditUserViewModel model = new EditUserViewModel
            {
               
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                ImageId = user.ImageId,

                //Churches = _combosHelper.GetComboChurches(district.Id),
                //ChurchId = user.Church.Id,
                //Fields = _combosHelper.GetComboFields(),
                //FieldId = field.Id,
                //DistrictId = district.Id,
                //Districts = _combosHelper.GetComboDistricts(field.Id),
                IdSubject = user.IdSubject,
                Subjects = aux2,
                IdSubjectname = subject.Name,
                //Subjects = _combosHelper.GetComboSubjects2(user.Id),
                
                //Subjects =  _combosHelper.GetComboSubjects(),
            Professions = aux,

                ProfessionId = profession.Id,
                Id = user.Id,

                Document = user.Document


            };;


            return View(model);
        }
        [Authorize(Roles = "User")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeUser(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                Guid imageId = model.ImageId;

                if (model.ImageFile != null)
                {
                    imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "users");
                }

                User user = await _userHelper.GetUserAsync(User.Identity.Name);

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Address = model.Address;
                user.PhoneNumber = model.PhoneNumber;
                user.ImageId = imageId;
                //user.Church = await _context.Churches.FindAsync(model.ChurchId);
                //user.UserSubjects = await _context.Churches.FindAsync(model.ChurchId);
                user.IdSubject = model.IdSubject;
                user.Profession = await _context.Professions.FindAsync(model.ProfessionId);
                user.Document = model.Document;


                await _userHelper.UpdateUserAsync(user);
                return RedirectToAction("Index", "Home");
            }



            //model.Fields = _combosHelper.GetComboFields();
            //model.Districts = _combosHelper.GetComboDistricts(model.FieldId);
            //model.Churches = _combosHelper.GetComboChurches(model.DistrictId);
           
            model.Subjects = _combosHelper.GetComboSubjects();
            model.Professions = aux;
            //model.Professions = _combosHelper.GetComboProfessions();
            return View(model);
        }







        //[Authorize(Roles = "User")]
        //[Authorize(Roles = "User")]
        //[Authorize(Roles = "Teacher")]
        private static string _MyGlobalVariableuser3;
        private static string username;
        private static User userglobal;
        [Authorize(Roles = "User,Teacher")]

        public async Task<IActionResult> UserSubjectList()
        {
            User user = await _userHelper.GetUserAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            _MyGlobalVariableuser3 = user.Id;
            username = user.FullName;
            userglobal = user;

            Profession profession = await _context.Professions.FirstOrDefaultAsync(p => p.Users.FirstOrDefault(u => u.Id == user.Id) != null);
            if (profession == null)
            {
                profession = await _context.Professions.FirstOrDefaultAsync();
            }

            Subject subject = await _context.Subjects.FirstOrDefaultAsync(p => p.Id == user.IdSubject);
            if (subject == null)
            {
                subject = await _context.Subjects.FirstOrDefaultAsync();
            }

            if (user.UserType.ToString() == "Teacher")
            {
                aux2 = _context.Subjects.Where(s => s.Id == user.IdSubject).Select(t => new SelectListItem
                {

                    Text = t.Name,
                    Value = $"{t.Id}"
                }).OrderBy(t => t.Text)
                .ToList();



                aux = _context.Professions.Where(p => p.Name == "Proffesor").Select(t => new SelectListItem
                {

                    Text = t.Name,
                    Value = $"{t.Id}"
                }).OrderBy(t => t.Text)
                  .ToList();
            }
            else
            {
                user.IdSubject = 0;
                //subject.Name = "d";
                aux2 = _combosHelper.GetComboSubjects2(user.Id);
                aux = _combosHelper.GetComboProfessions2(user);
            }

            EditUserViewModel model = new EditUserViewModel
            {

                //Address = user.Address,
                //FirstName = user.FirstName,
                //LastName = user.LastName,
                //PhoneNumber = user.PhoneNumber,
                //ImageId = user.ImageId,

                //Churches = _combosHelper.GetComboChurches(district.Id),
                //ChurchId = user.Church.Id,
                //Fields = _combosHelper.GetComboFields(),
                //FieldId = field.Id,
                //DistrictId = district.Id,
                //Districts = _combosHelper.GetComboDistricts(field.Id),
                IdSubject = user.IdSubject,
                Subjects = aux2,
                IdSubjectname = subject.Name,
                //Subjects = _combosHelper.GetComboSubjects2(user.Id),

                //Subjects =  _combosHelper.GetComboSubjects(),
                Professions = aux,

                ProfessionId = profession.Id,
                Id = user.Id

                //Document = user.Document


            }; ;


            return View(model);
        }

        public int subjectaux;
        //[Authorize(Roles = "User")]
        //[Authorize(Roles = "User")]
        //[Authorize(Roles = "Teacher")]
        [Authorize(Roles = "User,Teacher")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserSubjectList(EditUserViewModel model)
        {


            //int[] model2 = model.SubjectId;

            subjectaux = model.SubjectId[0];
            _MyGlobalVariable = model.SubjectId[0];
            return  RedirectToAction("ClassWorkUser", new { axusubject = subjectaux });

            //if (ModelState.IsValid)
            //{
            //    Guid imageId = model.ImageId;

            //    if (model.ImageFile != null)
            //    {
            //        imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "users");
            //    }

            //    User user = await _userHelper.GetUserAsync(User.Identity.Name);

            //    user.FirstName = model.FirstName;
            //    user.LastName = model.LastName;
            //    user.Address = model.Address;
            //    user.PhoneNumber = model.PhoneNumber;
            //    user.ImageId = imageId;
            //    //user.Church = await _context.Churches.FindAsync(model.ChurchId);
            //    //user.UserSubjects = await _context.Churches.FindAsync(model.ChurchId);
            //    user.IdSubject = model.IdSubject;
            //    user.Profession = await _context.Professions.FindAsync(model.ProfessionId);
            //    user.Document = model.Document;


            //    await _userHelper.UpdateUserAsync(user);
            //    return RedirectToAction("Index", "Home");
            //}



            //model.Fields = _combosHelper.GetComboFields();
            //model.Districts = _combosHelper.GetComboDistricts(model.FieldId);
            //model.Churches = _combosHelper.GetComboChurches(model.DistrictId);

            //model.Subjects = _combosHelper.GetComboSubjects();
            //model.Professions = aux;
            ////model.Professions = _combosHelper.GetComboProfessions();
            //return View(model);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ClassWorkUser(EditUserViewModel model)
        //{

        //    int p = model.SubjectId[0];
        //    return RedirectToAction("Index", "Home");

        //    return View(model);
        //}



        //[Authorize(Roles = "User")]
        //[Authorize(Roles = "Teacher")]
        private static int _MyGlobalVariable;
        private static int _MyGlobalVariable2;
        

        [Authorize(Roles = "User,Teacher")]
        public async Task<IActionResult> ClassWorkUser(int axusubject)
        {


            //_MyGlobalVariable = axusubject;

            //IEnumerable<Classwork> classwork = await _context.Classworks.Where(c => c.Subject.Id == axusubject).Include(s => s.Subject).ToListAsync();

            //return View(await _context.Classworks.Where(c => c.Subject.Id == axusubject).Include(s => s.Subject).ToListAsync());
            return View(await _context.Classworks.Where(c => c.Subject.Id == _MyGlobalVariable).Include(s => s.Subject).ToListAsync());

        }









        public IActionResult  CreateClasswork()
        {


            //User user = await _userHelper.GetUserAsync(User.Identity.Name);
            //if (user == null)
            //{
            //    return NotFound();
            //}
         
            //Subject subject = await _context.Subjects.FirstOrDefaultAsync(p => p.Id == user.IdSubject);
            //if (subject == null)
            //{
            //    subject = await _context.Subjects.FirstOrDefaultAsync();
            //}



            AddClassWorkViewModel model2 = new AddClassWorkViewModel
            {
                //Name = "",
                ////Subject = subject,
                //FileId = "",
                
            };


           

            //return (model2,ayuda);

            return View(model2);

    //        Subject subject1 = await _context.Subjects
    //.Include(s => s.Classworks)
    //.FirstOrDefaultAsync(f => f.Id == ayuda);


    //        subject1.Classworks.Add(new Classwork
    //        {
    //            Name = "prueba"
    //        }
    //            );
    //        _context.Update(subject);
    //        await _context.SaveChangesAsync();


            //return RedirectToAction("CreateClasswork2", new { model2 = model2 , ayuda1 = ayuda});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateClasswork(AddClassWorkViewModel model22)
        {

            //Guid filesId = Guid.Empty;
            //if (model22.Myfile != null)
            //{
            //    filesId = await _blobHelper.UploadBlobAsync(model22.Myfile, "files");
            //}

            //int auxxx = _MyGlobalVariable;
            //Subject subject = await _context.Subjects
            //    .Include(s => s.Classworks)
            //    .FirstOrDefaultAsync(f => f.Id == auxxx);


            //subject.Classworks.Add(new Classwork
            //{
            //    Name = model22.Name,
            //    FileId = model22.Myfile.FileName
            //}
            //    ) ;
            //_context.Update(subject);
            //await _context.SaveChangesAsync();

            //Guid filesId = Guid.Empty;
            string filedId = "";
            if (model22.Myfile != null)
            {
                filedId = await _blobHelper.UploadBlob2Async(model22.Myfile, "files");
            }

            int auxxx = _MyGlobalVariable;
            Subject subject = await _context.Subjects
                .Include(s => s.Classworks)
                .FirstOrDefaultAsync(f => f.Id == auxxx);


            subject.Classworks.Add(new Classwork
            {
                Name = model22.Name,
                FileId = model22.Myfile.FileName
            }
                );
            _context.Update(subject);
            await _context.SaveChangesAsync();

            //User user = await _userHelper.GetUserAsync(User.Identity.Name);
            //if (user == null)
            //{
            //    return NotFound();
            //}
            //user = await _context.Users.Include(k => k.UserSubjects).Where(a => a.i)    Where(u => u.s)

            IEnumerable<UserSubject> usersubject = await _context.UserSubjects.Where(u => u.Subject.Id == auxxx).Include(s => s.User).Include(j => j.Subject).ToListAsync();

            foreach (var item in usersubject)
            {
                Response response = _mailHelper.SendMail(item.User.UserName, "INBOX CLASSWORK HAS BEEN UPDATED", "Hi!" +  item.User.FirstName + "One new Classwork has been upload for the subject:" + item.Subject.Name);
            }




            return RedirectToAction("ClassWorkUser", new { axusubject = auxxx });
            
        }









        public async Task<IActionResult> DetailsClasswork(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Subject subject = await _context.Subjects.Include(s => s.Classworks).FirstOrDefaultAsync(a => a.Id == id);
            //Classwork classwork = await _context.Classworks.Include(c => c.Subject).Include(f => f.UserClassWorks).ThenInclude(g => g.FileClassroom).FirstOrDefaultAsync(a => a.Id == id);

            Classwork classwork = await _context.Classworks.Include(c => c.Subject).Include(f => f.UserClassWorks).ThenInclude(p => p.User).ThenInclude(h => h.UserClassWorks).ThenInclude(g => g.FileClassroom).FirstOrDefaultAsync(a => a.Id == id);
            _MyGlobalVariable2 = classwork.Id;
            //Classwork classwork = await _context.Classworks.Include(c => c.Subject).FirstOrDefaultAsync(a => a.Id == id);
            //var Field = await _context.Fields
            //     .Include(f => f.Districts)
            //     .ThenInclude(d => d.Churches)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            if (classwork == null)
            {
                return NotFound();
            }

            return View(classwork);
        }




















        public IActionResult AddmyfileClasswork()
        {





            AddmyfileClassworkViewModel model = new AddmyfileClassworkViewModel
            {
               

            };




           

            return View(model);

  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddmyfileClasswork(AddmyfileClassworkViewModel model22)
        {

            string filedId = "";
            if (model22.Myfile != null)
            {
                filedId = await _blobHelper.UploadBlob2Async(model22.Myfile, "files");
            }

            int auxxx = _MyGlobalVariable;
            //Subject subject = await _context.Subjects
            //    .Include(s => s.Classworks)
            //    .FirstOrDefaultAsync(f => f.Id == auxxx);



            Classwork classwork = await _context.Classworks
                .Include(s => s.UserClassWorks)
                .FirstOrDefaultAsync(f => f.Id == _MyGlobalVariable2);



            FileClassroom fileClassroom = new FileClassroom
            {
                FileId = model22.Myfile.FileName,
                Name = model22.Name
            };

              _context.FileClassrooms.Add(fileClassroom);
            await _context.SaveChangesAsync();
            //FileClassroom fileClassroom= await _context.FileClassrooms.Add(new FileClassroom
            //        {
            //            FileId = model22.Myfile.FileName
            //         }
            //    );


            classwork.UserClassWorks.Add(new UserClassWork
            {

                FileClassroom = await _context.FileClassrooms.FindAsync(fileClassroom.Id),
                User = await _context.Users.FindAsync(_MyGlobalVariableuser3)
                

            }
            );
            _context.Update(classwork);
            await _context.SaveChangesAsync();


            //subject.Classworks.Add(new Classwork
            //{
            //    Name = model22.Name,
            //    FileId = model22.Myfile.FileName
            //}
            //    );
            //_context.Update(subject);
            //await _context.SaveChangesAsync();



            //IEnumerable<UserSubject> usersubject = await _context.UserSubjects.Where(u => u.Subject.Id == auxxx).Include(s => s.User).Include(j => j.Subject).ToListAsync();

            //foreach (var item in usersubject)
            //{
            //    Response response = _mailHelper.SendMail(item.User.UserName, "INBOX CLASSWORK HAS BEEN UPDATED", "Hi!" + item.User.FirstName + "One new Classwork has been upload for the subject:" + item.Subject.Name);
            //}




            return RedirectToAction("ClassWorkUser", new { axusubject = auxxx });

        }








        public async Task<IActionResult> DeleteClasswork(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classwork = await _context.Classworks
                .FirstOrDefaultAsync(m => m.Id == id);

            if (classwork == null)
            {
                return NotFound();
            }

            try
            {
                _context.Classworks.Remove(classwork);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }




            return RedirectToAction("ClassWorkUser", new { axusubject = _MyGlobalVariable });

            //return View(Field);
        }

















        public async Task<IActionResult> EditClasswork(int? id)
        {




            int auxxx = _MyGlobalVariable;
            Subject subject = await _context.Subjects
                .Include(s => s.Classworks)
                .FirstOrDefaultAsync(f => f.Id == auxxx);


            Classwork classwork = await _context.Classworks.FindAsync(id);


            AddClassWorkViewModel model2 = new AddClassWorkViewModel
            {
                
                Id = (int)id,
                Name = classwork.Name,
                FileId = classwork.FileId
                

            };


            

            return View(model2);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditClasswork(AddClassWorkViewModel classwork1)
        {


            string filedId = "";
            if (classwork1.Myfile != null)
            {
                filedId = await _blobHelper.UploadBlob2Async(classwork1.Myfile, "files");
            }

            int auxxx = _MyGlobalVariable;
 

            Classwork classwork = await _context.Classworks.FindAsync(classwork1.Id);
            classwork.Name = classwork1.Name;
            classwork.FileId = classwork1.Myfile.FileName;
 


            _context.Update(classwork);
            await _context.SaveChangesAsync();



            return RedirectToAction("ClassWorkUser", new { axusubject = auxxx});

        }














        public async Task<IActionResult> DeleteUserClasswork(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userclasswork = await _context.UserClassWorks.FirstOrDefaultAsync(m => m.Id == id);

            if (userclasswork == null)
            {
                return NotFound();
            }

            try
            {
                _context.UserClassWorks.Remove(userclasswork);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction("ClassWorkUser", new { axusubject = _MyGlobalVariable });

        }








        public static int globalfileuser;

        public async Task<IActionResult> EditUserClasswork(int? id)
        {




            //int auxxx = _MyGlobalVariable;
            //Subject subject = await _context.Subjects
            //    .Include(s => s.Classworks)
            //    .FirstOrDefaultAsync(f => f.Id == auxxx);


            //Classwork classwork = await _context.Classworks.FindAsync(id);


            //AddClassWorkViewModel model2 = new AddClassWorkViewModel
            //{

            //    Id = (int)id,
            //    Name = classwork.Name,
            //    FileId = classwork.FileId


            //};

            //UserClassWork userclasswork = await _context.UserClassWorks.Include(g => g.FileClassroom).FirstOrDefault(f => f.Id == id);
            IEnumerable<UserClassWork> userclasswork =  _context.UserClassWorks.Where(f => f.Id == id).Include(k => k.FileClassroom);

            string fileaux = "";
            foreach (var item in userclasswork)
            {
                if(item.FileClassroom.Id != 0)
                {
                    globalfileuser = item.FileClassroom.Id;
                    fileaux = item.FileClassroom.FileId;
                    break;
                }
            }


            AddmyfileClassworkViewModel model = new AddmyfileClassworkViewModel
            {
                Id = (int)id,
                FileId = fileaux

            };



            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUserClasswork(AddmyfileClassworkViewModel model1)
        {


            string filedId = "";
            if (model1.Myfile != null)
            {
                filedId = await _blobHelper.UploadBlob2Async(model1.Myfile, "files");
            }

            int auxxx = _MyGlobalVariable;


            //Classwork classwork = await _context.Classworks.FindAsync(classwork1.Id);
            //classwork.Name = classwork1.Name;
            //classwork.FileId = classwork1.Myfile.FileName;
            FileClassroom fileClassroom = await _context.FileClassrooms.FindAsync(globalfileuser);

            fileClassroom.FileId = model1.Myfile.FileName;
            fileClassroom.Name = model1.Name;
            _context.Update(fileClassroom);
            await _context.SaveChangesAsync();

            //UserClassWork userClassWork = await _context.UserClassWorks.FindAsync(model1.Id);
            //userClassWork.


            return RedirectToAction("ClassWorkUser", new { axusubject = auxxx });

        }










































































































        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> ChangeUserTeacher()
        {
            User user = await _userHelper.GetUserAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }


            Profession profession = await _context.Professions.FirstOrDefaultAsync(p => p.Users.FirstOrDefault(u => u.Id == user.Id) != null);
            if (profession == null)
            {
                profession = await _context.Professions.FirstOrDefaultAsync();
            }

            Subject subject = await _context.Subjects.FirstOrDefaultAsync(p => p.Id == user.IdSubject);
            if (subject == null)
            {
                subject = await _context.Subjects.FirstOrDefaultAsync();
            }

            if (user.UserType.ToString() == "Teacher")
            {
                aux2 = _context.Subjects.Where(s => s.Id == user.IdSubject).Select(t => new SelectListItem
                {

                    Text = t.Name,
                    Value = $"{t.Id}"
                }).OrderBy(t => t.Text)
                .ToList();



                aux = _context.Professions.Where(p => p.Name == "Proffesor").Select(t => new SelectListItem
                {

                    Text = t.Name,
                    Value = $"{t.Id}"
                }).OrderBy(t => t.Text)
                  .ToList();
            }
            else
            {
                user.IdSubject = 0;
                //subject.Name = "d";
                aux2 = _combosHelper.GetComboSubjects2(user.Id);
                aux = _combosHelper.GetComboProfessions2(user);
            }

            EditUserViewModel model = new EditUserViewModel
            {

                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                ImageId = user.ImageId,

                //Churches = _combosHelper.GetComboChurches(district.Id),
                //ChurchId = user.Church.Id,
                //Fields = _combosHelper.GetComboFields(),
                //FieldId = field.Id,
                //DistrictId = district.Id,
                //Districts = _combosHelper.GetComboDistricts(field.Id),
                IdSubject = user.IdSubject,
                Subjects = aux2,
                IdSubjectname = subject.Name,
                //Subjects = _combosHelper.GetComboSubjects2(user.Id),

                //Subjects =  _combosHelper.GetComboSubjects(),
                Professions = aux,

                ProfessionId = profession.Id,
                Id = user.Id,

                Document = user.Document


            }; ;


            return View(model);
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeUserTeacher(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                Guid imageId = model.ImageId;

                if (model.ImageFile != null)
                {
                    imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "users");
                }

                User user = await _userHelper.GetUserAsync(User.Identity.Name);

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Address = model.Address;
                user.PhoneNumber = model.PhoneNumber;
                user.ImageId = imageId;
                //user.Church = await _context.Churches.FindAsync(model.ChurchId);
                //user.UserSubjects = await _context.Churches.FindAsync(model.ChurchId);
                user.IdSubject = model.IdSubject;
                user.Profession = await _context.Professions.FindAsync(model.ProfessionId);
                user.Document = model.Document;


                await _userHelper.UpdateUserAsync(user);
                return RedirectToAction("Index", "Home");
            }



            //model.Fields = _combosHelper.GetComboFields();
            //model.Districts = _combosHelper.GetComboDistricts(model.FieldId);
            //model.Churches = _combosHelper.GetComboChurches(model.DistrictId);

            model.Subjects = _combosHelper.GetComboSubjects();
            model.Professions = aux;
            //model.Professions = _combosHelper.GetComboProfessions();
            return View(model);
        }



















































        public IActionResult ChangePasswordMVC()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePasswordMVC(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserAsync(User.Identity.Name);
                if (user != null)
                {
                    var result = await _userHelper.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("ChangeUser");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User no found.");
                }
            }

            return View(model);
        }



        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                return NotFound();
            }

            User user = await _userHelper.GetUserAsync(new Guid(userId));
            if (user == null)
            {
                return NotFound();
            }

            IdentityResult result = await _userHelper.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                return NotFound();
            }

            return View();
        }



        public IActionResult RecoverPasswordMVC()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RecoverPasswordMVC(RecoverPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userHelper.GetUserAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "The email doesn't correspont to a registered user.");
                    return View(model);
                }

                string myToken = await _userHelper.GeneratePasswordResetTokenAsync(user);
                string link = Url.Action(
                    "ResetPassword",
                    "Account",
                    new { token = myToken }, protocol: HttpContext.Request.Scheme);
                _mailHelper.SendMail(model.Email, "Password Reset", $"<h1>Password Reset</h1>" +
                    $"To reset the password click in this link:</br></br>" +
                    $"<a href = \"{link}\">Reset Password</a>");
                ViewBag.Message = "The instructions to recover your password has been sent to email.";
                return View();

            }

            return View(model);
        }

        public IActionResult ResetPassword(string token)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            User user = await _userHelper.GetUserAsync(model.UserName);
            if (user != null)
            {
                IdentityResult result = await _userHelper.ResetPasswordAsync(user, model.Token, model.Password);
                if (result.Succeeded)
                {
                    ViewBag.Message = "Password reset successful.";
                    return View();
                }

                ViewBag.Message = "Error while resetting the password.";
                return View(model);
            }

            ViewBag.Message = "User not found.";
            return View(model);
        }



        public async Task<IActionResult> DeleteProfession(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Profession profession = await _context.Professions
                .FirstOrDefaultAsync(p => p.Id == id);
            if (profession == null)
            {
                return NotFound();
            }

            _context.Professions.Remove(profession);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }




        

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult RegisterTeacher()
        {
            AddUserViewModel model = new AddUserViewModel
            {
 
                Subjects = _combosHelper.GetComboSubjects(),    
            //Professions = _combosHelper.GetComboProfessions()
            Professions = _context.Professions.Where(p => p.Name == "Proffesor").Select(t => new SelectListItem
                {

                    Text = t.Name,
                    Value = $"{t.Id}"
                }).OrderBy(t => t.Text)
                  .ToList()


             };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterTeacher(AddUserViewModel model)
        {
            System.Diagnostics.Debug.WriteLine("ENTRAAA EN RAGISTRAR PROFESOR ------------------------>" + UserType.Teacher.ToString());
            if (ModelState.IsValid)
            {
                Guid imageId = Guid.Empty;

                if (model.ImageFile != null)
                {
                    imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "users");
                }
                

                User user = await _userHelper.AddUserteacherAsync(model, imageId, UserType.Teacher);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "This email is already used.");
                    //model.Fields = _combosHelper.GetComboFields();
                    //model.Districts = _combosHelper.GetComboDistricts(model.FieldId);
                    //model.Churches = _combosHelper.GetComboChurches(model.DistrictId);
                    model.Subjects = _combosHelper.GetComboSubjects();
                    model.Professions = _context.Professions.Where(p => p.Name == "Proffesor").Select(t => new SelectListItem
                    {

                        Text = t.Name,
                        Value = $"{t.Id}"
                    }).OrderBy(t => t.Text)
                  .ToList();

                    return View(model);

                }

                string myToken = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                string tokenLink = Url.Action("ConfirmEmail", "Account", new
                {
                    userid = user.Id,
                    token = myToken
                }, protocol: HttpContext.Request.Scheme);

                Response response = _mailHelper.SendMail(model.Username, "Email confirmation", $"<h1>Email Confirmation</h1>" +
                    $"To allow the user, " +
                    $"plase click in this link:</br></br><a href = \"{tokenLink}\">Confirm Email</a>");
                if (response.IsSuccess)
                {
                    ViewBag.Message = "The instructions to allow your user has been sent to email.";
                    return View(model);
                }

                ModelState.AddModelError(string.Empty, response.Message);

            }

            //model.Fields = _combosHelper.GetComboFields();
            //model.Districts = _combosHelper.GetComboDistricts(model.FieldId);
            //model.Churches = _combosHelper.GetComboChurches(model.DistrictId);
            model.Subjects = _combosHelper.GetComboSubjects();
            model.Professions = _context.Professions.Where(p => p.Name == "Proffesor").Select(t => new SelectListItem
            {

                Text = t.Name,
                Value = $"{t.Id}"
            }).OrderBy(t => t.Text)
                  .ToList();
            return View(model);
        }













 



    }
}
