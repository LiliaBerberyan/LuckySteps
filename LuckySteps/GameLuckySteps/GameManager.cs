using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLuckySteps
{
    class GameManager : IGameManager
    {
        private IGame LuckySteps;
        private List<IPlayer> Players { get; set; }
        public GameManager()
        {
            LuckySteps = new Game();
            Players = new List<IPlayer>();
        }
        public void StartWork()
        {
            ConsoleKey key;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Click button for appropriate Command\n1.Log In\n2.Add PLayer\nEsc.Close Programm");
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        LogIn();
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        AddPlayer();
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            }
        }
        private void AddPlayer()
        {
            Console.Clear();
            Console.WriteLine("Create UserName, and write it below");
            string userName = Console.ReadLine();
            IPlayer player = new Player(userName);
            Players.Add(player);
            Console.WriteLine("User Added,press any key to go back and LogIn");
            Console.ReadKey();
        }
        private void LogIn()
        {
            Console.Clear();
            Console.WriteLine("Write your UserName");
            string userName = Console.ReadLine();
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].UserName == userName)
                {
                    Console.WriteLine("You Logged In, press any key to start the game");
                    Console.ReadKey();
                    StartGame(Players[i]);
                }
                else
                {
                    Console.WriteLine("Wrong Username,Press any key to go back");
                    Console.ReadKey();
                }
            }
        }
        private void StartGame(IPlayer player)
        {
            ChechkPlayer(player);
            LuckySteps.CreateRandomTichket();
            while (LuckySteps.GameEnded == false)
            {
                Console.Clear();
                Console.WriteLine("Here is your tichket\nClick button for appropriate Command");
                Console.WriteLine("\n1.Left Column\n2.Right Column\nEsc.End Game and Get Money");
                if (LuckySteps.StepsCount == 0)
                {
                    LuckySteps.PrintCLosedTicket();
                }
                else LuckySteps.PrintTicket(LuckySteps.StepsCount);
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        ColumnChoose(0, LuckySteps.StepsCount, player);
                        break;
                    case ConsoleKey.D2:
                        ColumnChoose(1, LuckySteps.StepsCount, player);
                        break;
                    case ConsoleKey.Escape:
                        EndGame(player);
                        return;
                }
            }
        }
        private void ChechkPlayer(IPlayer player)
        {
            if (player.GamePlayCountForADay == 3)
            {
                Console.Clear();
                Console.WriteLine("You played today 3 times, you need yp wait 23 hours, yo play again");
                return;
            }
        }
        private void ColumnChoose(int column, int row, IPlayer player)
        {
            Console.Clear();
            LuckySteps.PrintTicket(row);
            if (LuckySteps.IsThereMoneyInColumn(column, row))
            {
                LuckySteps.StepsCount++;
                player.CurrentMoney += 10 * LuckySteps.StepsCount;
                Console.WriteLine($"Cogratulations,you earn {player.CurrentMoney}$");
            }
            else
            {
                Console.WriteLine("Unfortunately, you loose,press any key to end game");
                player.GamePlayCountForADay++;
                LuckySteps.GameEnded = true;
                Console.ReadKey();
            }
        }
        private void EndGame(IPlayer player)
        {
            Console.WriteLine($"You end game with {player.CurrentMoney}$");
            LuckySteps.GameEnded = true;
            player.GamePlayCountForADay++;
        }
    }
}
