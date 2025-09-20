using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.MetaBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Fel_Horde;

public sealed class QuestDarkPortal : QuestData
{
  private readonly unit _innerWaygate1;
  private readonly unit _innerWaygate2;
  private readonly unit _innerWaygate3;
  private readonly unit _outerWaygate1;
  private readonly unit _outerWaygate2;
  private readonly unit _outerWaygate3;

  /// <summary>
  /// Initializes a new instance of the class <see cref="QuestDarkPortal"/>.
  /// </summary>
  /// <param name="innerWaygate1">A Waygate inside outland, next to the Dark Portal.</param>
  /// <param name="innerWaygate2">A Waygate inside outland, next to the Dark Portal.</param>
  /// <param name="innerWaygate3">A Waygate inside outland, next to the Dark Portal.</param>
  /// <param name="outerWaygate1">A Waygate outside outland, next to the Dark Portal.</param>
  /// <param name="outerWaygate2">A Waygate outside outland, next to the Dark Portal.</param>
  /// <param name="outerWaygate3">A Waygate outside outland, next to the Dark Portal.</param>
  public QuestDarkPortal(unit innerWaygate1, unit innerWaygate2, unit innerWaygate3, unit outerWaygate1,
    unit outerWaygate2, unit outerWaygate3)
    : base("The Dark Portal",
      "Following the Second War, the archmage Khadgar and his fellow magi sealed the Dark Portal so that it would never again be used to threaten Azeroth. Little did they know that their magicks were only temporary, and that the portal would open again in time.",
      @"ReplaceableTextures\CommandButtons\BTNDarkPortal.blp")
  {
    ShowUnit(innerWaygate1, false);
    _innerWaygate1 = innerWaygate1;
    ShowUnit(innerWaygate2, false);
    _innerWaygate2 = innerWaygate2;
    ShowUnit(innerWaygate3, false);
    _innerWaygate3 = innerWaygate3;
    ShowUnit(outerWaygate1, false);
    _outerWaygate1 = outerWaygate1;
    ShowUnit(outerWaygate2, false);
    _outerWaygate2 = outerWaygate2;
    ShowUnit(outerWaygate3, false);
    _outerWaygate3 = outerWaygate3;
    AddObjective(new ObjectiveEitherOf(
      new ObjectiveResearch(UPGRADE_R02C_THE_DARK_PORTAL_FEL_HORDE, UNIT_O008_HELLFIRE_CITADEL_FEL_HORDE, true),
      new ObjectiveTime(600)));
    AddObjective(new ObjectiveTime(480));
    Global = true;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "The Dark Portal, previously thought to have been sealed forever, has been opened once more. The people of Stormwind are about to relive their worst nightmares, as the demonic Fel Horde spills forth from Outland to resume their slaughterous rampage.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    "The Dark Portal can be used to teleport units between the Eastern Kingdoms and Outland";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction) => OpenPortal();

  /// <inheritdoc />
  protected override void OnAdd(Faction whichFaction) =>
    whichFaction.ModObjectLimit(UPGRADE_R02C_THE_DARK_PORTAL_FEL_HORDE, Faction.Unlimited);

  private void OpenPortal()
  {
    ShowUnit(_innerWaygate1, true);
    _innerWaygate1
      .SetWaygateDestination(Regions.Dark_Portal_Exit_1.Center);
    ShowUnit(_innerWaygate2, true);
    _innerWaygate2
      .SetWaygateDestination(Regions.Dark_Portal_Exit_2.Center);
    ShowUnit(_innerWaygate3, true);
    _innerWaygate3
      .SetWaygateDestination(Regions.Dark_Portal_Exit_3.Center);
    ShowUnit(_outerWaygate1, true);
    _outerWaygate1
      .SetWaygateDestination(Regions.Dark_Portal_Entrance_1.Center);
    ShowUnit(_outerWaygate2, true);
    _outerWaygate2
      .SetWaygateDestination(Regions.Dark_Portal_Entrance_2.Center);
    ShowUnit(_outerWaygate3, true);
    _outerWaygate3
      .SetWaygateDestination(Regions.Dark_Portal_Entrance_3.Center);
  }
}
