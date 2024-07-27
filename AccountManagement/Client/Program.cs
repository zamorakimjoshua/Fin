using ClassroomManagementData;
using ClassroomManagementModels;
using ClassroomManagementServices;
using System;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool active = true;
            UserGetServices userGetServices = new UserGetServices();
            UserTransactionServices userTransactionServices = new UserTransactionServices();

            while (active)
            {

                Console.WriteLine("Classroom Reservation");
                Console.WriteLine("1. Reservation?");
                Console.WriteLine("2. Already Done?");
                Console.WriteLine("3. Occupied Rooms");
                Console.WriteLine("4. Exit");

                Console.WriteLine("Enter the number:");
                string number = Console.ReadLine();

                switch (number)
                {
                    case "1":
                        Console.WriteLine("Who is the Professor?");
                        string prof = Console.ReadLine();

                        Console.WriteLine("What is the room number?");
                        string roomNum = Console.ReadLine();

                        User newUser = new User { prof = prof, roomNum = roomNum, status = "settled" };
                        userTransactionServices.CreateUser(newUser);
                        Console.WriteLine("Keep the room clean Please!");
                        break;

                    case "2":
                        Console.WriteLine("who is the Professor?");
                        string unregisterIgn = Console.ReadLine();

                        User userToDelete = new User { prof = unregisterIgn };
                        userTransactionServices.DeleteUser(userToDelete);
                        Console.WriteLine("Hope you clean the room!");
                        break;

                    case "3":
                        Console.WriteLine("Here is the List:");
                        DisplayUsers(userGetServices.GetAllUsers());
                        break;

                    case "4":
                        active = false;
                        break;

                    default:
                        Console.WriteLine("ERROR: Invalid input, please try again.");
                        break;
                }
            }
        }

        public static void DisplayUsers(List<User> users)
        {
            foreach (var item in users)
            {
                Console.WriteLine($"Professor: {item.prof}, Room Number: {item.roomNum}, Status: {item.status}");
            }
        }
    }
}
