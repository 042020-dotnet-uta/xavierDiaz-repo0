using System;

namespace rocPapSci_obj
{
    public class Round
    {
        public int RoundID{get;set;}
        public string _p1Play;
        public string _p2Play;
        private int _rWin;

        public Round(){
            Random rand = new Random();
            int p1Play = rand.Next(3);
            int p2Play = rand.Next(3);
            _p1Play = playID(p1Play);
            _p2Play = playID(p2Play);
            _rWin = roundWinner(p1Play, p2Play);//by default its a tie
        }

        public int getWinner(){
            return _rWin;
        }

        public string playID(int playInt){
            // just returns the string representation of a play
            if(playInt == 0){
                return "Rock";
            }
            else if(playInt == 1){
                return "Paper";
            }
            else{
                return "Scisors";
            }
        }

        public int roundWinner(int p1, int p2){
        //logic for who wins and draws
        //0-> tie, 1-> p1 won, 2-> p2 won : 0 = rock, 1 = paper, 2 = scissors
            if(p1 == 0 && p2 == 2){// p1 rock win
                return 1;
            }
            else if(p1 == 1 && p2 == 0){// p1 paper win
                return 1;
            }
            else if(p1 == 2 && p2 == 1){// p1 scisors win
                return 1;
            }
            else if(p2 == 0 && p1 == 2){// p2 rock win
                return 2;
            }
            else if(p2 == 1 && p1 == 0){// p2 paper win
                return 2;
            }
            else if(p2 == 2 && p1 == 1){// p2 scisors win
                return 2;
            }
            else {
                return 0;
            }

        }
        
    }
}