using BattleShip.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Business
{
    public interface IBattleAreaBusiness
    {
        BattleAreaDto CreateBattleArea(string input);
    }
}
