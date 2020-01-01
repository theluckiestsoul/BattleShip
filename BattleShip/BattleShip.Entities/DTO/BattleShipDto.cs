using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Entities.DTO
{
    public class BattleShipDto
    {
        public BattleShipDto()
        {
            BattleAreaCellDtos = new List<BattleShipCellDto>();
        }
        public int BattleAreaId { set; get; }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<BattleShipCellDto> BattleAreaCellDtos { get; set; }
    }
}
