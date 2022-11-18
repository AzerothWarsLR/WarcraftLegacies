using MacroTools;
using MacroTools.FactionSystem;
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
    public static Legend? Maiev { get; private set; }

    /// <summary>
    /// High Priestess of Elune.
    /// </summary>
    public static Legend? Tyrande { get; private set; }
    
    /// <summary>
    /// Tyrande's second in command.
    /// </summary>
    public static Legend? Shandris { get; private set; }
    
    /// <summary>
    /// Night Elven Commander.
    /// </summary>
    public static Legend? Jarod { get; private set; }
    
    /// <summary>
    /// Night Elven town in Darkshore.
    /// </summary>
    public static Legend? Auberdine { get; private set; }
    
    /// <summary>
    /// Night Elven stronghold village led by Shandris.
    /// </summary>
    public static Legend? Feathermoon { get; private set; }

    /// <summary>
    /// Sets up all Sentinel <see cref="Legend"/>s.
    /// </summary>
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      Maiev = new Legend
      {
        UnitType = FourCC("Ewrd")
      };
      Legend.Register(Maiev);

      Auberdine = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("e00J"))
      };
      Legend.Register(Auberdine);

      Feathermoon = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("e00M"))
      };
      Legend.Register(Feathermoon);

      Tyrande = new Legend
      {
        UnitType = FourCC("Etyr"),
        PlayerColor = PLAYER_COLOR_CYAN
      };
      Legend.Register(Tyrande);

      Shandris = new Legend
      {
        UnitType = FourCC("E002"),
        StartingXp = 1000
      };
      Legend.Register(Shandris);

      Jarod = new Legend
      {
        UnitType = FourCC("O02E"),
        StartingXp = 4000
      };
      Legend.Register(Jarod);
    }
  }
}