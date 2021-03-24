using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzerothWarsCSharp.Template.Source.Setup
{
  public class GameSetup
  {
    public static void Initialize()
    {
      TeamSetup.Initialize();
      FactionSetup.Initialize();
    }
  }
}
