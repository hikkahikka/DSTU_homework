using System;
using System.Collections.Generic;
using System.Text;

namespace FP_lab2
{
    public record class EmailNotification : Notification
    {
        public required string EmailAddress { get; init; }
        public required string Subject { get; init; }
    }

}
