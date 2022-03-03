using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLuckySteps
{
    interface IGame
    {
        bool GameEnded { get; set; }
        void CreateRandomTichket();
        int StepsCount { get; set; }
        void PrintCLosedTicket();
        void PrintTicket(int row);
        bool IsThereMoneyInColumn(int column, int row);
    }
}
