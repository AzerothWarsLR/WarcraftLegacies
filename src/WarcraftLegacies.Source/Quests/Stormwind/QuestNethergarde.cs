using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Stormwind
{
  public sealed class QuestNethergarde : QuestData
  {
    private readonly List<unit> _rescueUnits;

    public QuestNethergarde() : base("Nethergarde Relief",
      "Nethergarde Keep fort is holding down the Dark Portal, they will need to be reinforced soon!",
      "ReplaceableTextures\\CommandButtons\\BTNStormwindGuardTower.blp")
    {
      AddObjective(new ObjectiveLegendInRect(LegendStormwind.Varian, Regions.NethergardeUnlock, "Nethergarde"));
      AddObjective(new ObjectiveExpire(1440));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = Regions.NethergardeUnlock.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    }

    /// <inheritdoc />
    protected override string CompletionPopup => "Varian has come to relieve the Nethergarde garrison.";

    /// <inheritdoc />
    protected override string RewardDescription => "You gain control of Nethergarde";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player.RescueGroup(_rescueUnits);
    }
  }
}