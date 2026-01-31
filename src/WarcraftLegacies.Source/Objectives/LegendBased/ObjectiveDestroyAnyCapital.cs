using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

public sealed class ObjectiveDestroyAnyCapital : Objective
{
  /// <summary>
  /// The <see cref="Capital"/> that was destroyed to complete the objective, if any.
  /// </summary>
  public Capital? DestroyedCapital { get; private set; }

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveDestroyAnyCapital"/> class.
  /// </summary>
  public ObjectiveDestroyAnyCapital()
  {
    Description = "Destroy any enemy capital";
  }

  /// <inheritdoc />
  public override void OnAdd(Faction faction)
  {
    CapitalManager.CapitalDestroyed += (_, capital) =>
    {
      if (IsPlayerOnSameTeamAsAnyEligibleFaction(@event.KillingUnit.Owner))
      {
        DestroyedCapital = capital;
        Progress = QuestProgress.Complete;
      }
    };
  }
}
