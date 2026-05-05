using GaragePortalNewUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GaragePortalNewUI.ViewModels
{
    public class DashboardViewModel
    {
        public List<ServiceAppointmentViewModel> ServiceAppointments { get; set; }
    }
}