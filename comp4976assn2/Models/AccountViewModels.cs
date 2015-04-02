﻿using System;
using System.ComponentModel.DataAnnotations;

// New namespace imports:
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace comp4976assn2.Models
{

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public bool Inactive { get; set; }

        // Return a pre-poulated instance of AppliationUser:
        public ApplicationUser GetUser()
        {
            var user = new ApplicationUser()
            {
                UserName = this.UserName,
                Email = this.Email,
                Inactive = this.Inactive,
            };
            return user;
        }
    }

    public class EditRoleViewModel
    {
        public EditRoleViewModel() { }

        // Allow Initialization with an instance of IdentityRole:
        public EditRoleViewModel(IdentityRole role)
        {
            this.Role = role.Name;
        }

        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }

    }

    public class EditUserViewModel
    {
        public EditUserViewModel() { }

        // Allow Initialization with an instance of ApplicationUser:
        public EditUserViewModel(ApplicationUser user)
        {
            this.UserName = user.UserName;
            this.Email = user.Email;
            this.Inactive = user.Inactive;
        }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Must be an email address.")]
        public string Email { get; set; }

        [Display(Name = "Inactive")]
        public bool Inactive { get; set; }

    }


    public class SelectUserRolesViewModel
    {
        public SelectUserRolesViewModel()
        {
            this.Roles = new List<SelectRoleEditorViewModel>();
        }

        // Enable initialization with an instance of ApplicationUser:
        public SelectUserRolesViewModel(ApplicationUser user)
            : this()
        {
            this.UserName = user.UserName;

            var Db = new ApplicationDbContext();

            // Add all available roles to the list of EditorViewModels:
            var allRoles = Db.Roles;
            foreach (var role in allRoles)
            {
                // An EditorViewModel will be used by Editor Template:
                var rvm = new SelectRoleEditorViewModel(role);
                this.Roles.Add(rvm);
            }

            // Set the Selected property to true for those roles for 
            // which the current user is a member:
            foreach (var userRole in user.Roles)
            {
                var checkUserRole =
                    this.Roles.Find(r => r.RoleName == userRole.Role.Name);
                checkUserRole.Selected = true;
            }
        }

        public string UserName { get; set; }
        public List<SelectRoleEditorViewModel> Roles { get; set; }
    }

    // Used to display a single role with a checkbox, within a list structure:
    public class SelectRoleEditorViewModel
    {
        public SelectRoleEditorViewModel() { }
        public SelectRoleEditorViewModel(IdentityRole role)
        {
            if (role.Name == "Administrator")
            {
                Int32 count;
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    IdentityRole myRole = db.Roles.First(r => r.Name == "Administrator");
                    count = db.Set<IdentityUserRole>().Count(r => r.RoleId == myRole.Id);
                }
                this.RoleCount = count;
            }
            this.RoleName = role.Name;
        }

        public bool Selected { get; set; }

        [Required]
        public string RoleName { get; set; }

        public int RoleCount { get; set; }
    }
}