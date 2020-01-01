using BattleShip.Business;
using BattleShip.Entities.DTO;
using BattleShip.Utility;
using System.Collections.Generic;

namespace BattleShip
{
    public class InputProcessor : IInputProcessor
    {
        private readonly IBattleAreaBusiness _battleAreaBusiness;
        private readonly IConverter _converter;
        private readonly IBattleShipBusiness _battleShipBusiness;
        private readonly IGame _game;
        public InputProcessor(IBattleAreaBusiness battleAreaBusiness,IConverter converter, IBattleShipBusiness battleShipBusiness, IGame game)
        {
            _battleAreaBusiness = battleAreaBusiness;
            _converter = converter;
            _battleShipBusiness = battleShipBusiness;
            _game = game;
        }
        public void ProcessInput(List<string> inputList)
        {
            BattleAreaDto playerOneArea = _battleAreaBusiness.CreateBattleArea(inputList[0]);
            BattleAreaDto playerTwoArea = _battleAreaBusiness.CreateBattleArea(inputList[0]);
            
            int noOfBattleShips=_converter.Convert<string, int>(inputList[1]);
            for(int i=0;i< noOfBattleShips; i++)
            {
                _battleShipBusiness.CreateBattleShip(inputList[2 + i], playerOneArea,  playerTwoArea);
            }
            _game.Start(playerOneArea, playerTwoArea, inputList[2 + noOfBattleShips], inputList[3 + noOfBattleShips]);

        }
    }
}
