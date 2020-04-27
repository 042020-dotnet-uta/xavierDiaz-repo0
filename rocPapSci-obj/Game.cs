using System;
using System.Collections.Generic;

namespace rocPapSci_obj
{
    public class Game
    {
        private Player _p1;
        private Player _p2;
        private int _p1S;
        private int _p2S;
        public List<Round> Rounds = new List<Round>();
        public Game(){
            _p1 = new Player();
            _p2 = new Player();
            _p1S = 0;
            _p2S = 0;
        }
        public void LetsPlay(){
            //creates a loop of rounds that ends when someone gets 2 wins
            while(_p2S < 2 && _p1S < 2){
                Round gRound = new Round();
                if(gRound.getWinner() == 1){
                    _p1S++;
                }
                else if(gRound.getWinner() == 2){
                    _p2S++;
                }
                // store these rounds for later use
                Rounds.Add(gRound);
            }
        }

        public void showResults(){
            //print out the round summaries
            int r = 1; 
            foreach(var round in Rounds){
                if(round.getWinner() == 0){
                    Console.WriteLine($"Round {r}: {_p1.getName()} played {round._p1Play} and {_p2.getName()} played {round._p2Play}, ended in a draw");
                }
                else if(round.getWinner() == 1){
                    Console.WriteLine($"Round {r}: {_p1.getName()} played {round._p1Play} and {_p2.getName()} played {round._p2Play}, winner {_p1.getName()}!");
                }
                else if(round.getWinner() == 2){
                    Console.WriteLine($"Round {r}: {_p1.getName()} played {round._p1Play} and {_p2.getName()} played {round._p2Play}, winner {_p2.getName()}!");
                }
                r++;
            }
            // print out who won and update wins/losses
            if(_p1S == 2){
                Console.WriteLine($"Winner was {_p1.getName()} {_p1S}-{_p2S}");
                _p1.updateWL(true);
                _p2.updateWL(false);
            }
            else{
                Console.WriteLine($"Winner was {_p2.getName()} {_p2S}-{_p1S}");
                _p1.updateWL(false);
                _p2.updateWL(true);
            }
        }
    }
}