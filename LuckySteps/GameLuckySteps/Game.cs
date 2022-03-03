using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLuckySteps
{
    class Game : IGame
    {
        private string[,] _ticket = new string[10, 2];
        private string[,] _closedTicket = new string[10, 2];
        private StepResult ResultForCurrentStep { get; set; }
        private int stepsCount;
        public bool GameEnded { get; set; }

        public Game()
        {
            StepsCount = 0;
            GameEnded = false;
        }
        public int StepsCount
        {
            get
            {
                return stepsCount;
            }
            set
            {
                if (value >= 0 && value <= 10)
                {
                    stepsCount = value;
                }
                else throw new Exception();
            }
        }
        public void CreateRandomTichket()
        {
            for (int i = 0; i < _ticket.GetLength(0); i++)
            {
                for (int j = 0; j < _ticket.GetLength(1); j += 2)
                {
                    ResultForCurrentStep = StepResultRandomChoose.Choose();
                    _ticket[i, j] = ResultForCurrentStep.ToString();
                    if (ResultForCurrentStep == StepResult.Empty)
                    {
                        _ticket[i, j + 1] = StepResult.Money.ToString();
                    }
                    else _ticket[i, j + 1] = StepResult.Empty.ToString();
                }
            }
        }
        public void PrintCLosedTicket()
        {
            for (int i = 0; i < _ticket.GetLength(0); i++)
            {
                for (int j = 0; j < _ticket.GetLength(1); j++)
                {
                    _closedTicket[i, j] = "*";
                    Console.Write(_closedTicket[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public void PrintTicket(int row)
        {
            for (int i = 0; i < _ticket.GetLength(0) - row - 1; i++)
            {
                for (int j = 0; j < _ticket.GetLength(1); j++)
                {
                    Console.Write(_closedTicket[i, j] + " ");
                }
                Console.WriteLine();
            }
            for (int i = _ticket.GetLength(0) - row - 1; i < _ticket.GetLength(0); i++)
            {
                for (int j = 0; j < _ticket.GetLength(1); j++)
                {
                    Console.Write(_ticket[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public bool IsThereMoneyInColumn(int column, int row)
        {
            if (_ticket[row, column] == StepResult.Money.ToString())
            {
                return true;
            }
            else return false;
        }
    }
}
