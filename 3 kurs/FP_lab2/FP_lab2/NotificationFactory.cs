using System;
using System.Collections.Generic;
using System.Text;

namespace FP_lab2
{
    public static class NotificationFactory
    {
        public static Func<string, string, string, EmailNotification> CreateEmailFactory(NotificationPriority priority)
        {
            return (email, subject, message) => new EmailNotification {
                Id= Random.Shared.Next(1, 10000),
                Type= 1,
                Title= "Email",
                Message= message,
                Timestamp= DateTime.Now,
                Priority= priority,
                EmailAddress= email,
                Subject= subject
            };
        }

        public static Func<string, string, SmsNotification> CreateSmsFactory(NotificationPriority priority)
        {
            return (phone, message) => new SmsNotification {
                Id= Random.Shared.Next(1, 10000),
                Type= 2,
                Title= "SMS",
                Message= message,
                Timestamp= DateTime.Now,
                Priority= priority,
                PhoneNumber= phone
            };
        }

        public static string CreateFromTemplate(string template, Dictionary<string, string> parameters)
        {
            string result = template;
            foreach (var param in parameters)
            {
                result = result.Replace($"{{{param.Key}}}", param.Value);
            }
            return result;
        }
    }
}
