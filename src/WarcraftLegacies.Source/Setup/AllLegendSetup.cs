using MacroTools;
using MacroTools.LegendSystem;
using WarcraftLegacies.Source.Factions;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Setup
{
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
    /// Contains references to all Goblin <see cref="Legend"/>s.
    /// </summary>
    public LegendGoblin Goblin { get; }
    
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

    public LegendTroll Troll { get; }
    
    public LegendAhnqiraj Ahnqiraj { get; }
    
    public LegendNazjatar Nazjatar { get; }
    
    public LegendBlackEmpire BlackEmpire { get; }

    public LegendSkywall Skywall { get; }

    public LegendTwilight Twilight { get; }
    
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
    public AllLegendSetup(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup)
    {
      Dalaran = new LegendDalaran(preplacedUnitSystem);
      Draenei = new LegendDraenei(preplacedUnitSystem);
      Druids = new LegendDruids(preplacedUnitSystem);
      FelHorde = new LegendFelHorde(preplacedUnitSystem);
      Frostwolf = new LegendFrostwolf(preplacedUnitSystem);
      Goblin = new LegendGoblin(preplacedUnitSystem);
      Ironforge = new LegendIronforge(preplacedUnitSystem);
      Kultiras = new LegendKultiras(preplacedUnitSystem);
      Legion = new LegendLegion(preplacedUnitSystem);
      Lordaeron = new LegendLordaeron(preplacedUnitSystem, artifactSetup);
      Naga = new LegendIllidan();
      Quelthalas = new LegendQuelthalas(preplacedUnitSystem);
      Scourge = new LegendScourge(preplacedUnitSystem);
      Sentinels = new LegendSentinels(preplacedUnitSystem);
      Stormwind = new LegendStormwind(preplacedUnitSystem);
      Troll = new LegendTroll();
      Warsong = new LegendWarsong(preplacedUnitSystem);
      Neutral = new LegendNeutral(preplacedUnitSystem);
      Gilneas = new LegendGilneas(preplacedUnitSystem);
      Ahnqiraj = new LegendAhnqiraj(preplacedUnitSystem);
      Nazjatar = new LegendNazjatar();
      BlackEmpire = new LegendBlackEmpire(preplacedUnitSystem);
      Skywall = new LegendSkywall(preplacedUnitSystem);
      Twilight = new LegendTwilight();
      Scarlet = new LegendScarlet(preplacedUnitSystem);
      Sunfury = new LegendSunfury(preplacedUnitSystem);
    }

    /// <summary>
    /// Registers all <see cref="Legend"/>s managed by the <see cref="AllLegendSetup"/>.
    /// </summary>
    public void RegisterLegends(PreplacedUnitSystem preplacedUnitSystem)
    {
      Dalaran.RegisterLegends();
      Draenei.RegisterLegends();
      Druids.RegisterLegends();
      FelHorde.RegisterLegends();
      Frostwolf.RegisterLegends();
      Goblin.RegisterLegends();
      Ironforge.RegisterLegends();
      Kultiras.RegisterLegends();
      Legion.RegisterLegends();
      Lordaeron.RegisterLegends();
      Naga.RegisterLegends();
      Quelthalas.RegisterLegends();
      Scourge.RegisterLegends(preplacedUnitSystem);
      Sentinels.RegisterLegends();
      Stormwind.RegisterLegends();
      Warsong.RegisterLegends();
      Troll.RegisterLegends();
      Ahnqiraj.RegisterLegends();
      Nazjatar.RegisterLegends();
      BlackEmpire.RegisterLegends();
      Skywall.RegisterLegends();
      Twilight.RegisterLegends();
      Neutral.RegisterLegends();
      Gilneas.RegisterLegends();
      Scarlet.RegisterLegends();
      Sunfury.RegisterLegends();
    }
  }
}