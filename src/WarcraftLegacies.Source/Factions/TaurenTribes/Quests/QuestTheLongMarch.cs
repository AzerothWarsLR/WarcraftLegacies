using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Factions;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Quests;

/// <summary>
/// The Tauren Tribes' starting quest. Their camp packs up into a caravan of pack kodos, which marches from the
/// starting camp to Stonemaul Keep and then Thunder Bluff, handing off each base as it arrives.
/// </summary>
public sealed class QuestTheLongMarch : QuestData
{
  private const int GoldPerSurvivingKodo = 75;
  private const int ExperiencePerSurvivingKodo = 250;

  private List<unit> _kodos = new();
  private ObjectiveCaravanArrives? _thousandNeedlesObjective;
  private ObjectiveCaravanArrives? _stonemaulObjective;
  private ObjectiveCaravanArrives? _mulgoreObjective;
  private ObjectiveCaravanArrives? _thunderBluffObjective;

  public QuestTheLongMarch() : base("The Long March",
    "The Tauren tribes must abandon their ancestral camp and march east across the Barrens, escorted by a handful of guards, to build a new home at Thunder Bluff. Centaur raiders infest the plains between here and there.",
    @"ReplaceableTextures\CommandButtons\BTNHeroTaurenChieftain.blp")
  {
    AddObjective(new ObjectiveSelfExists());
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "Battered but unbroken, the Tauren tribes complete their long march and raise Thunder Bluff on the plains of Mulgore.";

  /// <inheritdoc />
  public override string PenaltyFlavour =>
    "The kodo caravan is lost along the way, but the Tauren tribes stagger into Thunder Bluff regardless, battered and few.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    "Control of Stonemaul Keep and Thunder Bluff, plus gold and experience scaled by how many pack kodos survive the march";

  /// <summary>
  /// Adds the objectives that track the caravan's journey. Called once the camp has packed up into kodos.
  /// </summary>
  public void BeginMarch(List<unit> kodos, Point thousandNeedles, Rectangle stonemaulKeep, Point mulgore,
    Rectangle thunderBluff)
  {
    _kodos = kodos;
    _thousandNeedlesObjective = new ObjectiveCaravanArrives(thousandNeedles, "Thousand Needles");
    AddObjective(_thousandNeedlesObjective);
    _stonemaulObjective = new ObjectiveCaravanArrives(stonemaulKeep, "Stonemaul Keep");
    AddObjective(_stonemaulObjective);
    _mulgoreObjective = new ObjectiveCaravanArrives(mulgore, "Mulgore");
    AddObjective(_mulgoreObjective);
    _thunderBluffObjective = new ObjectiveCaravanArrives(thunderBluff, "Thunder Bluff");
    AddObjective(_thunderBluffObjective);
    AddObjective(new ObjectiveCaravanSurvives(kodos));
  }

  /// <summary>Marks the Thousand Needles waypoint reached. Called by <see cref="WarcraftLegacies.Source.Factions.TaurenTribes.Mechanics.LongMarchCaravan"/>.</summary>
  public void MarkThousandNeedlesReached() => _thousandNeedlesObjective!.Progress = QuestProgress.Complete;

  /// <summary>Marks the Stonemaul Keep waypoint reached. Called by <see cref="WarcraftLegacies.Source.Factions.TaurenTribes.Mechanics.LongMarchCaravan"/>.</summary>
  public void MarkStonemaulReached() => _stonemaulObjective!.Progress = QuestProgress.Complete;

  /// <summary>Marks the Mulgore waypoint reached. Called by <see cref="WarcraftLegacies.Source.Factions.TaurenTribes.Mechanics.LongMarchCaravan"/>.</summary>
  public void MarkMulgoreReached() => _mulgoreObjective!.Progress = QuestProgress.Complete;

  /// <summary>Marks the Thunder Bluff waypoint reached. Called by <see cref="WarcraftLegacies.Source.Factions.TaurenTribes.Mechanics.LongMarchCaravan"/>.</summary>
  public void MarkThunderBluffReached() => _thunderBluffObjective!.Progress = QuestProgress.Complete;

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
