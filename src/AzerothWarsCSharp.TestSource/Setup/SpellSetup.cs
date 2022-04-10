using AzerothWarsCSharp.MacroTools.Spells;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.TestSource.Setup
{
  public static class SpellSetup
  {
    public static void Setup()
    {
      var summonGraniteGolems = new SummonUnits(FourCC("AHbn"))
      {
        SummonUnitTypeId = FourCC("nggr"),
        SummonCount = 4,
        Duration = 60,
        Radius = 400,
        AngleOffset = 45,
        Effect = @"war3mapImported\Earth NovaTarget.mdx"
      };
      SpellSystem.Register(summonGraniteGolems);
    }
  }
}