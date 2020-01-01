using System;

namespace BattleShip.Entities.DTO
{
    public class BattleShipCellDto
    {
        public Guid Id { set; get; }
        public string CellName { get; set; }

        public int BattleShipId { get; set; }

        public int HitsRequiredToDestroy { get; set; }
    }
}
