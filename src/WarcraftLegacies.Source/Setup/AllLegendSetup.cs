using MacroTools;
using MacroTools.LegendSystem;
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
    public LegendNaga Naga { get; }
    
    /// <summary>
    /// Contains references to all Quel'thalas <see cref="Legend"/>s.
    /// </summary>
    public LegendQuelthalas Quelthalas { get; }
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
    
    /// <summary>
    /// Contains references to all Neutral <see cref="Legend"/>s.
    /// </summary>
    public LegendNeutral Neutral { get; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="AllLegendSetup"/> class.
    /// </summary>
    public AllLegendSetup(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup)
    {
      Dalaran = new LegendDalaran().Setup(preplacedUnitSystem);
      Draenei = new LegendDraenei().Setup(preplacedUnitSystem);
      Druids = new LegendDruids().Setup(preplacedUnitSystem);
      FelHorde = new LegendFelHorde().Setup(preplacedUnitSystem);
      Frostwolf = new LegendFrostwolf().Setup(preplacedUnitSystem);
      Goblin = new LegendGoblin().Setup(preplacedUnitSystem);
      Ironforge = new LegendIronforge().Setup(preplacedUnitSystem);
      Kultiras = new LegendKultiras().Setup(preplacedUnitSystem);
      Legion = new LegendLegion().Setup(preplacedUnitSystem);
      Lordaeron = new LegendLordaeron().Setup(preplacedUnitSystem, artifactSetup);
      Naga = new LegendNaga().Setup();
      Quelthalas = new LegendQuelthalas().Setup(preplacedUnitSystem);
      Scourge = new LegendScourge().Setup(preplacedUnitSystem);
      Sentinels = new LegendSentinels().Setup(preplacedUnitSystem);
      Stormwind = new LegendStormwind().Setup(preplacedUnitSystem);
      Warsong = new LegendWarsong().Setup(preplacedUnitSystem);
      Neutral = new LegendNeutral().Setup(preplacedUnitSystem);
    }
  }
}