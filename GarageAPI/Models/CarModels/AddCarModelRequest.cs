﻿namespace GarageAPI.Models.CarModels
{
    public class AddCarModelRequest
    {
        public string ModelName { get; set; }

        public long GarageID { get; set; }
    }
}
