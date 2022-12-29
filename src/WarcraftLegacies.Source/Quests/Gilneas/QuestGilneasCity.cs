using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using System.Collections.Generic;
using static War3Api.Common;
using MacroTools.Extensions;
using MacroTools.ObjectiveSystem.Objectives;

namespace WarcraftLegacies.Source.Quests.Gilneas
{
  /// <summary>
  /// Kill Worgen in and around Gilneas and upgrade the main building to Tier 3 in order to unlock Gilneas City and the Greymane Wall
  /// </summary>
  public class QuestGilneasCity : QuestData
  {
    private List<unit> _rescueUnits { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestGilneasCity"/> class.
    /// </summary>
    public QuestGilneasCity() : base("Liberation of Gilneas", "Gilneas has been under the curse of the Worgen. Eliminate all of them to free Gilneas of the curse.", "ReplaceableTextures\\CommandButtons\\BTNGilneasCathedral.blp")
    {
      AddObjective(new ObjectiveKillXUnit(Constants.UNIT_O02J_WORGEN_GILNEAS, 11));
      AddObjective(new ObjectiveKillXUnit(Constants.UNIT_O038_WORGEN_BLOOD_SHAMAN_WORGEN_HERO, 4));
      AddObjective(new ObjectiveUpgrade(Constants.UNIT_H02C_CASTLE_GILNEAS_T3, Constants.UNIT_H01R_TOWN_HALL_GILNEAS_T1));
      AddObjective(new ObjectiveExpire(1300));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = Regions.GilneasUnlock5.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      _rescueUnits.AddRange(Regions.GilneasUnlock6.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures));
      ResearchId = Constants.UPGRADE_R02R_QUEST_COMPLETED_LIBERATION_OF_GILNEAS;
      Required = true;
    }

    /// <inheritdoc/>
    protected override string CompletionPopup => "Every worgen has been eliminated, the curse is lifting!";

    /// <inheritdoc/>
    protected override string RewardDescription => "Gain control of the Greymane Wall and Gilneas City.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      if (whichFaction.Player != null)
      {
        whichFaction.Player.RescueGroup(_rescueUnits);
        if (GetLocalPlayer() == whichFaction.Player)
          PlayThematicMusic("war3mapImported\\GilneasTheme1.mp3");
      }
    }

    /// <inheritdoc/>
    protected override void OnFail(Faction whichFaction)
    {
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
    }
  }
}
