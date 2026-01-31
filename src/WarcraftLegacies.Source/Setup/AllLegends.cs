using MacroTools.Legends;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Setup;

public static class AllLegends
{
  /// <summary>
  /// Contains references to all Dalaran <see cref="Legend"/>s.
  /// </summary>
  public static LegendDalaran Dalaran { get; }

  /// <summary>
  /// Contains references to all Draenei <see cref="Legend"/>s.
  /// </summary>
  public static LegendDraenei Draenei { get; }

  /// <summary>
  /// Contains references to all Druid <see cref="Legend"/>s.
  /// </summary>
  public static LegendDruids Druids { get; }

  /// <summary>
  /// Contains references to all Fel Horde <see cref="Legend"/>s.
  /// </summary>
  public static LegendFelHorde FelHorde { get; }

  /// <summary>
  /// Contains references to all Frostwolf <see cref="Legend"/>s.
  /// </summary>
  public static LegendFrostwolf Frostwolf { get; }

  /// <summary>
  /// Contains references to all Ironforge <see cref="Legend"/>s.
  /// </summary>
  public static LegendIronforge Ironforge { get; }

  /// <summary>
  /// Contains references to all Kul Tiras <see cref="Legend"/>s.
  /// </summary>
  public static LegendKultiras Kultiras { get; }

  /// <summary>
  /// Contains references to all Legion <see cref="Legend"/>s.
  /// </summary>
  public static LegendLegion Legion { get; }

  /// <summary>
  /// Contains references to all Lordaeron <see cref="Legend"/>s.
  /// </summary>
  public static LegendLordaeron Lordaeron { get; }

  /// <summary>
  /// Contains references to all Naga <see cref="Legend"/>s.
  /// </summary>
  public static LegendIllidan Naga { get; }

  /// <summary>
  /// Contains references to all Quel'thalas <see cref="Legend"/>s.
  /// </summary>
  public static LegendQuelthalas Quelthalas { get; }

  /// <summary>
  /// Contains references to all Scourge <see cref="Legend"/>s.
  /// </summary>
  public static LegendScourge Scourge { get; }

  /// <summary>
  /// Contains references to all Sentinel <see cref="Legend"/>s.
  /// </summary>
  public static LegendSentinels Sentinels { get; }

  /// <summary>
  /// Contains references to all Stormwind <see cref="Legend"/>s.
  /// </summary>
  public static LegendStormwind Stormwind { get; }

  /// <summary>
  /// Contains references to all Warsong <see cref="Legend"/>s.
  /// </summary>
  public static LegendWarsong Warsong { get; }

  public static LegendAhnqiraj Ahnqiraj { get; }

  public static LegendBlackEmpire BlackEmpire { get; }

  public static LegendSkywall Skywall { get; }

  public static LegendGilneas Gilneas { get; }

  public static LegendScarlet Scarlet { get; }

  public static LegendSunfury Sunfury { get; }

  /// <summary>
  /// Contains references to all Neutral <see cref="Legend"/>s.
  /// </summary>
  public static LegendNeutral Neutral { get; }

  static AllLegends()
  {
    Dalaran = new LegendDalaran();
    Draenei = new LegendDraenei();
    Druids = new LegendDruids();
    FelHorde = new LegendFelHorde();
    Frostwolf = new LegendFrostwolf();
    Ironforge = new LegendIronforge();
    Kultiras = new LegendKultiras();
    Legion = new LegendLegion();
    Lordaeron = new LegendLordaeron();
    Naga = new LegendIllidan();
    Quelthalas = new LegendQuelthalas();
    Scourge = new LegendScourge();
    Sentinels = new LegendSentinels();
    Stormwind = new LegendStormwind();
    Warsong = new LegendWarsong();
    Neutral = new LegendNeutral();
    Gilneas = new LegendGilneas();
    Ahnqiraj = new LegendAhnqiraj();
    BlackEmpire = new LegendBlackEmpire();
    Skywall = new LegendSkywall();
    Scarlet = new LegendScarlet();
    Sunfury = new LegendSunfury();
  }

  /// <summary>
  /// Registers all <see cref="Legend"/>s managed by the <see cref="AllLegends"/>.
  /// </summary>
  public static void Setup()
  {
    Dalaran.RegisterLegends();
    Draenei.RegisterLegends();
    Druids.RegisterLegends();
    FelHorde.RegisterLegends();
    Frostwolf.RegisterLegends();
    Ironforge.RegisterLegends();
    Kultiras.RegisterLegends();
    Legion.RegisterLegends();
    Lordaeron.RegisterLegends();
    Naga.RegisterLegends();
    Quelthalas.RegisterLegends();
    Scourge.RegisterLegends();
    Sentinels.RegisterLegends();
    Stormwind.RegisterLegends();
    Warsong.RegisterLegends();
    Ahnqiraj.RegisterLegends();
    BlackEmpire.RegisterLegends();
    Skywall.RegisterLegends();
    Neutral.RegisterLegends();
    Gilneas.RegisterLegends();
    Scarlet.RegisterLegends();
    Sunfury.RegisterLegends();
  }
}
