using System;
using System.Collections.Generic;

namespace CodingChallengeWeek3
{
    class Program
    {
        static void Main(string[] args)
        {
            //while loop to start again if desired
            while (true)
            {
                string action = FuncChoose();//returns one two or three to indicate what they chose
                if (action == "one")
                    IsEven();
                else if (action == "two")
                    MultTable();
                else if (action == "three")
                    Shuffle();
                else
                {
                    Console.WriteLine("error");// in case it somehow gets this far
                }
                Console.Write("Go again? (y/n) >> ");//check to see if they want to go again
                string c = Console.ReadLine();
                if (c == "y")
                    continue;
                else if (c == "n")
                    break;
                else
                {
                    Console.WriteLine("Didn't enter y or n so just going to stop");
                    break;
                }
            }

        }

        public static string FuncChoose()//returns a string that main uses to direct user to wanted function
        {
            Console.WriteLine("Choose an action");
            Console.WriteLine("Enter -> 1 for IsEven, 2 for MultTable, 3 for Shuffle");
            while (true)
            {
                Console.Write(">> ");
                string choice = Console.ReadLine();
                if (choice == "1")
                    return "one";
                else if (choice == "2")
                    return "two";
                else if (choice == "3")
                    return "three";
                else
                {
                    Console.WriteLine("Invalid input try again");//keeps running till it gets what it wants
                    continue;
                }
            }

        }

        public static void Shuffle()
        {
            //init both lists and the list they combine into
            var one = new List<string>();
            var two = new List<string>();
            var combined = new List<string>();
            int count = 1;
            while(one.Count < 5)//get values for first list
            {
                Console.Write($"Please enter element {count} of set 1 >>");
                string val = Console.ReadLine();
                if (string.IsNullOrEmpty(val))
                {
                    Console.WriteLine("please enter something");//input has to be something, not empty or null
                    continue;
                }
                one.Add(val);
                count++;
            }
            count = 1;
            while (two.Count < 5)// populating list 2 like loop above
            {
                Console.Write($"Please enter element {count} of set 2 >>");
                string val = Console.ReadLine();
                if (string.IsNullOrEmpty(val))
                {
                    Console.WriteLine("please enter something");
                    continue;
                }
                two.Add(val);
                count++;
            }
            for (int i = 0; i < 5; i++)//combining list to desired effect
            {
                combined.Add(one[i]);
                combined.Add(two[i]);
            }
            //print it
            Console.WriteLine($"Input Shuffled: [{combined[0]},{combined[1]},{combined[2]},{combined[3]},{combined[4]},{combined[5]},{combined[6]},{combined[7]},{combined[8]},{combined[9]}]");
        }
        public static void IsEven()
        {
            int InNum;
            Console.Write("Enter an integer value >> ");
            string InP = Console.ReadLine();
            if (int.TryParse(InP, out InNum))//if it's supplied with an int evaluate
            {
                if (InNum % 2 == 0)// if % 2 == 0 then it must be even
                {
                    Console.WriteLine($"{InP} is an even number");
                }
                else
                {
                    Console.WriteLine($"{InP} is not an even number");
                }
            }
            else//if not parsed it wasn't an integer
            {
                Console.WriteLine($"{InP} is not an integer value");
            }
        }

        public static void MultTable()
        {
            Console.Write("Enter an Integer >> ");
            int InNum;
            while (true)//all this is to make sure an integer was actually entered, otherwise ask again
            {
                string InP = Console.ReadLine();
                if (int.TryParse(InP, out InNum))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid Integer >> ");
                }
            }
            //calculate and print out the multiplication table
            for (int i = 1; i <= InNum; i++)
            {
                for (int j = 1; j <= InNum; j++)
                {
                    Console.WriteLine($"{i} X {3} = {i * j}");
                }
            }
        }
    }
    
}
