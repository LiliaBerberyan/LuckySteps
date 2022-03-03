using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLuckySteps
{
    class Player : IPlayer
    {
        public string UserName { get; }
        public int GamePlayCountForADay { get; set; }
        public int CurrentMoney { get; set; }
        public Player(string userName)
        {
            UserName = userName;
            GamePlayCountForADay = 0;
            CurrentMoney = 0;
        }
    }
}
