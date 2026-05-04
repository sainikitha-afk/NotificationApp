using NotificationApp.Models;
using NotificationApp.Services;
using NotificationApp.Interfaces;

namespace NotificationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;

            while (flag)
            {
                // create user object
                User user = new User();

                Console.WriteLine("Enter your name:");
                user.Name = Console.ReadLine() ?? "";
                while (string.IsNullOrWhiteSpace(user.Name))
                {
                    Console.WriteLine("Invalid name, enter again.");
                    user.Name = Console.ReadLine() ?? "";
                }

                Console.WriteLine("Enter your email:");
                user.Email = Console.ReadLine() ?? "";
                while (string.IsNullOrWhiteSpace(user.Email))
                {
                    Console.WriteLine("Invalid email, enter again;");
                    user.Email = Console.ReadLine() ?? "";
                }

                Console.WriteLine("Enter your phone number:");
                user.Phone = Console.ReadLine() ?? "";
                while (string.IsNullOrWhiteSpace(user.Phone) || user.Phone.Length != 10 || !user.Phone.All(char.IsDigit))
                {
                    Console.WriteLine("Invalid ph no. Enter again:");
                    user.Phone = Console.ReadLine() ?? "";
                }

                // create notification object
                Notification notification = new Notification();

                Console.WriteLine("Enter message to send:");
                notification.Message = Console.ReadLine() ?? "";
                while (string.IsNullOrWhiteSpace(notification.Message))
                {
                    Console.WriteLine("Please enter valid messsage:");
                    notification.Message = Console.ReadLine() ?? "";
                }

                notification.SentDate = DateTime.Now;

                // to ask user how they want to receive notification
                Console.WriteLine("\nChoose notification type:");
                Console.WriteLine("1. Email");
                Console.WriteLine("2. SMS");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
                {
                    Console.WriteLine("Invalid choice. Enter 1 or 2:");
                }

                // create service
                NotificationService service = new NotificationService();

                // ref of interface type (polymorphism)
                INotification notifier;

                // choice which notification to use
                if (choice == 1) {
                    notifier = new EmailNotification();
                }
                else if (choice == 2) {
                    notifier = new SMSNotification();
                }
                else {

                    Console.WriteLine("Invalid Choice entered!");
                    return;
                }

                // send notification
                service.SendNotification(notifier, user, notification);

                Console.WriteLine("\nNotification sent successfully!");
            
                Console.WriteLine("\nDo you want to send another notification? (y/n)");
                string again = Console.ReadLine() ?? "";

                if (again.ToLower() != "y")
                {
                    flag = false;
                    Console.WriteLine("Exited");
                }
        }
    }
}
}