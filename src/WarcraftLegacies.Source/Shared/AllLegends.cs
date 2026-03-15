using MacroTools.Legends;
using WarcraftLegacies.Source.Factions.Ahnqiraj;
using WarcraftLegacies.Source.Factions.BlackEmpire;
using WarcraftLegacies.Source.Factions.Dalaran;
using WarcraftLegacies.Source.Factions.Draenei;
using WarcraftLegacies.Source.Factions.Druids;
using WarcraftLegacies.Source.Factions.FelHorde;
using WarcraftLegacies.Source.Factions.Frostwolf;
using WarcraftLegacies.Source.Factions.Gilneas;
using WarcraftLegacies.Source.Factions.Illidari;
using WarcraftLegacies.Source.Factions.Ironforge;
using WarcraftLegacies.Source.Factions.Kultiras;
using WarcraftLegacies.Source.Factions.Legion;
using WarcraftLegacies.Source.Factions.Lordaeron;
using WarcraftLegacies.Source.Factions.Quelthalas;
using WarcraftLegacies.Source.Factions.ScarletCrusade;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Factions.Sentinels;
using WarcraftLegacies.Source.Factions.Skywall;
using WarcraftLegacies.Source.Factions.Stormwind;
using WarcraftLegacies.Source.Factions.Sunfury;
using WarcraftLegacies.Source.Factions.Warsong;

namespace WarcraftLegacies.Source.Shared;

public static class AllLegends
{
  /// <summary>
  /// Contains references to all Dalaran <see cref="Legend"/>s.
  /// </summary>
  public static DalaranLegends Dalaran { get; }

  /// <summary>
  /// Contains references to all Draenei <see cref="Legend"/>s.
  /// </summary>
  public static DraeneiLegends Draenei { get; }

  /// <summary>
  /// Contains references to all Druid <see cref="Legend"/>s.
  /// </summary>
  public static DruidsLegends Druids { get; }

  /// <summary>
  /// Contains references to all Fel Horde <see cref="Legend"/>s.
  /// </summary>
  public static FelHordeLegends FelHorde { get; }

  /// <summary>
  /// Contains references to all Frostwolf <see cref="Legend"/>s.
  /// </summary>
  public static FrostwolfLegends Frostwolf { get; }

  /// <summary>
  /// Contains references to all Ironforge <see cref="Legend"/>s.
  /// </summary>
  public static IronforgeLegends Ironforge { get; }

  /// <summary>
  /// Contains references to all Kul Tiras <see cref="Legend"/>s.
  /// </summary>
  public static KultirasLegends Kultiras { get; }

  /// <summary>
  /// Contains references to all Legion <see cref="Legend"/>s.
  /// </summary>
  public static LegendLegion Legion { get; }

  /// <summary>
  /// Contains references to all Lordaeron <see cref="Legend"/>s.
  /// </summary>
  public static LordaeronLegends Lordaeron { get; }

  /// <summary>
  /// Contains references to all Naga <see cref="Legend"/>s.
  /// </summary>
  public static IllidariLegends Naga { get; }

  /// <summary>
  /// Contains references to all Quel'thalas <see cref="Legend"/>s.
  /// </summary>
  public static QuelthalasLegends Quelthalas { get; }

  /// <summary>
  /// Contains references to all Scourge <see cref="Legend"/>s.
  /// </summary>
  public static ScourgeLegends Scourge { get; }

  /// <summary>
  /// Contains references to all Sentinel <see cref="Legend"/>s.
  /// </summary>
  public static SentinelsLegends Sentinels { get; }

  /// <summary>
  /// Contains references to all Stormwind <see cref="Legend"/>s.
  /// </summary>
  public static StormwindLegends Stormwind { get; }

  /// <summary>
  /// Contains references to all Warsong <see cref="Legend"/>s.
  /// </summary>
  public static WarsongLegends Warsong { get; }

  public static AhnqirajLegends Ahnqiraj { get; }

  public static BlackEmpireLegends BlackEmpire { get; }

  public static SkywallLegends Skywall { get; }

  public static GilneasLegends Gilneas { get; }

  public static ScarletLegends Scarlet { get; }

  public static SunfuryLegends Sunfury { get; }

  /// <summary>
  /// Contains references to all Neutral <see cref="Legend"/>s.
  /// </summary>
  public static NeutralLegends Neutral { get; }

  static AllLegends()
  {
    Dalaran = new DalaranLegends();
    Draenei = new DraeneiLegends();
    Druids = new DruidsLegends();
    FelHorde = new FelHordeLegends();
    Frostwolf = new FrostwolfLegends();
    Ironforge = new IronforgeLegends();
    Kultiras = new KultirasLegends();
    Legion = new LegendLegion();
    Lordaeron = new LordaeronLegends();
    Naga = new IllidariLegends();
    Quelthalas = new QuelthalasLegends();
    Scourge = new ScourgeLegends();
    Sentinels = new SentinelsLegends();
    Stormwind = new StormwindLegends();
    Warsong = new WarsongLegends();
    Neutral = new NeutralLegends();
    Gilneas = new GilneasLegends();
    Ahnqiraj = new AhnqirajLegends();
    BlackEmpire = new BlackEmpireLegends();
    Skywall = new SkywallLegends();
    Scarlet = new ScarletLegends();
    Sunfury = new SunfuryLegends();
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
