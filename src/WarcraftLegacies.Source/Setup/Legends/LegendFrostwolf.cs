using WarcraftLegacies.MacroTools;
using WarcraftLegacies.MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendFrostwolf
  {
    public static Legend? LegendCairne { get; private set; }
    public static Legend? LegendThrall { get; private set; }
    public static Legend? LegendRexxar { get; private set; }

    public static Legend? LegendThunderbluff { get; private set; }
    public static Legend? LegendDarkspearhold { get; private set; }
    public static Legend? LegendOrgrimmar { get; private set; }

    public static void Setup()
    {
      LegendCairne = new Legend
      {
        UnitType = FourCC("Ocbh"),
        DeathMessage =
          "CairneFourCC(s spirit has passed on from this world. The Tauren have already begun to revere their fallen ancestor.",
        StartingXp = 1000
      };
      Legend.Register(LegendCairne);

      LegendThrall = new Legend
      {
        UnitType = FourCC("Othr")
      };
      Legend.Register(LegendThrall);

      LegendThunderbluff = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("o00J")),
        DeathMessage =
          "The mesas of Thunderbluff have been swept clean of the Tauren. The Bloodhoof are without a home."
      };
      Legend.Register(LegendThunderbluff);

      LegendDarkspearhold = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("o02D"))
      };
      Legend.Register(LegendDarkspearhold);

      LegendRexxar = new Legend
      {
        UnitType = FourCC("Orex"),
        StartingXp = 1800
      };
      Legend.Register(LegendRexxar);

      LegendOrgrimmar = new Legend
      {
        DeathMessage =
          "Orgrimmar has been demolished. With it dies the hopes and dreams of a wartorn race seeking refuge in a new world."
      };
      Legend.Register(LegendOrgrimmar);
    }
  }
}