using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProjectZero
{
    class Program
    {
        static void Main(string[] args)
        {
            Start:
            int action = GetAction();
            PerformAction(action);
            if(GoAgain() == 1)
                goto Start;
            else
                Console.WriteLine("Have a nice day");
        }

        public static int GoAgain()
        {
            Console.WriteLine();
            Console.Write("want to continue? (y/n)>> ");
            Console.WriteLine();
            while (true)
            {
                string InP = Console.ReadLine();
                if (InP == "y")
                    return 1;
                else if (InP == "n")
                    return 0;
                else
                {
                    Console.Write("Invalid try again >> ");
                    continue;
                }
            }
        }

        public static void PerformAction(int action)
        {
            // All this does is calls the desired action
            switch (action)
            {
                case 1:
                    ActionOne();
                    break;
                case 2:
                    ActionTwo();
                    break;
                case 3:
                    ActionThree();
                    break;
                case 4:
                    ActionFour();
                    break;
                case 5:
                    ActionFive();
                    break;
                case 6:
                    ActionSix();
                    break;
                case 7:
                    ActionSeven();
                    break;
                case 8:
                    ActionEight();
                    break;
                default:
                    Console.WriteLine("whaaaa how did you do this?");
                    break;
            }
        }
        public static void ActionOne()
        {
            Console.WriteLine("welcome to action one");
        }
        public static void ActionTwo()
        {
            Console.WriteLine("Ok lets add a new customer");
            Customer c = new Customer();
            c.WriteCustomer();
        }
        public static void ActionThree()
        {
            Console.WriteLine("Ok lets search for a customer");
            Customer c = new Customer();
            Console.WriteLine("Search with ID number or first name, last name? enter 'id' or 'name' | id recommended ");
            Console.Write(">> ");
            while (true)
            {
                string inP = Console.ReadLine();
                if (inP == "id")
                {
                    c.SearchCustomer(0);
                    break;
                }
                else if ( inP == "name")
                {
                    c.SearchCustomer(1);
                    break;
                }
                else
                {
                    Console.Write("Invalid - try again >> ");
                    continue;
                }
            }
        }
        public static void ActionFour()
        {
            Console.WriteLine("welcome to action four");
        }
        public static void ActionFive()
        {
            Console.WriteLine("welcome to action five");
        }
        public static void ActionSix()
        {
            Console.WriteLine("welcome to action six");
        }
        public static void ActionSeven()
        {
            Console.WriteLine("welcome to action seven");
        }
        public static void ActionEight()
        {
            Console.WriteLine("welcome to action eight");
        }

        public static int GetAction()
        {
            Console.WriteLine("Hello, please enter a number that coresponds to which action you'd like to take");
            Console.WriteLine("1 -> place order to store location for customer");
            Console.WriteLine("2 -> add new customer");
            Console.WriteLine("3 -> search customers by name");
            Console.WriteLine("4 -> display details of an order");
            Console.WriteLine("5 -> display all store orders");
            Console.WriteLine("6 -> display all orders of a customer");
            Console.WriteLine("7 -> display available inventory by store");
            Console.WriteLine("8 -> display all item details");
            while (true)
            {
                Console.Write(">> ");
                string act = Console.ReadLine();
                switch (act)
                {
                    case "1":
                        return 1;
                    case "2":
                        return 2;
                    case "3":
                        return 3;
                    case "4":
                        return 4;
                    case "5":
                        return 5;
                    case "6":
                        return 6;
                    case "7":
                        return 7;
                    case "8":
                        return 8;
                    default:
                        Console.WriteLine("invalid entry, please try again");
                        break;

                }
            }
        }
    }
}
