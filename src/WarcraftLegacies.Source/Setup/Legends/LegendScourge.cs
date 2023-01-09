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
  public static class LegendScourge
  {
    /// <summary>
    /// Leader of the Cult of the Damned.
    /// </summary>
    public static LegendaryHero? Kelthuzad { get; private set; }
    
    /// <summary>
    /// Fallen king of the Nerubians.
    /// </summary>
    public static LegendaryHero? Anubarak { get; private set; }
    
    /// <summary>
    /// Ruler of Stratholme after it's taken over by the Scourge.
    /// </summary>
    public static LegendaryHero? Rivendare { get; private set; }
    
    /// <summary>
    /// Psychic ruler of the Scourge.
    /// </summary>
    public static Capital? LegendLichking { get; private set; }
    
    /// <summary>
    /// A Vrykul stronghold.
    /// </summary>
    public static Capital? LegendUtgarde { get; private set; }
    
    /// <summary>
    /// Mobile Scourge Necropolis.
    /// </summary>
    public static Capital? Naxxramas { get; private set; }

    /// <summary>
    /// Sets up <see cref="LegendScourge"/>.
    /// </summary>
    /// <param name="preplacedUnitSystem">A system for finding preplaced units on the map.</param>
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      Kelthuzad = new LegendaryHero("Kel'thuzad")
      {
        UnitType = FourCC("U001"),
        PermaDies = true,
        DeathMessage =
          "Kel'thuzad has been slain. He lives on in spectral form, and may yet return if he is brought to the Sunwell.",
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

      Naxxramas = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_U01X_HEART_OF_NAXXRAMAS_SCOURGE_NAXXRAMAS_INTERIOR)
      };
      CapitalManager.Register(Naxxramas);
      SetUnitInvulnerable(Naxxramas.Unit, true);
      SetUnitTimeScale(Naxxramas.Unit, 0);
    }
  }
}