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

namespace GaragePortalNewUI.ViewModels.Engineer
{
    public class EngineerSpecialitiesViewModel
    {
        private readonly ResourceManager _resourceManager;

        public EngineerSpecialitiesViewModel(ResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public EngineerSpecialitiesViewModel()
        {

        }

        public long SpecialityID { get; set; }

        public string SpecialityDescription { get; set; }
    }
}