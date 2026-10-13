using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FP_lab2
{
    public static class NotificationUtils
    {
        public static string Format(Notification notification){
            string prefix = notification.Priority == NotificationPriority.Critical ? "[CRITICAL] " : "";
            return notification switch
            {
                EmailNotification email =>
                    $"{prefix}EMAIL to {email.EmailAddress}. Subject - {email.Subject}. Message - {email.Message}. Time - {email.Timestamp}", //time proverit
                SmsNotification sms =>
                    $"{prefix}SMS to {sms.PhoneNumber}. Message - {sms.Message}. Time - {sms.Timestamp}",
                PushNotification push =>
                    $"{prefix}PUSH. App - {push.AppName}. Title - {push.Title}. Message - {push.Message}. Time - {push.Timestamp}",
                _ => $"Priority - {notification.Priority}. Title - {notification.Title}. Message - {notification.Message}. Time - {notification.Timestamp}"
            };
        }
        public static string GetDestination(Notification notification) => notification switch
        {
            EmailNotification e => e.EmailAddress,
            SmsNotification s => s.PhoneNumber,
            PushNotification p => $"{p.AppName}:{p.DeviceId}",
            _ => "Unknown Destination"
        };
    }
}
