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

namespace GaragePortalNewUI.ViewModels.Customer
{
    public class CustomerLoginViewModel
    {
        public long CustomerID { get; set; }

        public long GarageID { get; set; }

        public DateTime? LastLoginDate { get; set; }
    }
}