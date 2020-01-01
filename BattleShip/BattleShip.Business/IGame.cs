using BattleShip.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
   public interface IGame
    {
        void Start(BattleAreaDto battle1, BattleAreaDto battle2, string player1Missile, string player2Missile);
    }
}
