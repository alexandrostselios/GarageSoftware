﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageAPI.Data;
using GarageAPI.Models;

namespace GarageAPI.Controllers
{
    public class OutputsController : Controller
    {
        private readonly GarageAPIDbContext _context;

        public OutputsController(GarageAPIDbContext context)
        {
            _context = context;
        }
    }
}