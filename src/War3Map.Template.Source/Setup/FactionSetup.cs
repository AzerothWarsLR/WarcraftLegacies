using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzerothWarsCSharp.Template.Source.Setup
{
  public static class FactionSetup
  {
    public static void Initialize()
    {
      ScourgeSetup.Initialize();
      LordaeronSetup.Initialize();
    }
  }
}
