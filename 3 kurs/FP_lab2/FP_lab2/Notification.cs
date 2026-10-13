using System;
using System.Collections.Generic;
using System.Text;

namespace FP_lab2
{
    public record class Notification
    {
        public int Id { get; init; }
        public int Type { get; init; }
        public required string Title { get; init; }
        public required string Message { get; init; }
        public DateTime Timestamp { get; init; }
        public NotificationPriority Priority { get; init; }
    }
}
