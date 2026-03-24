using MacroTools.Extensions;
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
    Description = "Destroy any player-owned enemy capital";
  }

  /// <inheritdoc />
  public override void OnAdd(Faction faction)
  {
    CapitalManager.CapitalDestroyed += capital =>
    {
      if (capital.Unit == null)
      {
        return;
      }

      var capitalOwner = capital.Unit.Owner;
      var capitalOwnerData = capitalOwner.GetPlayerData();
      var capitalOwnerTeam = capitalOwnerData.Team;

      if (faction.Player == null ||
          faction.Player.GetPlayerData().Team == capitalOwnerTeam ||
          capitalOwnerData.Faction == null)
      {
        return;
      }

      if (!IsPlayerOnSameTeamAsAnyEligibleFaction(@event.KillingUnit.Owner))
      {
        return;
      }

      DestroyedCapital = capital;
      Progress = QuestProgress.Complete;
    };
  }
}
