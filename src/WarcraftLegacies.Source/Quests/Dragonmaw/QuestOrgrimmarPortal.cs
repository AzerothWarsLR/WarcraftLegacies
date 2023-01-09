using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using System;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Dragonmaw
{
  /// <summary>
  /// Dragonmaw opens a portal to Orgrimmar.
  /// </summary>
  public sealed class QuestOrgrimmarPortal : QuestData
  {
    private readonly unit _waygateDragonmawPort;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestOrgrimmarPortal"/> class.
    /// </summary>
    /// <param name="prequel">This quest must be completed first.</param>
    /// <param name="waygateDragonmawPort">Starts hidden and gets revealed when the quest is complete.</param>
    public QuestOrgrimmarPortal(QuestData prequel, unit waygateDragonmawPort) : base(
      "The Reunification of the Horde",
      "The new Horde in Kalimdor has send a message to the Dragonmaw Clan to join them, Zaela has foreseen it to be the salvation of the Dragonmaw Clan. But the portal will be unstable, as soon as it is open, we should escape with great haste",
      "ReplaceableTextures\\CommandButtons\\BTNPortal.blp")
    {
      _waygateDragonmawPort = waygateDragonmawPort;

      AddObjective(new ObjectiveCompleteQuest(prequel));
      AddObjective(new ObjectiveControlCapital(LegendNeutral.GrimBatol, false));
      waygateDragonmawPort.Show(false);
      Required = true;
    }

    /// <inheritdoc />
    protected override string CompletionPopup =>
      "The portal to Kalimdor will open at turn 9! Once it does, hurry! it will only last for 60 seconds.";

    /// <inheritdoc />
    protected override string RewardDescription => "Will make the Orgrimar Portal open at turn 9. The portal will stay open only for 60 seconds!";

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      var timeUntilReward = 540 - GameTime.GetGameTime();
      if (timeUntilReward <= 0)
        GiveReward(completingFaction);
      else
        CreateTimer().Start(Math.Max(540 - GameTime.GetGameTime(), 0), false, () =>
        {
          GiveReward(completingFaction);
        });
    }
    
    private void GiveReward(Faction completingFaction)
    {
      _waygateDragonmawPort
        .Show(true)
        .SetWaygateDestination(Regions.OrgrimmarPortal.Center);
      CreateTimer().Start(60, false, () =>
      {
        _waygateDragonmawPort.Kill();
        GetExpiredTimer().Destroy();
      });
      if (completingFaction.Player != null)
        completingFaction.Player?.SetTeam(TeamSetup.Horde);

    }
  }
}