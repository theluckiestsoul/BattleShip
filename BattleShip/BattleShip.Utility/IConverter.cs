using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Utility
{
    public interface IConverter
    {
        Tout Convert<Tin, Tout>(Tin input);
    }
}
