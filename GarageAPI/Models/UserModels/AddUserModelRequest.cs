﻿using GarageAPI.Models.CarEngineTypes;

namespace GarageAPI.Models.UserModels
{
    public class AddUserModelRequest
    {
        public long id { get; set; }

        public long UserID { get; set; }

        public string LicencePlate { get; set; }

        public string VIN { get; set; }

        public long Color { get; set; }

        public long Kilometer { get; set; }

        public long ModelManufacturer { get; set; }

        public long Model { get; set; }

        public long ModelYear { get; set; }

        public byte[]? CarImage { get; set; }

        public long EngineTypeID { get; set; }
    }
}
