using System;
using System.Collections.Generic;
using System.Text;

namespace FP_lab2
{
    public record class PushNotification: Notification
    {
        public int DeviceId { get; init; }
        public required string AppName { get; init; }
    }
}
