using BattleShip.Entities.DTO;
using BattleShip.Utility;

namespace BattleShip.Business
{
    public  class BattleAreaBusiness : IBattleAreaBusiness
    {
        private readonly IConverter _converter;
        public BattleAreaBusiness(IConverter converter)
        {
            _converter = converter;
        }
        public BattleAreaDto CreateBattleArea(string input)
        {
            string[] inputArray=input.Split(' ');
            BattleAreaDto battleAreaDto = new BattleAreaDto();
            battleAreaDto.Width = _converter.Convert<string, int>(inputArray[0]);
            battleAreaDto.Height = _converter.Convert<string, char>(inputArray[1]);
            return battleAreaDto;
        }
    }
}
