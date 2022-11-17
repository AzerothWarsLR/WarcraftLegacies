using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
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
      "The new Horde in Kalimdor has send a message to the Dragonmaw Clan to join them, Zuluhead will need to open a portal for his people to go through!",
      "ReplaceableTextures\\CommandButtons\\BTNPortal.blp")
    {
      _waygateDragonmawPort = waygateDragonmawPort;

      AddObjective(new ObjectiveControlLegend(LegendNeutral.LegendGrimbatol, false));
      waygateDragonmawPort.Show(false);
      Required = true;
    }

    /// <inheritdoc />
    protected override string CompletionPopup =>
      "Zuluhead has opened the portal to Orgrimmar. Hurry, it will collapse in 3 mins";

    /// <inheritdoc />
    protected override string RewardDescription => "Open a Portal between Dragonmaw Port and Orgrimmar";

    /// <inheritdoc />
    protected override void OnComplete(Faction whichFaction)
    {
      _waygateDragonmawPort
        .Show(true)
        .SetWaygateDestination(Regions.OrgrimmarPortal.Center);
      CreateTimer().Start(180, false, () =>
      {
        _waygateDragonmawPort.Kill();
        GetExpiredTimer().Destroy();
      });
      if (whichFaction.Player != null)
        whichFaction.Player?.SetTeam(TeamSetup.Horde);

    }
  }
}