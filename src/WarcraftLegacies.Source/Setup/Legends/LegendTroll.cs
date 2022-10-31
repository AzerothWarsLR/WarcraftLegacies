using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendTroll
  {
    public static Legend LEGEND_PRIEST { get; private set; }
    public static Legend LEGEND_RASTAKHAN { get; private set; }
    public static Legend LEGEND_HAKKAR { get; private set; }

    public static void Setup()
    {
      LEGEND_PRIEST = new Legend
      {
        UnitType = FourCC("O01J"),
      };
      Legend.Register(LEGEND_PRIEST);

      LEGEND_HAKKAR = new Legend
      {
        UnitType = FourCC("U023")
      };
      Legend.Register(LEGEND_HAKKAR);

      LEGEND_RASTAKHAN = new Legend
      {
        UnitType = FourCC("O026"),
        StartingXp = 2800
      };
      Legend.Register(LEGEND_RASTAKHAN);
    }
  }
}