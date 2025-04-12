using MacroTools.LegendSystem;
using MacroTools.Systems;

#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendFrostwolf
  {
    public LegendaryHero Cairne { get; }
    public LegendaryHero Thrall { get; }
    public LegendaryHero Rexxar { get; }
    public LegendaryHero Voljin { get; }
    public Capital ThunderBluff { get; }
    public Capital DarkspearHold { get; }

    public LegendFrostwolf(PreplacedUnitSystem preplacedUnitSystem)
    {
      Cairne = new LegendaryHero("Cairne Bloodhoof")
      {
        UnitType = FourCC("Ocbh"),
        DeathMessage =
          "Cairne's spirit has passed on from this world. The Tauren have already begun to revere their fallen ancestor.",
        StartingXp = 1800,
        StartingArtifacts = new()
        {
          new(CreateItem(ITEM_I00L_BLOODHOOF_TOTEM, Regions.ArtifactDummyInstance.Center.X, Regions.ArtifactDummyInstance.Center.Y))
        }
      };

      Thrall = new LegendaryHero("Thrall")
      {
        UnitType = UNIT_OTHR_WARCHIEF_OF_THE_HORDE_FROSTWOLF,
        StartingArtifacts = new()
        {
          new(CreateItem(ITEM_I004_THE_DOOMHAMMER, Regions.ArtifactDummyInstance.Center.X, Regions.ArtifactDummyInstance.Center.Y))
        }
      };

      ThunderBluff = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("o00J")),
        Capturable = true,
        DeathMessage =
          "The mesas of Thunderbluff have been swept clean of the Tauren. The Bloodhoof are without a home.",
        Essential = true
      };

      DarkspearHold = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("o02D")),
        Essential = true
      };
    
      Rexxar = new LegendaryHero("Rexxar")
      {
        UnitType = FourCC("Orex"),
        StartingXp = 1800
      };

      Voljin = new LegendaryHero("Vol'jin")
      {
        UnitType = UNIT_ORKN_CHIEFTAIN_OF_THE_DARKSPEAR_TRIBE_FROSTWOLF,
        StartingXp = 2800
      };
    }
    
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(Cairne);
      LegendaryHeroManager.Register(Thrall);
      LegendaryHeroManager.Register(Rexxar);
      LegendaryHeroManager.Register(Voljin);
      CapitalManager.Register(ThunderBluff);
      CapitalManager.Register(DarkspearHold);
    }
  }
}