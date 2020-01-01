using BattleShip.Business;
using BattleShip.Utility;
using System;
using Xunit;

namespace BattleShip.Tests.BusinessTests
{
    public class BattleAreaBusinessTest
    {
        [Fact]
        public void CreateBattleArea_Should_Return_BattleAreaDto_When_SuppliedWithInput()
        {
            IConverter converter = new StubConverter();
            BattleAreaBusiness battleAreaBusiness = new BattleAreaBusiness(converter);
            var battleAreaDto=battleAreaBusiness.CreateBattleArea("5 E");
            Assert.Equal(5, battleAreaDto.Width);
            Assert.Equal('E', battleAreaDto.Height);
        }
    }

    class StubConverter : IConverter
    {
        public Tout Convert<Tin, Tout>(Tin input)
        {
            Tout output = default(Tout);
            try
            {
                output = (Tout)System.Convert.ChangeType(input, typeof(Tout));
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error while converting input" + ex.Message);
            }
            return output;
        }
    }
}
