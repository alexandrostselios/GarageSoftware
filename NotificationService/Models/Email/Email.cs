﻿using System.ComponentModel.DataAnnotations.Schema;

namespace GarageNotificationService.Models.Email
{
    public class Email
    {
        public long SenderID { get; set; }

        public long ReceiverID { get; set; }

        [NotMapped]
        public string? Receiver { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public DateTime InsDate { get; set; }

        [ForeignKey("GarageDetails")]
        public long GarageID { get; set; }
    }
}
