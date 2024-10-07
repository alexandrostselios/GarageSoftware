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

namespace GaragePortalNewUI.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        private readonly ResourceManager _resourceManager;

        public EmployeeViewModel(ResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public EmployeeViewModel()
        {

        }

        public long EmployeeID { get; set; }

        public string EmployeeSurname { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeEmail { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public long GarageID { get; set; }

        public long UserID { get; set; }

        public byte[]? EmployeePhoto { get; set; }

        public string? EmployeeHomePhone { get; set; }

        public string? EmployeeMobilePhone { get; set; }

        public string EmployeeComment { get; set; }

        public string EmployeePassword { get; set; }

        // Additional properties from Users table
        public EnableAccess EnableAccess { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public UserType UserType { get; set; }
    }
}