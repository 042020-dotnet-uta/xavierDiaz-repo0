using System;

namespace SweetNsalty
{
    class Program
    {
        static void Main(string[] args)
        {
            int sweetC = 0;
            int saltC = 0;
            int sns = 0;
            for(int i = 1; i <= 100; i++){
                if(i % 3 == 0 && i % 5==0){
                    Console.WriteLine("sweet’nSalty");
                    sns++;
                }
                else if(i % 3 == 0 ){
                    Console.WriteLine("sweet");
                    sweetC++;
                }
                else if(i % 5 == 0){
                    Console.WriteLine("salty");
                    saltC++;
                }
                else{
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine($"There were {sweetC} sweets, {saltC} salties, and {sns} salty'N'Sweets");
        }
    }
}
