using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Effects;
using WCSharp.Events;
using WCSharp.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests;

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
    yoggsaronPrison.SetOwner(player.NeutralPassive);
    yoggsaronPrison.IsInvulnerable = true;
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
    var newOwner = _heroInRectObjective.CompletingUnit == null
      ? player.NeutralAggressive
      : _heroInRectObjective.CompletingUnit.Owner;

    _yoggsaronPrison.SetOwner(newOwner);
    _yoggsaronPrison.IsInvulnerable = false;
  }

  private void OnCastSummonSpell()
  {
    var yoggsaronSummonPoint = new Point(3995, 23488);
    _yoggsaron.ForceCreate(player.NeutralAggressive, yoggsaronSummonPoint, 320);
    effect effect = effect.Create(@"Abilities\Spells\Human\Thunderclap\ThunderClapCaster.mdl", yoggsaronSummonPoint.X, yoggsaronSummonPoint.Y);
    effect.Scale = 2;
    EffectSystem.Add(effect, 1);
    _yoggsaronPrison.Kill();

    foreach (var player in Util.EnumeratePlayers())
    {
      player.DisplayLegendaryHeroSummoned(_yoggsaron,
        "LOOK UPON YOGG-SARON, GOD OF DEATH, AND KNOW THAT YOUR END COMES SOON!");
    }
  }
}
