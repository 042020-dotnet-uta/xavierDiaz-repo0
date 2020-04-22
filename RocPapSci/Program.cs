using System;
using System.Collections.Generic;
namespace RocPapSci
{
    class Program
    {
        static void Main(string[] args)
        {
            //get the names of the players
            string pOneN;
            string pTwoN;
            Console.Write("Please enter name for Player one: ");
            pOneN = Console.ReadLine();
            Console.Write("Please enter name for Player two: ");
            pTwoN = Console.ReadLine();

            //create storage for player scores
            int pOneS = 0;
            int pTwoS = 0;

            //create list of arrays to store game round data
            List<string[]> round_data = new List<string[]>();
            Random rand = new Random();

            while(pOneS < 2 && pTwoS < 2){
                //generate random play, decide winner till one gets 2 wins
                int randOne = rand.Next(3);
                int randTwo = rand.Next(3);
                string OnePlay = played(randOne);
                string TwoPlay = played(randTwo);
                int win = winner(randOne, randTwo);
                if(win == 0){
                    round_data.Add(new string[] {OnePlay, TwoPlay, pOneN});
                    pOneS++;
                }
                else if(win == 1){
                    round_data.Add(new string[] {OnePlay, TwoPlay, pTwoN});
                    pTwoS++;
                }
                else{
                    round_data.Add(new string[] {OnePlay, TwoPlay, "tie"});
                }
            }
            //print out the game records
            //int sizeL;
            //sizeL = round_data.Count;
            int tieCount = 0;
            for(int i = 0; i < round_data.Count; i++){
                if(round_data[i][2] == "tie"){
                    tieCount++;
                }
                Console.WriteLine("round "+i+": "+pOneN+" played "+round_data[i][0]+", "+pTwoN+" played "+round_data[i][1]+" the winner was "+round_data[i][2]);
            }
            //state who won
            if(pOneS == 2){//p1 win
                Console.WriteLine("The winner was "+pOneN+" with "+pOneS+"-"+pTwoS+" and "+tieCount+" ties!");
            }
            else{
                Console.WriteLine("The winner was "+pTwoN+" with "+pTwoS+"-"+pOneS+" and "+tieCount+" ties!");
            }
        }

        static public string played(int rps){
            if(rps == 0){
                return "rock";
            }
            else if(rps == 1){
                return "paper";
            }
            else{
                return "scisors";
            }

        }
        static public int winner(int one, int two){
            //0 = rock, 1 = paper, 2 = scisors
            // return--> 0 p1 wins, 1 p2 wins, 2 tie
            if(one == 0 && two == 2){//rock win one
                return 0;
            }
            if(one == 1 && two == 0){//paper win one
                return 0;
            }
            if(one == 2 && two == 1){//scisors win one
                return 0;
            }
            if(two == 0 && one == 2){//rock win two
                return 1;
            }
            if(two == 1 && one == 0){//paper win two
                return 1;
            }
            if(two == 2 && one == 1){//scisors win two
                return 1;
            }
            return 2;
        }
    }
}
