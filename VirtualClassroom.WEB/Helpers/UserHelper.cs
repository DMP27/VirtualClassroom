using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassroom.Common.Enums;
using VirtualClassroom.WEB.Data;
using VirtualClassroom.WEB.Data.Entities;
using VirtualClassroom.WEB.Models;

namespace VirtualClassroom.WEB.Helpers
{
    public class UserHelper : IUserHelper
    {


        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public UserHelper(DataContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }


        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _context.Users
                //.Include(u => u.Church)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<SignInResult> ValidatePasswordAsync(User user, string password)
        {
            return await _signInManager.CheckPasswordSignInAsync(user, password, false);
        }





        public async Task<User> AddUserAsync(AddUserViewModel model, Guid imageId, UserType userType)
        {
            //Console.WriteLine("LLEGA USERTYPE ------------------------>" + userType.ToString());


            //System.Diagnostics.Debug.WriteLine("PRUEBA subjectsssssss ------------------------>" + model.SubjectId);
            //System.Diagnostics.Debug.WriteLine("PRUEBA subjectsssssss ------------------------>" + model.ProfessionId);

            User user = new User
            {
                
                Address = model.Address,
                Document = model.Document,
                Email = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ImageId = imageId,
                PhoneNumber = model.PhoneNumber,
                //Church = await _context.Churches.FindAsync(model.ChurchId),
                //UserSubjects = (ICollection<UserSubject>)model.Subjects,
                //UserSubjects = (ICollection<UserSubject>)await _context.UserSubjects.FindAsync(model.Subjects),
                //UserSubjects = model.SubjectId.ToArray().Count(),
                UserName = model.Username,
                UserType = userType,
                Profession = await _context.Professions.FindAsync(model.ProfessionId),

            };

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result != IdentityResult.Success)
            {
                return null;
            }

            User newUser = await GetUserAsync(model.Username);
            await AddUserToRoleAsync(newUser, user.UserType.ToString());

            await addsubjectsAsync(user, model);
            return newUser;
        }




        public async Task addsubjectsAsync(User user , AddUserViewModel model)
        {

            /*
             *  Field field = await _context.Fields
                    .Include(f => f.Districts)
                    .FirstOrDefaultAsync(f => f.Id == district.IdField);
                if (field == null)
                {
                    return NotFound();
                }

                try
                {
                    district.Id = 0;
                    field.Districts.Add(district);
                    _context.Update(field);
                    await _context.SaveChangesAsync();
             */
            for (int i = 0; i <= 2; i++)
            {
                Subject subject = await _context.Subjects
                .Include(s => s.UserSubjects)
                .FirstOrDefaultAsync(f => f.Id == model.SubjectId[i]);

                subject.UserSubjects.Add(new UserSubject
                {
                    User = await _context.Users.FindAsync(user.Id)
                });

                _context.Update(subject);
                await _context.SaveChangesAsync();
                //field.Districts.Add(district);
                //_context.Update(field);
                //await _context.SaveChangesAsync();
            }

            //_context.Subjects.u

            //_context.Subjects.Add(new Subject
            //    {

            //        Name = "Math",

            //        UserSubjects = new List<UserSubject>
            //        {
            //                            new UserSubject {
            //                                               User = await _context.Users.FindAsync(user.Id) },

            //        }



            //    });
            //    _context.Subjects.Add(new Subject
            //    {
            //        Name = "Chemistry",
            //        UserSubjects = new List<UserSubject>
            //        {
            //                            new UserSubject {
            //                                               User = await _context.Users.FindAsync("600") },


            //        }
            //    });
            //    _context.Subjects.Add(new Subject
            //    {
            //        Name = "English"

            //    });
                //await _context.SaveChangesAsync();         

        }








        public async Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            return await _userManager.UpdateAsync(user);
        }



        //with this method we can get user info
        //in this case we are dragging only users but users and churches
        public async Task<User> GetUserAsync(Guid userId)
        {
            return await _context.Users
                //.Include(u => u.Church)
                .FirstOrDefaultAsync(u => u.Id == userId.ToString());
        }


        public async Task<IdentityResult> ConfirmEmailAsync(User user, string token)
        {
            return await _userManager.ConfirmEmailAsync(user, token);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }




        public async Task<string> GeneratePasswordResetTokenAsync(User user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<IdentityResult> ResetPasswordAsync(User user, string token, string password)
        {
            return await _userManager.ResetPasswordAsync(user, token, password);
        }


    }

}
