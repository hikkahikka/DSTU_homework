using System;
using System.Collections.Generic;

namespace FP_lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var manager = new NotificationManager();

            manager.Subscribe(NotificationPriority.High, n =>
            {
                Console.WriteLine($"[Подписчик HIGH]: Получено уведомление. {n.Title}");
            });

            manager.Subscribe(NotificationPriority.Critical, n =>
            {
                Console.WriteLine($"[Подписчик CRITICAL]: Получено уведомление! ID: {n.Id}");
            });

            manager.NotificationFilter += n =>
            {
                if (n.Message.Contains("SPAM"))
                {
                    return false;
                }
                return true;
            };

            manager.NotificationSent += n =>
            {
                Console.WriteLine($"Событие NotificationSent: {NotificationUtils.Format(n)}");
            };
            manager.CriticalNotificationReceived += n =>
            {
                Console.WriteLine("СРАБОТАЛО СОБЫТИЕ КРИТИЧЕСКОГО ОПОВЕЩЕНИЯ");
            };

            var criticalEmailFactory = NotificationFactory.CreateEmailFactory(NotificationPriority.Critical);
            var normalSmsFactory = NotificationFactory.CreateSmsFactory(NotificationPriority.Normal);

            var email = criticalEmailFactory("admin@test.com", "Security Alert", "Unauthorized access detected!");
            var sms = normalSmsFactory("+79991234567", "Your code is 1234");
            var spamSms = normalSmsFactory("+79990000000", "BUY SPAM ");

            manager.Send(email);
            Console.WriteLine();

            manager.Send(sms);
            Console.WriteLine();

            manager.Send(spamSms); 
            Console.WriteLine();


            Console.WriteLine("(Format & GetDestination)");
            Console.WriteLine($"Формат: {NotificationUtils.Format(email)}");
            Console.WriteLine($"Маршрут (Destination): {NotificationUtils.GetDestination(email)}");

            Console.WriteLine("LINQ");

            var counts = manager.GetCountByPriority();
            Console.WriteLine("Количество по приоритетам:");
            foreach (var pair in counts)
            {
                Console.WriteLine($"  {pair.Key}: {pair.Value}");
            }

            var recent = manager.GetRecentNotifications(TimeSpan.FromMinutes(5));
            Console.WriteLine($"Уведомлений за последние 5 минут: {recent.Count()}");

            var grouped = manager.GroupByType();
            Console.WriteLine("Группировка по типам:");
            foreach (var group in grouped)
            {
                Console.WriteLine($"  Тип: {group.Key.Name}, Кол-во: {group.Count()}");
            }

            double avg = manager.GetAverageNotificationsPerHour(DateTime.Now.AddHours(-1), DateTime.Now.AddMinutes(1));
            Console.WriteLine($"Среднее кол-во в час: {avg:F2}");
        }
    }
}