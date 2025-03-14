﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassroom.Common.Enums;
using VirtualClassroom.WEB.Data.Entities;
using VirtualClassroom.WEB.Models;

namespace VirtualClassroom.WEB.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<SignInResult> ValidatePasswordAsync(User user, string password);


        Task<User> AddUserAsync(AddUserViewModel model, Guid imageId, UserType userType);
        Task<User> AddUserteacherAsync(AddUserViewModel model, Guid imageId, UserType userType);
        
        Task addsubjectsAsync(User user, AddUserViewModel model);

        //Task getsubjectsAsync(AddUserViewModel model);


        //public async Task addsubjectsAsync(User user, AddUserViewModel model);

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<User> GetUserAsync(Guid userId);

        Task<string> GenerateEmailConfirmationTokenAsync(User user);

        Task<IdentityResult> ConfirmEmailAsync(User user, string token);

        Task<string> GeneratePasswordResetTokenAsync(User user);

        Task<IdentityResult> ResetPasswordAsync(User user, string token, string password);


    }

}
