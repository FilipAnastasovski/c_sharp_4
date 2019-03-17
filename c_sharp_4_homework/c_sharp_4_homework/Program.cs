using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string[] Messages { get; set; } = { "asd", "blabla", "potato" };

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }


    class Program
    {
        static string LogIn(string username, string password, User[] users)
        {
            foreach (User user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    string mesages = "";

                    foreach (string msg in user.Messages)
                    {
                        mesages += $"\n{msg}";
                    }
                    return $"Welcome {user.Username}. Here are your messages:{mesages}";
                }
            }
            return "user not here";
        }

        static string Register(string username, string password, ref User[] users)
        {
            foreach (User user in users)
            {
                if (user.Username == username)
                {
                    return "There is already a user called like that.";
                }
            }

            Array.Resize(ref users, users.Length + 1);
            users[users.Length - 1] = new User(username, password);

            string useri = "";
            foreach (User user in users)
            {
                useri += $"\n{user.Username}";
            }
            return $"Registration complete! Users:{useri}";
        }

        static void Main(string[] args)
        {
            User[] users = { new User("petko", "petko1"), new User("trajko", "trajko1"), new User("stanko", "stanko1") };
            while (true)
            {
                Console.WriteLine("Do you want to Log In or Register? \n1) Log In \n2) Register");
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    Console.WriteLine("Enter Username:");
                    string username = Console.ReadLine();
                    Console.WriteLine("Enter Password:");
                    string password = Console.ReadLine();
                    if (input == 1)
                    {
                        Console.WriteLine(LogIn(username, password, users));
                    }
                    else if (input == 2)
                    {
                        Console.WriteLine(Register(username, password, ref users));
                    }
                    else
                    {
                        Console.WriteLine("Did not entered 1 or 2.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Not a valid input.");
                    continue;
                }
            }
        }
    }
}