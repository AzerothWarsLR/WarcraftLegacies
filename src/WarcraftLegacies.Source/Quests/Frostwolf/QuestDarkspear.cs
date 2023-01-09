using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using System.Collections.Generic;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Frostwolf
{
  /// <summary>
  /// Bring <see cref="LegendFrostwolf.LegendVolJin"/> to the Echo Isles to unlock the base
  /// </summary>
  public sealed class QuestDarkspear : QuestData
  {
    private readonly List<unit> _rescueUnits;

    /// <inheritdoc />
    public QuestDarkspear() : base("The Darkspear Trolls",
      "After the Darkspear trolls were rescued by Thrall, Vol'jin pledged his loyalty and service to the Horde. The trolls must now be gathered to help in the fight against the night elves.",
      "ReplaceableTextures\\CommandButtons\\BTNSorceressMaster.blp")
    {
      _rescueUnits = Regions.EchoUnlock.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      AddObjective(new ObjectiveSelfExists());
      AddObjective(new ObjectiveExpire(1455));
      AddObjective(new ObjectiveAnyUnitInRect(Regions.EchoUnlock, "Echo Isles", true));
      Required = true;
    }

    /// <inheritdoc />
    protected override string CompletionPopup => "Vol'jin has made contact with the Darkspear trolls on the Echo Isles. They are now yours to command!";

    /// <inheritdoc />
    protected override string RewardDescription => "Unlock the troll base on the Echo Isles.";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
        completingFaction.Player?.RescueGroup(_rescueUnits);
    }
  }
}
