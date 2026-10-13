using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.WebSockets;
using System.Text;

namespace FP_lab2
{
    public class NotificationManager
    {
        public List<Notification> NotificationHistory { get; } = new();
        public Dictionary<NotificationPriority, List<Action<Notification>>> Subscribers { get; } = new();
        public event Action<Notification>? NotificationSent;
        public event Action<Notification>? CriticalNotificationReceived;
        public event Func<Notification, bool>? NotificationFilter;
        public void Subscribe(NotificationPriority priority, Action<Notification> handler)
        {
            if (!Subscribers.ContainsKey(priority))
            {
                Subscribers[priority] = new List<Action<Notification>>();
            }
            Subscribers[priority].Add(handler);
        }
        public void Unsubscribe(NotificationPriority priority, Action<Notification> handler)
        {
            if (Subscribers.ContainsKey(priority))
            {
                Subscribers[priority].Remove(handler);
            }
        }
        public void Send(Notification notification)
        {
            if (NotificationFilter != null)
            {
                foreach(Func<Notification, bool> filter in NotificationFilter.GetInvocationList())
                {
                    if (!filter(notification))
                    {
                        Console.WriteLine($"Notification {notification.Title} decline by a filter");
                        return;
                    }
                }
            }
            NotificationHistory.Add(notification);
            if (notification.Priority == NotificationPriority.Critical) CriticalNotificationReceived?.Invoke(notification);
            if(Subscribers.TryGetValue(notification.Priority, out List<Action<Notification>>? handlers))
            {
                foreach (Action<Notification> handler in handlers)
                {
                    ProcessNotification(notification, handler);
                }
            }
            NotificationSent?.Invoke(notification);

        }
        public void ProcessNotification(Notification notification, Action<Notification> handler)
        {
            handler(notification);
        }
        public List<Notification> GetNotifications(Func<Notification, bool> condition)
        {
            return NotificationHistory.Where(condition).ToList();
        }
        public Dictionary<NotificationPriority, int> GetCountByPriority()
        {
            return NotificationHistory.GroupBy(n => n.Priority).ToDictionary(g=>g.Key, g=>g.Count());
        }
        public IEnumerable<Notification> GetRecentNotifications(TimeSpan period)
        {
            var p = DateTime.Now - period;
            return NotificationHistory.Where(n => n.Timestamp >= p);
        }
        public IEnumerable<IGrouping<Type, Notification>> GroupByType()
        {
            return NotificationHistory.GroupBy(n => n.GetType());
        }
        public double GetAverageNotificationsPerHour(DateTime start, DateTime end)
        {
            var hours = (end - start).TotalHours;
            return NotificationHistory.Where(n => (n.Timestamp >= start && n.Timestamp <= end)).Count() / hours;
        }
    }
}
