using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Events;
using WCSharp.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests
{
  /// <summary>
  /// Any player owns the yogg prison, cast a spell on it, and has a high level hero.
  /// </summary>
  public sealed class QuestYoggSaron : QuestData
  {
    private readonly LegendaryHero _yoggsaron;
    private readonly unit _yoggsaronPrison;
    private readonly ObjectiveHeroWithLevelInRect _heroInRectObjective;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestYoggSaron"/> class.
    /// </summary>
    public QuestYoggSaron(LegendaryHero yoggsaron, unit yoggsaronPrison) : base("The Beast With a Thousand Maws",
      "Yogg-Saron rests dormant in Ulduar but his corruption seeps out from his prison. Once we are strong enough, we should open his prison and confront the Old God.",
      @"ReplaceableTextures\CommandButtons\BTNYogg-saronIcon.blp")
    {
      _yoggsaron = yoggsaron;
      yoggsaronPrison.MakeCapturable();
      SetUnitOwner(yoggsaronPrison, Player(PLAYER_NEUTRAL_PASSIVE), true);
      SetUnitInvulnerable(yoggsaronPrison, true);
      _yoggsaronPrison = yoggsaronPrison;

      _heroInRectObjective =
        new ObjectiveHeroWithLevelInRect(14, Regions.YoggSaronPrison, "the Prison of Yogg-Saron");
      AddObjective(_heroInRectObjective);
      PlayerUnitEvents.Register(UnitEvent.SpellEffect, OnCastSummonSpell, _yoggsaronPrison);
      IsFactionQuest = false;
    }

    /// <inheritdoc/>
    protected override string RewardDescription => "Gain the ability to release Yogg-Saron from his near Storm peaks; he can be slain to acquire Val'anyr, Hammer of Ancient Kings";

    /// <inheritdoc/>
    public override string RewardFlavour => $"{_heroInRectObjective.CompletingUnitName} has seized control of the prison of Yogg-Saron, and can now free him.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      player whichPlayer = _heroInRectObjective.CompletingUnit?.OwningPlayer() ?? Player(PLAYER_NEUTRAL_AGGRESSIVE);
      SetUnitOwner(_yoggsaronPrison, whichPlayer, true);
      SetUnitInvulnerable(_yoggsaronPrison, false);
    }

    private void OnCastSummonSpell()
    {
      var yoggsaronSummonPoint = new Point(3995, 23488);
      _yoggsaron.ForceCreate(Player(PLAYER_NEUTRAL_AGGRESSIVE), yoggsaronSummonPoint, 320);
      AddSpecialEffect(@"Abilities\Spells\Human\Thunderclap\ThunderClapCaster.mdl", yoggsaronSummonPoint.X,
          yoggsaronSummonPoint.Y)
        .SetScale(2)
        .SetLifespan(1);
      KillUnit(_yoggsaronPrison);

      foreach (var player in Util.EnumeratePlayers())
        player.DisplayLegendaryHeroSummoned(_yoggsaron,
          "LOOK UPON YOGG-SARON, GOD OF DEATH, AND KNOW THAT YOUR END COMES SOON!");
    }
  }
}