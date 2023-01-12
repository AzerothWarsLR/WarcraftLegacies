using System.Collections.Generic;
using MacroTools;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Dragonmaw
{
  public sealed class QuestDragonmawPort : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestDragonmawPort(PreplacedUnitSystem preplacedUnitSystem, Rectangle rescueRect, unit waygateDragonmawPort) : base("Dragonmaw Port",
      "The Dragonmaw Port will be the site of the portal summoning to escape to kalimdor! The Tyrant Mor'ghor and his followers have taken control of the Port, kill him to reunite the clan. ",
      "ReplaceableTextures\\CommandButtons\\BTNIronHordeSummoningCircle.blp")
    {
      AddObjective(
        new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N08T_DRAGONMAW_PORT_10GOLD_MIN)));
      AddObjective(new ObjectiveUnitIsDead(preplacedUnitSystem.GetUnit(Constants.UNIT_N0DA_OVERLORD_DRAGONMAW_QUEST)));
      AddObjective(new ObjectiveControlLegend(LegendDragonmaw.Zaela, false));
      AddObjective(new ObjectiveExpire(480));
      AddObjective(new ObjectiveSelfExists());

      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.Invulnerable);
      _rescueUnits.Remove(waygateDragonmawPort);
      Required = true;
    }

    //Todo: bad flavour
    /// <inheritdoc />
    protected override string RewardFlavour =>
      "Dragonmaw Port has fallen under our control.";

    /// <inheritdoc />
    protected override string RewardDescription => "Control of all buildings in Dragonmaw Port";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      if (completingFaction?.Player == GetLocalPlayer())
        PlayThematicMusic("war3mapImported\\DragonmawTheme.mp3");
      completingFaction.Player?.RescueGroup(_rescueUnits);
    }
  }
}