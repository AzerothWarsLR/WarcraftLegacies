using MacroTools;
using MacroTools.Extensions;
using MacroTools.LegendSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace WarcraftLegacies.Source.Setup.Legends
{
  /// <summary>
  /// Responsible for setting up and managing all <see cref="ScourgeSetup.Scourge"/> <see cref="Legend"/>s.
  /// </summary>
  public sealed class LegendScourge
  {
    /// <summary>
    /// Leader of the Cult of the Damned.
    /// </summary>
    public LegendaryHero? Kelthuzad { get; }
    
    /// <summary>
    /// Fallen king of the Nerubians.
    /// </summary>
    public LegendaryHero? Anubarak { get; }
    
    /// <summary>
    /// Ruler of Stratholme after it's taken over by the Scourge.
    /// </summary>
    public LegendaryHero? Rivendare { get; }
    
    /// <summary>
    /// The first human Death Knight, and Ner'zhul's champion.
    /// </summary>
    public LegendaryHero? Arthas { get; }
    
    /// <summary>
    /// Psychic ruler of the Scourge.
    /// </summary>
    public Capital? LegendLichking { get; }
    
    /// <summary>
    /// A Vrykul stronghold.
    /// </summary>
    public Capital? LegendUtgarde { get; }

    /// <summary>
    /// Sets up <see cref="LegendScourge"/>.
    /// </summary>
    /// <param name="preplacedUnitSystem">A system for finding preplaced units on the map.</param>
    public LegendScourge(PreplacedUnitSystem preplacedUnitSystem)
    {
      Kelthuzad = new LegendaryHero("Kel'thuzad")
      {
        UnitType = FourCC("U001"),
        PermaDies = true,
        DeathSfx = "Abilities\\Spells\\Undead\\DeathCoil\\DeathCoilSpecialArt.mdl",
        StartingXp = 1000
      };
      LegendaryHeroManager.Register(Kelthuzad);

      Anubarak = new LegendaryHero("Anub'arak")
      {
        UnitType = FourCC("Uanb")
      };
      LegendaryHeroManager.Register(Anubarak);

      Rivendare = new LegendaryHero("Baron Rivendare")
      {
        UnitType = FourCC("U00A"),
        StartingXp = 1000
      };
      LegendaryHeroManager.Register(Rivendare);

      Arthas = new LegendaryHero("Arthas Menethil")
      {
        UnitType = Constants.UNIT_UEAR_CHAMPION_OF_THE_SCOURGE_SCOURGE,
        StartingXp = 7000
      };
      LegendaryHeroManager.Register(Arthas);
      
      LegendUtgarde = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("h00O")),
        Capturable = true
      };
      CapitalManager.Register(LegendUtgarde);

      LegendLichking = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("u000")),
        Hivemind = true,
        DeathMessage =
          "The great Lich King has been destroyed. With no central mind to command them, the forces of the Undead have gone rogue."
      };
      CapitalManager.Register(LegendLichking);
      LegendLichking.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_N094_ICECROWN_OBELISK_RED, new Point(-3655, 20220)));
      LegendLichking.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_N094_ICECROWN_OBELISK_RED, new Point(-3015, 20762)));
      LegendLichking.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_N094_ICECROWN_OBELISK_RED, new Point(-3643, 22588)));
      LegendLichking.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_N094_ICECROWN_OBELISK_RED, new Point(-3638, 23374)));
      CreateTrigger()
        .RegisterUnitEvent(LegendLichking.Unit, EVENT_UNIT_CHANGE_OWNER)
        .AddAction(() =>
      {
        if (LegendLichking.Unit.OwningPlayer() != Player(bj_PLAYER_NEUTRAL_VICTIM))
          LegendLichking.Unit.SetOwner(Player(bj_PLAYER_NEUTRAL_VICTIM));
      });
    }
  }
}