using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

namespace Lab_26_Craps
{
    enum STATUS { CONTINUE, WON, LOST}
    enum DICE_NAME:Int16 { SNAKE_EYE = 2, TREY = 3, SEVEN = 7, YO_LEVEN = 11, BOX_CARS = 12}

    class CrapsGame
    {
        private Random rand;
        private const int SIZE = 22;
        int[] wins = new int[SIZE];//keep track of number of wins
        int[] losses = new int[SIZE];//keep track of number of losses
        int totalNumberOfRolls;//total number of rolls for all games
        int totalWins, totalLosses;
        int totalNumberOfRollsPerGame;
        public CrapsGame()
        {
            rand = new Random();
            totalNumberOfRolls = 0; //don't need to initialize it.
            totalNumberOfRollsPerGame = 0;//don't need to intialize
            Play();
        }
        public void Play()
        {
            STATUS gStatus = STATUS.CONTINUE;
            int myPoint = -1;

            int diceValue = RollDice();
            if (totalNumberOfRollsPerGame >= 21)
            {
                totalNumberOfRollsPerGame = 21;
            }


            switch ((DICE_NAME) diceValue)
            {
                case DICE_NAME.SEVEN:
                case DICE_NAME.YO_LEVEN:
                gStatus = STATUS.WON; //game won on first roll.
                    totalWins++;
                    ++wins[++totalNumberOfRollsPerGame];
                    break;
                case DICE_NAME.SNAKE_EYE:
                case DICE_NAME.TREY:
                case DICE_NAME.BOX_CARS:
                    gStatus = STATUS.LOST; //game lost on first roll.
                    totalLosses++;
                    ++losses[totalNumberOfRollsPerGame];
                    break;
                default:
                    gStatus = STATUS.CONTINUE;
                    myPoint = diceValue;
                    break;
            } //end switch for first roll
            while (gStatus == STATUS.CONTINUE)
            {
                diceValue = RollDice();
                
                if (diceValue == myPoint)
                {
                    gStatus = STATUS.WON;
                    totalWins++;
                    ++wins[totalNumberOfRollsPerGame];
                }
                else if (diceValue == (int)DICE_NAME.SEVEN)
                {
                    gStatus = STATUS.LOST;
                    totalLosses++;
                    
                    ++losses[totalNumberOfRollsPerGame];
                }
            }//END OF GAME, either we got a 7 and lost of got the point and won.
            if (gStatus == STATUS.WON)
            {
                Console.WriteLine("Game won");
            }
            else
            {
                Console.WriteLine("Game lost");
            }

        }//end of method Play

        public void DisplayStatus()
        {
            for (int i = 1; i < SIZE; i++)
            {
                Console.WriteLine($"On Roll {i,-10} Wins: {wins[i], -10} Losses: {losses[i], -10}");
            }
            Console.WriteLine($"Wins:{totalWins} Losses:{totalLosses}");
        }
        public int RollDice()
        {
            ++totalNumberOfRolls;
            ++totalNumberOfRollsPerGame;
            int die1 = rand.Next(1, 7); //from 1 to 6
            int die2 = rand.Next(1, 7); //from 1 to 6
            int sum = die1 + die2;
            Console.WriteLine($"{die1} {die2} - {sum}");
            return sum;
        }
    }//end of class
}//end of namespace
