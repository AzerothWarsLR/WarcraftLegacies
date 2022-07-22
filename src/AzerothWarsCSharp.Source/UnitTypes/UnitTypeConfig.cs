using AzerothWarsCSharp.MacroTools;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.UnitTypes
{
  public static class UnitTypeConfig
  {

    public static void Setup()
    {
      UnitType.Register(new UnitType(Constants.UNIT_NCOP_TAVERN_SELECTOR)
      {
        Meta = true
      });
    }
  }
}