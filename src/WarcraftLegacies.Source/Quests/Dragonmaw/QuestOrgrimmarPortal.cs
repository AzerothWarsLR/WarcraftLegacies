using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using System;
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
    /// <param name="waygateDragonmawPort">Starts hidden and gets revealed when the quest is complete.</param>
    public QuestOrgrimmarPortal(unit waygateDragonmawPort) : base(
      "The Reunification of the Horde",
      "The new Horde in Kalimdor has send a message to the Dragonmaw Clan to join them, Zaela has foreseen it to be the salvation of the Dragonmaw Clan. But the portal will be unstable, as soon as it is open, we should escape with great haste",
      "ReplaceableTextures\\CommandButtons\\BTNPortal.blp")
    {
      _waygateDragonmawPort = waygateDragonmawPort;

      AddObjective(new ObjectiveControlLegend(LegendDragonmaw.DragonmawPort, false));
      AddObjective(new ObjectiveControlLegend(LegendNeutral.GrimBatol, false));
      waygateDragonmawPort.Show(false);
      Required = true;
      Global = true;
    }

    /// <inheritdoc />
    protected override string CompletionPopup =>
      "The portal to Kalimdor is opened! Hurry, it will collapse in 60 seconds!";

    /// <inheritdoc />
    protected override string RewardDescription => "Open a Portal between Dragonmaw Port and Orgrimmar";

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

    /// <inheritdoc />
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