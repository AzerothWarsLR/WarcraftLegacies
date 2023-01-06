using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Naga
{
  /// <summary>
  /// Illidan acquires the Black Temple.
  /// </summary>
  public sealed class QuestBlackTemple : QuestData
  {
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestBlackTemple"/> class.
    /// </summary>
    /// <param name="rescueRect"></param>
    public QuestBlackTemple(Rectangle rescueRect) : base("Seat of Power",
      "A small remnant of Illidan's Naga have held on in the Broken Isles, we need to make contact with them",
      "ReplaceableTextures\\CommandButtons\\BTNWarpPortal.blp")
    {
      AddObjective(new ObjectiveLegendInRect(LegendNaga.LegendIllidan, Regions.IllidanBlackTempleUnlock, "Black Temple"));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures,
        filterUnit => filterUnit.GetTypeId() != Constants.UNIT_N066_INFERNAL_JUGGERNAUT_TEAL_TOWER);
      Required = true;
    }

    /// <inheritdoc />
    protected override string CompletionPopup => "The Black Temple is waiting for it's rightfull owner.";

    /// <inheritdoc />
    protected override string RewardDescription => "Control of all buildings in Black Temple";

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