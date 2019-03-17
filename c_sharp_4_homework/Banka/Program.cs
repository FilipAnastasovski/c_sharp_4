using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{

    class User
    {
        public string Name { get; set; }
        public long CardNumber { get; set; }
        private string Pin { get; set; }
        private int Balance { get; set; }

        public User(string name, long cardNum, string pin, int balance = 0)
        {
            Name = name;
            CardNumber = cardNum;
            Pin = pin;
            Balance = balance;
        }

        public string GetPin()
        {
            return Pin;
        }

        public int GetBalance()
        {
            return Balance;
        }

        public void SetBalance(int number)
        {
            Balance = number;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            User[] users = { new User("bob", 1234123412341234, "1234"), new User("mark", 4321432143214321, "4321"), new User("marry", 9876987698769876, "9876") };

            while (true)
            {
                User selectedUser = null;
                Console.WriteLine("Do you want to Log In or Register? \n 1. Log In \n 2. Register");
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input == 1) 
                    {
                        bool cardFound = false;
                        Console.WriteLine("Enter Card Number:");
                        string cardInput = string.Join("", Console.ReadLine().Split('-'));
                        bool result = long.TryParse(cardInput, out long cardNumber);

                        if (!result)
                        {
                            Console.WriteLine("Not valid card number");
                            continue;
                        }

                        foreach (User user in users)
                        {
                            if (user.CardNumber == cardNumber)
                            {
                                Console.WriteLine("Card number is acepted.");
                                cardFound = true;
                                int counter = 0;
                                while (counter < 3)
                                {
                                    Console.WriteLine("Enter PIN:");
                                    string pin = Console.ReadLine();
                                    if (user.GetPin() == pin)
                                    {
                                        Console.WriteLine(" PIN acepted.");
                                        selectedUser = user;
                                        Console.WriteLine($"Hello {user.Name}");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("PIN incorrect.");
                                        Console.WriteLine($"You have {2 - counter} more chances before shut down.");
                                        counter++;
                                        if (counter == 3)
                                        {
                                            Console.WriteLine("Max chances reached.");
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                        if (!cardFound)
                        {
                            Console.WriteLine("Card does not exist.");
                            continue;
                        }
                        while (true) 
                        {
                            Console.WriteLine("What do you want to do?: \n 1. Check Balance \n 2. Cash Withdrawal \n 3. Cash Deposit");
                            if (int.TryParse(Console.ReadLine(), out int number))
                            {
                                if (number == 1) 
                                {
                                    Console.WriteLine($"Balance: {selectedUser.GetBalance()}");
                                }
                                else if (number == 2) 
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("How much cash do you want to withdraw?");
                                        if (int.TryParse(Console.ReadLine(), out int cash))
                                        {
                                            if (cash > selectedUser.GetBalance())
                                            {
                                                Console.WriteLine("you don't have that much i your acc.");
                                                break;
                                            }
                                            else
                                            {
                                                selectedUser.SetBalance(selectedUser.GetBalance() - cash);
                                                Console.WriteLine($"Withdrawed {cash}$ from your balance.");
                                                Console.WriteLine($"Balance: {selectedUser.GetBalance()}");
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Not a valid input.");
                                            continue;
                                        }
                                    }
                                }
                                else if (number == 3) 
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("How much cash do you want to deposit?");
                                        if (int.TryParse(Console.ReadLine(), out int cashDeposit))
                                        {
                                            selectedUser.SetBalance(selectedUser.GetBalance() + cashDeposit);
                                            Console.WriteLine($"Added {cashDeposit}$ from your balance.");
                                            Console.WriteLine($"Balance: {selectedUser.GetBalance()}");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Not a valid input.");
                                            continue;
                                        }
                                    }
                                }
                            }
                            
                            Console.WriteLine("Do you want to do another action? (Y/N)");
                            if (Console.ReadLine().ToLower() == "n")
                            {
                                return;
                            }
                        }
                    }
                    else if (input == 2) 
                    {
                        Console.WriteLine("Enter Name");
                        string name1 = Console.ReadLine();

                        Console.WriteLine("Enter Card Number");
                        string cardInput1 = string.Join("", Console.ReadLine().Split('-'));
                        bool result = long.TryParse(cardInput1, out long cardNumber1);

                        Console.WriteLine("Enter Pin");
                        string pin1 = Console.ReadLine();

                        Console.WriteLine("Do you want to deposit money? (Y/N)");
                        if (Console.ReadLine().ToLower() == "y")
                        {
                            while (true)
                            {
                                Console.WriteLine("Enter money:");
                                if (int.TryParse(Console.ReadLine(), out int balance1))
                                {
                                    Array.Resize(ref users, users.Length + 1);
                                    users[users.Length - 1] = new User(name1, cardNumber1, pin1, balance1);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Not a valid input.");
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            Array.Resize(ref users, users.Length + 1);
                            users[users.Length - 1] = new User(name1, cardNumber1, pin1);
                        }
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