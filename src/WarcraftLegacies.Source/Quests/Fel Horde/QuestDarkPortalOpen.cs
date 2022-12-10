using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Fel_Horde
{
  public sealed class QuestDarkPortalOpen : QuestData
  {
    private readonly unit _portalController;
    private readonly unit _innerWaygate1;
    private readonly unit _innerWaygate2;
    private readonly unit _innerWaygate3;
    private readonly unit _outerWaygate1;
    private readonly unit _outerWaygate2;
    private readonly unit _outerWaygate3;

    /// <summary>
    /// Initializes a new instance of the class <see cref="QuestDarkPortalOpen"/>.
    /// </summary>
    /// <param name="portalController"></param>
    /// <param name="innerWaygate1">A Waygate inside outland, next to the Dark Portal.</param>
    /// <param name="innerWaygate2">A Waygate inside outland, next to the Dark Portal.</param>
    /// <param name="innerWaygate3">A Waygate inside outland, next to the Dark Portal.</param>
    /// <param name="outerWaygate1">A Waygate outside outland, next to the Dark Portal.</param>
    /// <param name="outerWaygate2">A Waygate outside outland, next to the Dark Portal.</param>
    /// <param name="outerWaygate3">A Waygate outside outland, next to the Dark Portal.</param>
    public QuestDarkPortalOpen(unit portalController, unit innerWaygate1, unit innerWaygate2, unit innerWaygate3, unit outerWaygate1, unit outerWaygate2, unit outerWaygate3)
      : base("The Dark Portal Opens", "The Dark Portal has been opened.", "ReplaceableTextures\\CommandButtons\\BTNDarkPortal.blp")
    {
      _portalController = portalController;
      _innerWaygate1 = innerWaygate1;
      _innerWaygate2 = innerWaygate2;
      _innerWaygate3 = innerWaygate3;
      _outerWaygate1 = outerWaygate1.Show(false);
      _outerWaygate2 = outerWaygate2.Show(false);
      _outerWaygate3 = outerWaygate3.Show(false);
      AddObjective(new ObjectiveTime(600));
      AddObjective(new ObjectiveExpire(785));
      AddObjective(new ObjectiveSelfExists());
      Global = true;
    }
    
    /// <inheritdoc />
    protected override string CompletionPopup => "The Dark Portal is now open.";

    /// <inheritdoc />
    protected override string RewardDescription => "The Dark Portal is now open";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction) => OpenPortal();

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction) => OpenPortal();

    private void OpenPortal()
    {
      _portalController.SetInvulnerable(false);
      _innerWaygate1.SetWaygateDestination(Regions.Dark_Portal_Exit_1.Center);
      _innerWaygate2.SetWaygateDestination(Regions.Dark_Portal_Exit_2.Center);
      _innerWaygate3.SetWaygateDestination(Regions.Dark_Portal_Exit_3.Center);
      _outerWaygate1
        .Show(true)
        .SetWaygateDestination(Regions.Dark_Portal_Entrance_1.Center);
      _outerWaygate2
        .Show(true)
        .SetWaygateDestination(Regions.Dark_Portal_Entrance_2.Center);
      _outerWaygate3
        .Show(true)
        .SetWaygateDestination(Regions.Dark_Portal_Entrance_3.Center);
    }
  }
}
