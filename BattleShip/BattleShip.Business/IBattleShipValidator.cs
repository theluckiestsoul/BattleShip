using BattleShip.Entities.DTO;
using System.Collections.Generic;

namespace BattleShip.Business
{
   public interface IBattleShipValidator
    {
        void CheckIfShipCellsCanBeCreated(BattleAreaDto playerArea, List<string> cellNameParts);
    }
}
