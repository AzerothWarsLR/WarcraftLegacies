using MacroTools;
using MacroTools.LegendSystem;
using static War3Api.Common;
#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendFrostwolf : IRegistersLegends
  {
    public LegendaryHero LegendCairne { get; }
    public LegendaryHero LegendThrall { get; }
    public LegendaryHero LegendRexxar { get; }
    public LegendaryHero LegendVolJin { get; }
    public Capital LegendThunderbluff { get; }
    public Capital LegendDarkspearhold { get; }

    public LegendFrostwolf(PreplacedUnitSystem preplacedUnitSystem)
    {
      LegendCairne = new LegendaryHero("Cairne Bloodhoof")
      {
        UnitType = FourCC("Ocbh"),
        DeathMessage =
          "Cairne's spirit has passed on from this world. The Tauren have already begun to revere their fallen ancestor.",
        StartingXp = 1000
      };

      LegendThrall = new LegendaryHero("Thrall")
      {
        UnitType = Constants.UNIT_OTHR_WARCHIEF_OF_THE_HORDE_FROSTWOLF,
        StartingArtifactItemTypeIds = new[]
        {
          Constants.ITEM_I004_THE_DOOMHAMMER
        }
      };

      LegendThunderbluff = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("o00J")),
        DeathMessage =
          "The mesas of Thunderbluff have been swept clean of the Tauren. The Bloodhoof are without a home."
      };

      LegendDarkspearhold = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("o02D"))
      };

      LegendRexxar = new LegendaryHero("Rexxar")
      {
        UnitType = FourCC("Orex"),
        StartingXp = 1800
      };

      LegendVolJin = new LegendaryHero("Vol'jin")
      {
        UnitType = Constants.UNIT_ORKN_CHIEFTAIN_OF_THE_DARKSPEAR_TRIBE_FROSTWOLF,
      };
    }

    /// <inheritdoc />
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(LegendCairne);
      LegendaryHeroManager.Register(LegendThrall);
      LegendaryHeroManager.Register(LegendRexxar);
      LegendaryHeroManager.Register(LegendVolJin);
      CapitalManager.Register(LegendThunderbluff);
      CapitalManager.Register(LegendDarkspearhold);
    }
  }
}