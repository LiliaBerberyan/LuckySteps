using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLuckySteps
{
    interface IPlayer
    {
        string UserName { get; }
        int GamePlayCountForADay { get; set; }
        int CurrentMoney { get; set; }
    }
}
