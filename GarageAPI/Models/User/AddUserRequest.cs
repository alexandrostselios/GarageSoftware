﻿using GarageAPI.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Models.User { 
    public class AddUserRequest
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public long GarageID { get; set; }

        public UserType UserType { get; set; }

        public long? Speciality { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreationDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastLoginDate { get; set; }

        public EnableAccess EnableAccess { get; set; }

        public byte[]? UserPhoto { get; set; }
    }
}
