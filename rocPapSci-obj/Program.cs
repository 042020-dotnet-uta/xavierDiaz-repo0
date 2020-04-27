using System;

namespace rocPapSci_obj
{
    class Program
    {
        static void Main(string[] args)
        {
            // instantiate a game
            Game curGame = new Game();
            // run the game
            curGame.LetsPlay();
            // print rounds and winner 
            curGame.showResults();
        }
    }
}
