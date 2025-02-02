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
using System.Collections.Generic;

namespace GaragePortalNewUI.ViewModels
{
    public class AddServiceAppointmentViewModel
    {
        public AddServiceAppointmentViewModel(){

        }

        public DateTime ServiceAppointmentDate { get; set; }

        public string ServiceAppointmentComments { get; set; }

        public ServiceAppointmentStatus ServiceAppointmentStatus { get; set; }

        public long CustomerID { get; set; }

        public long CustomerCarID { get; set; }

        public long Kilometer { get; set; }

        public long GarageID { get; set; }
    }
}