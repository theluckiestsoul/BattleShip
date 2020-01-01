using BattleShip.Entities.DTO;

namespace BattleShip.Business
{
    public interface IBattleShipBusiness
    {
        void CreateBattleShip(string input, BattleAreaDto playerOneArea, BattleAreaDto playerTwoArea);
    }
}
