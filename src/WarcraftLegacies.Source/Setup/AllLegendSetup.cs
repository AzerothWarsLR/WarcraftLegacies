using MacroTools.LegendSystem;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Setup;

/// <summary>
/// Initializes and maintains references to all <see cref="Legend"/>s.
/// </summary>
public sealed class AllLegendSetup
{
  /// <summary>
  /// Contains references to all Dalaran <see cref="Legend"/>s.
  /// </summary>
  public LegendDalaran Dalaran { get; }

  /// <summary>
  /// Contains references to all Draenei <see cref="Legend"/>s.
  /// </summary>
  public LegendDraenei Draenei { get; }

  /// <summary>
  /// Contains references to all Druid <see cref="Legend"/>s.
  /// </summary>
  public LegendDruids Druids { get; }

  /// <summary>
  /// Contains references to all Fel Horde <see cref="Legend"/>s.
  /// </summary>
  public LegendFelHorde FelHorde { get; }

  /// <summary>
  /// Contains references to all Frostwolf <see cref="Legend"/>s.
  /// </summary>
  public LegendFrostwolf Frostwolf { get; }

  /// <summary>
  /// Contains references to all Ironforge <see cref="Legend"/>s.
  /// </summary>
  public LegendIronforge Ironforge { get; }

  /// <summary>
  /// Contains references to all Kul Tiras <see cref="Legend"/>s.
  /// </summary>
  public LegendKultiras Kultiras { get; }

  /// <summary>
  /// Contains references to all Legion <see cref="Legend"/>s.
  /// </summary>
  public LegendLegion Legion { get; }

  /// <summary>
  /// Contains references to all Lordaeron <see cref="Legend"/>s.
  /// </summary>
  public LegendLordaeron Lordaeron { get; }

  /// <summary>
  /// Contains references to all Naga <see cref="Legend"/>s.
  /// </summary>
  public LegendIllidan Naga { get; }

  /// <summary>
  /// Contains references to all Quel'thalas <see cref="Legend"/>s.
  /// </summary>
  public LegendQuelthalas Quelthalas { get; }

  /// <summary>
  /// Contains references to all Scourge <see cref="Legend"/>s.
  /// </summary>
  public LegendScourge Scourge { get; }

  /// <summary>
  /// Contains references to all Sentinel <see cref="Legend"/>s.
  /// </summary>
  public LegendSentinels Sentinels { get; }

  /// <summary>
  /// Contains references to all Stormwind <see cref="Legend"/>s.
  /// </summary>
  public LegendStormwind Stormwind { get; }

  /// <summary>
  /// Contains references to all Warsong <see cref="Legend"/>s.
  /// </summary>
  public LegendWarsong Warsong { get; }

  public LegendAhnqiraj Ahnqiraj { get; }

  public LegendBlackEmpire BlackEmpire { get; }

  public LegendSkywall Skywall { get; }

  public LegendGilneas Gilneas { get; }

  public LegendScarlet Scarlet { get; }

  public LegendSunfury Sunfury { get; }

  /// <summary>
  /// Contains references to all Neutral <see cref="Legend"/>s.
  /// </summary>
  public LegendNeutral Neutral { get; }

  /// <summary>
  /// Initializes a new instance of the <see cref="AllLegendSetup"/> class.
  /// </summary>
  public AllLegendSetup()
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
  /// Registers all <see cref="Legend"/>s managed by the <see cref="AllLegendSetup"/>.
  /// </summary>
  public void RegisterLegends()
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
