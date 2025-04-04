﻿using System;
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
using GaragePortalNewUI.Models.EngineerSpeciality;

namespace GaragePortalNewUI.ViewModels.Engineer
{
    public class EngineerViewModel
    {
        private readonly ResourceManager _resourceManager;

        public EngineerViewModel(ResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public EngineerViewModel()
        {

        }

        public long? EngineerID { get; set; }

        public string EngineerSurname { get; set; }

        public string EngineerName { get; set; }

        public string EngineerEmail { get; set; }

        public string EngineerPassword { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public long GarageID { get; set; }

        public UserType UserType { get; set; }

        public EnableAccess EnableAccess { get; set; }

        public long? UserID { get; set; }

        public byte[] EngineerPhoto { get; set; }

        public string? EngineerHomePhone { get; set; }

        public string? EngineerMobilePhone { get; set; }

        public string? EngineerComment { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public List<long>? EngineerSpecialitiesID { get; set; }

        public List<EngineerSpeciality>? EngineerSpecialities { get; set; }
    }
}