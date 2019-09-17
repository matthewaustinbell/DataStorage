using DataStorage.Data;
using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var userRepository = new UserRepository();

            while (true)
            {
                Console.WriteLine("Enter the user's first name");
                var firstName = Console.ReadLine();

                Console.WriteLine("Enter the user's last name");
                var lastName = Console.ReadLine();

                Console.WriteLine("Enter the user's password");
                var password = Console.ReadLine();

                var user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password
                };

                userRepository.Add(user);

                Console.WriteLine("Would you like to add another? (y/n)");
                var response = Console.ReadLine();

                if (response != "y")
                {
                    break;
                }
            }

            var users = userRepository.GetAll()
                .Select(user => $"{user.FirstName} {user.LastName} has a password of {user.Password}");

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }
    }
}