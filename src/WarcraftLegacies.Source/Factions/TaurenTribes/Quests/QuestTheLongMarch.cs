using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Quests;

/// <summary>
/// The Tauren Tribes' starting quest. Their camp packs up into a caravan of pack kodos, which marches from the
/// starting camp to Thunder Bluff, handing off each base as it arrives.
/// </summary>
public sealed class QuestTheLongMarch : QuestData
{
  private const int GoldPerSurvivingKodo = 75;
  private const int ExperiencePerSurvivingKodo = 250;

  private List<unit> _kodos = new();
  private readonly ObjectiveCaravanArrives _thousandNeedlesObjective;
  private readonly ObjectiveCaravanArrives _mulgoreObjective;
  private readonly ObjectiveCaravanArrives _thunderBluffObjective;

  public QuestTheLongMarch(LegendaryHero cairneBloodhoof, Point thousandNeedles, Point mulgore,
    Rectangle thunderBluff) : base("The Long March",
    "The Tauren tribes must abandon their ancestral camp and march east across the Barrens, to their new home at Thunder Bluff. The march sets out as soon as Cairne Bloodhoof takes up the lead, joined by a war party of Tauren and Spirit Walkers. Centaur raiders infest the plains between here and there. Until the march is over, no units can be trained, but the elders of Thunder Bluff can already begin their research.",
    @"ReplaceableTextures\CommandButtons\BTNHeroTaurenChieftain.blp")
  {
    AddObjective(new ObjectiveSelfExists());
    AddObjective(new ObjectiveControlLegend(cairneBloodhoof, false));

    _thousandNeedlesObjective = new ObjectiveCaravanArrives(thousandNeedles, "Thousand Needles");
    AddObjective(_thousandNeedlesObjective);
    _mulgoreObjective = new ObjectiveCaravanArrives(mulgore, "Mulgore");
    AddObjective(_mulgoreObjective);
    _thunderBluffObjective = new ObjectiveCaravanArrives(thunderBluff, "Thunder Bluff");
    AddObjective(_thunderBluffObjective);
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "Battered but unbroken, the Tauren tribes complete their long march and settle at Thunder Bluff on the plains of Mulgore.";

  /// <inheritdoc />
  public override string PenaltyFlavour =>
    "The kodo caravan is lost along the way, but the Tauren tribes stagger into Thunder Bluff regardless, battered and few.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    "The defenders of Thunder Bluff join you, and you gain gold and experience scaled by how many pack kodos survive the march";

  /// <inheritdoc />
  protected override string PenaltyDescription =>
    "The defenders of Thunder Bluff join you, although injured";

  /// <summary>
  /// Adds the objective tracking the caravan's survival. Called once the camp has packed up into kodos.
  /// </summary>
  public void BeginMarch(List<unit> kodos)
  {
    _kodos = kodos;
    AddObjective(new ObjectiveCaravanSurvives(kodos));
  }

  /// <summary>Marks the Thousand Needles waypoint reached. Called by <see cref="WarcraftLegacies.Source.Factions.TaurenTribes.Mechanics.LongMarchCaravan"/>.</summary>
  public void MarkThousandNeedlesReached() => _thousandNeedlesObjective.Progress = QuestProgress.Complete;

  /// <summary>Marks the Mulgore waypoint reached. Called by <see cref="WarcraftLegacies.Source.Factions.TaurenTribes.Mechanics.LongMarchCaravan"/>.</summary>
  public void MarkMulgoreReached() => _mulgoreObjective.Progress = QuestProgress.Complete;

  /// <summary>Marks the Thunder Bluff waypoint reached. Called by <see cref="WarcraftLegacies.Source.Factions.TaurenTribes.Mechanics.LongMarchCaravan"/>.</summary>
  public void MarkThunderBluffReached() => _thunderBluffObjective.Progress = QuestProgress.Complete;

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    GrantReward(completingFaction, _kodos.Count(kodo => kodo.Alive));
  }

  /// <inheritdoc />
  protected override void OnFail(Faction completingFaction)
  {
    GrantReward(completingFaction, 0);
  }

  private static void GrantReward(Faction completingFaction, int survivingKodos)
  {
    var rewardedPlayer = completingFaction.Player;
    if (rewardedPlayer == null)
    {
      return;
    }

    rewardedPlayer.SetTechResearched(UPGRADE_RT20_QUEST_CONCLUDED_THE_LONG_MARCH_TAUREN_TRIBES, 1);
    var multiplier = Math.Max(survivingKodos, 1);
    rewardedPlayer.Gold += GoldPerSurvivingKodo * multiplier;

    var heroes = GlobalGroup.EnumUnitsOfPlayer(rewardedPlayer).Where(hero => hero.IsUnitType(unittype.Hero)).ToList();
    if (heroes.Count == 0)
    {
      return;
    }

    var experiencePerHero = ExperiencePerSurvivingKodo * multiplier / heroes.Count;
    foreach (var hero in heroes)
    {
      AddHeroXP(hero, experiencePerHero, true);
    }
  }
}
