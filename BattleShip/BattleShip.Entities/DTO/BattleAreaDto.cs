using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Entities.DTO
{
    public class BattleAreaDto
    {
        public BattleAreaDto()
        {
            BattleShips = new List<BattleShipDto>();
        }
        public Guid Id { get; set; }
        public char Height { get; set; }
        public int Width { get; set; }
        public List<BattleShipDto> BattleShips { get; }
    }
}
