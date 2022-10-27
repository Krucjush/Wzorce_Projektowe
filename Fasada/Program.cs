
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WzorzecFasada
{

    interface IUserService
    {
        void CreateUser(string email);
        void DeleteUser(string email);
        string Count();
    }

    static class EmailNotification
    {
        public static void SendEmail(string to, string subject)
        {
            Console.WriteLine($"{subject} {to}");
        }
    }

    class UserRepository
    {
        private readonly List<string> users = new List<string>
        {
            "john.doe@gmail.com", "sylvester.stallone@gmail.com"
        };

        public bool IsEmailFree(string email)
        {
            if (users.Contains(email))
            {
                return false;
            }
            return true;
        }

        public void AddUser(string email)
        {
            users.Add(email);
        }
        public void DeleteUser(string email)
        {
            users.Remove(email);
        }
        public int Count()
        {
            return users.Count;
        }

    }

    static class Validators
    {
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase);
        }
    }

    class UserService : IUserService
    {
        private readonly UserRepository userRepository = new UserRepository();
        public void CreateUser(string email)
        {
            if (!Validators.IsValidEmail(email))
            {
                throw new ArgumentException("Błędny email");
            }

            if (!userRepository.IsEmailFree(email))
            {
                throw new ArgumentException("Zajęty email");
            }
            // TODO: dodaj sprawdzenie czy email jest wolny, jeśli nie to wyrzuć wyjątek, jeśli tak, kontynuuj wykonywanie funkcji

            userRepository.AddUser(email);
            EmailNotification.SendEmail(email, "Welcome to our service");
        }
        public void DeleteUser(string email)
        {
            if (userRepository.IsEmailFree(email))
            {
                throw new ArgumentException("Użytkownik nie istnieje");
            }
            userRepository.DeleteUser(email);
            EmailNotification.SendEmail(email, "Goodbye");
        }
        public string Count()
        {
            return $"Aktualna liczba adresów: {userRepository.Count()}";
        }
            
    }

    class Program
    {
        static void Main(string[] args)
        {
            IUserService userService = new UserService();
            Console.WriteLine(userService.Count());
            userService.CreateUser("someemail@gmail.com");
            Console.WriteLine(userService.Count());
            userService.DeleteUser("john.doe@gmail.com");
            Console.WriteLine(userService.Count());
        }
    }

}