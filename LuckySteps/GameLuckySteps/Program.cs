using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLuckySteps
{
    class Program
    {
        static void Main(string[] args)
        {
            StartProgram();
        }
        static void StartProgram()
        {
            IGameManager gameManager = new GameManager();
            gameManager.StartWork();
        }
    }
}
