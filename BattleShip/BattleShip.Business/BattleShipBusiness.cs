using BattleShip.Entities.DTO;
using BattleShip.Utility;
using BattleShip.Utility.Constants;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BattleShip.Business
{
    public class BattleShipBusiness : IBattleShipBusiness
    {
        private readonly IConverter _converter;
        private readonly IBattleShipValidator _battleShipValidator;
        public BattleShipBusiness(IConverter converter, IBattleShipValidator battleShipValidator)
        {
            _converter = converter;
            _battleShipValidator = battleShipValidator;
        }
        public void CreateBattleShip(string input, BattleAreaDto playerOneArea, BattleAreaDto playerTwoArea)
        {
            string[] battleShipInfo = input.Split(' ');
            int width = _converter.Convert<string, int>(battleShipInfo[1]);
            int height = _converter.Convert<string, int>(battleShipInfo[2]);
            CreateBattleShip(playerOneArea, battleShipInfo[0], battleShipInfo[3], width, height);
            CreateBattleShip(playerTwoArea, battleShipInfo[0], battleShipInfo[4], width, height);
        }

        private void CreateBattleShip(BattleAreaDto battleArea, string shipName, string cellName, int width, int height)
        {
            BattleShipDto battleShipDto = new BattleShipDto();
            battleShipDto.Name = shipName;
            GenerateBattleShipCells(cellName, battleArea, width, height).ForEach(cell =>
            {
                BattleShipCellDto battleAreaCellDto = CreateBattleShipCellDto(cell, shipName);
                battleShipDto.BattleAreaCellDtos.Add(battleAreaCellDto);
            });
            battleArea.BattleShips.Add(battleShipDto);
        }

        private static BattleShipCellDto CreateBattleShipCellDto(string cell, string shipName)
        {
            BattleShipCellDto battleAreaCellDto = new BattleShipCellDto();
            battleAreaCellDto.CellName = cell;
            battleAreaCellDto.HitsRequiredToDestroy = shipName == Ship.P ? HitsRequiredToDestroy.ONE : HitsRequiredToDestroy.TWO;
            return battleAreaCellDto;
        }

        private List<string> GenerateBattleShipCells(string cellName, BattleAreaDto playerArea,int width,int height)
        {
            List<string> battleAreaCellList = new List<string>();
            List<string> cellNameParts = Regex.Split(cellName, string.Empty).ToList<string>().FindAll(s => !string.IsNullOrWhiteSpace(s));
            _battleShipValidator.CheckIfShipCellsCanBeCreated(playerArea, cellNameParts);
            for (int i = 0; i < height; i++)
            {

                for (int j = 0; j < width; j++)
                {
                    battleAreaCellList.Add(cellNameParts[0] + (_converter.Convert<string, int>(cellNameParts[1]) + j));
                }
            }
            return battleAreaCellList;
        }
        
    }
}
