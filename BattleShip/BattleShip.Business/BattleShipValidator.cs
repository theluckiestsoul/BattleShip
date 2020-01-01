using BattleShip.Entities.DTO;
using BattleShip.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Business
{
    public class BattleShipValidator : IBattleShipValidator
    {
        private readonly IConverter _converter;
        public BattleShipValidator(IConverter converter)
        {
            _converter = converter;
        }
        public void CheckIfShipCellsCanBeCreated(BattleAreaDto playerArea, List<string> cellNameParts)
        {
            if (_converter.Convert<string, char>(cellNameParts[0]) > playerArea.Height || _converter.Convert<string, int>(cellNameParts[1]) > playerArea.Width)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
