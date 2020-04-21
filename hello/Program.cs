using static System.Console;

namespace hello
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Hello World!");
            WriteLine("Hello Universes!");
            int i = 20;
            while(i > 0){
                WriteLine("test "+i);
                i--;
            }
            WriteLine("1 + 2 = "+addMe(1,2));
        }

        static public int addMe(int a, int b){
            return (a+b);
        }
    }
}
