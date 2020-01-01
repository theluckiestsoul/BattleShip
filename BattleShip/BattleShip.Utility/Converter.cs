using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Utility
{
    public class Converter : IConverter
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
