using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GaragePortalNewUI.Controllers;
using System.Globalization;
using GaragePortalNewUI.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Resources;
using System.Text.RegularExpressions;

namespace GaragePortalNewUI.Models
{
    public class UserViewModel
    {
        private readonly ResourceManager _resourceManager;

        public UserViewModel(ResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public UserViewModel()
        {
            
        }
        public long ID { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your surname.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Surname { get; set; }

        [Required]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        public string Email { get; set; }

        public string Password { get; set; }

        public long GarageID { get; set; }

        public long? UserType { get; set; }

        [Column(TypeName = "datetime")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? CreationDate { get; set; }

        [Column(TypeName = "datetime")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? ModifiedDate { get; set; }

        [Column(TypeName = "datetime")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? LastLoginDate { get; set; }

        public EnableAccess EnableAccess { get; set; }

        public byte[]? UserPhoto { get; set; }

        public string? EngineerSpeciality { get; set; }
    }
}