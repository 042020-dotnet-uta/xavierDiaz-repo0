using System;

namespace rocPapSci_obj
{
    public class Player
    {
        private string _name;
        private int _wins;
        private int _losses;

        public Player() {
            Console.Write("Please enter name for Player: ");
            _name = Console.ReadLine();
            _wins = 0;
            _losses = 0;
        }


        public void updateWL(bool win_loss){
        //increase wins and losses after a game
            if(win_loss){
                _wins++;
            }
            else{
                _losses--;
            }
        }

        public string getName(){
            return _name;
        }
    }
}