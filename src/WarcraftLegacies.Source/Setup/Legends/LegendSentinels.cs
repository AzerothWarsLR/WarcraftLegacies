using MacroTools;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  /// <summary>
  /// Responsible for setting up and storing all Sentinel <see cref="Legend"/>s.
  /// </summary>
  public static class LegendSentinels
  {
    /// <summary>
    /// Leader of the Wardens.
    /// </summary>
    public static LegendaryHero? Maiev { get; private set; }

    /// <summary>
    /// High Priestess of Elune.
    /// </summary>
    public static LegendaryHero? Tyrande { get; private set; }
    
    /// <summary>
    /// Tyrande's second in command.
    /// </summary>
    public static LegendaryHero? Shandris { get; private set; }
    
    /// <summary>
    /// Night Elven Commander.
    /// </summary>
    public static LegendaryHero? Jarod { get; private set; }
    
    /// <summary>
    /// Night Elven town in Darkshore.
    /// </summary>
    public static Capital? Auberdine { get; private set; }
    
    /// <summary>
    /// Night Elven stronghold village led by Shandris.
    /// </summary>
    public static Capital? Feathermoon { get; private set; }

    /// <summary>
    /// Sets up all Sentinel <see cref="Legend"/>s.
    /// </summary>
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      Maiev = new LegendaryHero
      {
        UnitType = FourCC("Ewrd")
      };
      LegendaryHeroManager.Register(Maiev);

      Auberdine = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("e00J"))
      };
      LegendaryHeroManager.Register(Auberdine);

      Feathermoon = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("e00M"))
      };
      LegendaryHeroManager.Register(Feathermoon);

      Tyrande = new LegendaryHero
      {
        UnitType = FourCC("Etyr"),
        PlayerColor = PLAYER_COLOR_CYAN
      };
      LegendaryHeroManager.Register(Tyrande);

      Shandris = new LegendaryHero
      {
        UnitType = FourCC("E002"),
        StartingXp = 1000
      };
      LegendaryHeroManager.Register(Shandris);

      Jarod = new LegendaryHero
      {
        UnitType = FourCC("O02E"),
        StartingXp = 4000
      };
      LegendaryHeroManager.Register(Jarod);
    }
  }
}