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
            Console.Clear();
            int action = GetAction();
            PerformAction(action);
            if(GoAgain() == 1)
                goto Start;
            else
                Console.WriteLine("Have a nice day");
        }

        /// <summary>
        /// Determine if using goto start label
        /// </summary>
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

        /// <summary>
        /// directs program to correct method
        /// </summary>
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
        /// <summary>
        /// action one: used to make order
        /// </summary>
        public static void ActionOne()
        {
            Console.WriteLine("Ok lets make an order");
            Order o = new Order();
            o.MakeOder();
        }
        /// <summary>
        /// used to add new customer
        /// </summary>
        public static void ActionTwo()
        {
            Console.WriteLine("Ok lets add a new customer");
            Customer c = new Customer();
            c.WriteCustomer();
        }
        /// <summary>
        /// used to search for customer
        /// </summary>
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
        /// <summary>
        /// used to get order details
        /// </summary>
        public static void ActionFour()
        {
            Console.WriteLine("Ok lets see the details of an order");
            Order o = new Order();
            o.ShowSpecificOrder();
        }
        /// <summary>
        /// used to see all orders from specified store
        /// </summary>
        public static void ActionFive()
        {
            Console.WriteLine("Ok lets see the details of a stores orders");
            Order o = new Order();
            o.ShowStoreOrders();
        }
        /// <summary>
        /// used to see all orders of a customer
        /// </summary>
        public static void ActionSix()
        {
            Console.WriteLine("Ok lets see the details of a customars orders");
            Order o = new Order();
            o.ShowCustomerOrders();
        }
        /// <summary>
        /// Extra: used to see all stock
        /// </summary>
        public static void ActionSeven()
        {
            Console.WriteLine("Lets see what the stores have in stock");
            Location l = new Location();
            l.ShowInventory();
        }
        /// <summary>
        /// Extra: used to show all potential produts
        /// </summary>
        public static void ActionEight()
        {
            Console.WriteLine("Lets see all our products");
            Product p = new Product();
            p.ShowAllProducts();
        }
        /// <summary>
        /// used to get desired action from user
        /// </summary>
        public static int GetAction()
        {
            Console.WriteLine("Hello, please enter a number that coresponds to which action you'd like to take");
            Console.WriteLine("1) place order to store location for customer");
            Console.WriteLine("2) add new customer");
            Console.WriteLine("3) search customers by name");
            Console.WriteLine("4) display details of an order");
            Console.WriteLine("5) display all store orders");
            Console.WriteLine("6) display all orders of a customer");
            Console.WriteLine("7) display inventory of all stores");
            Console.WriteLine("8) display all item details");
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
