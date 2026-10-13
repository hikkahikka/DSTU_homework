using System;
using System.Collections.Generic;
using System.Text;

namespace FP_lab2
{
    public record class SmsNotification : Notification
    { 
        public required string PhoneNumber { get; init; } 
    }
}
