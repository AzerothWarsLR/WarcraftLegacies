using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Events;
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
      "TODO Yogg-Saron cool description for Yak",
      @"ReplaceableTextures\CommandButtons\BTNYogg-saronIcon.blp")
    {
      _yoggsaron = yoggsaron;
      _yoggsaronPrison = yoggsaronPrison
        .MakeCapturable()
        .SetOwner(Player(PLAYER_NEUTRAL_PASSIVE))
        .SetInvulnerable(true);

      _heroInRectObjective =
        new ObjectiveHeroWithLevelInRect(14, Regions.YoggSaronPrison, "the Prison of Yogg-Saron");
      AddObjective(_heroInRectObjective);
      PlayerUnitEvents.Register(UnitEvent.SpellEffect, OnCastSummonSpell, _yoggsaronPrison);
      IsFactionQuest = false;
    }

    /// <inheritdoc/>
    protected override string RewardDescription => "Yogg-Saron is emprisonned near Storm peaks, and can be slain to acquire X";

    /// <inheritdoc/>
    public override string RewardFlavour => $"{_heroInRectObjective.CompletingUnitName} has seized control of the prison of Yogg-Saron, and can now free him.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      _yoggsaronPrison
        .SetOwner(_heroInRectObjective.CompletingUnit?.OwningPlayer() ?? Player(PLAYER_NEUTRAL_AGGRESSIVE))
        .SetInvulnerable(false);
    }

    private void OnCastSummonSpell()
    {
      var yoggsaronSummonPoint = new Point(3995, 23488);
      _yoggsaron.ForceCreate(Player(PLAYER_NEUTRAL_AGGRESSIVE), yoggsaronSummonPoint, 320);
      AddSpecialEffect(@"Abilities\Spells\Human\Thunderclap\ThunderClapCaster.mdl", yoggsaronSummonPoint.X,
          yoggsaronSummonPoint.Y)
        .SetScale(2)
        .SetLifespan(1);
      _yoggsaronPrison.Kill();

      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        player.DisplayLegendaryHeroSummoned(_yoggsaron,
          "TODO right a cool description of Yogg-saron being summoned yak!");
    }
  }
}