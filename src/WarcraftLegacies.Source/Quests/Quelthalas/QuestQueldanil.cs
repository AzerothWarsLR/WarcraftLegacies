using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Quelthalas
{
  public sealed class QuestQueldanil : QuestData
  {
    private readonly List<unit> _rescueUnits;

    public QuestQueldanil(Rectangle rescueRect) : base("Quel'danil Lodge",
      "Quel'danil Lodge is a High Elven outpost situated in the Hinterlands. It's been some time since the rangers there have been in contact with Quel'thalas.",
      "ReplaceableTextures\\CommandButtons\\BTNBearDen.blp")
    {
      AddObjective(new ObjectiveAnyUnitInRect(Regions.QuelDanil_Lodge, "Quel'danil Lodge", true));
      AddObjective(new ObjectiveControlCapital(LegendNeutral.Caerdarrow, false));
      ResearchId = Constants.UPGRADE_R074_QUEST_COMPLETED_QUEL_DANIL_LODGE;
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    }

    protected override string RewardFlavour =>
      "Quel'thalas has finally reunited with its lost rangers in the Hinterlands.";

    protected override string RewardDescription => "Control of Quel'danil Lodge";

    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player.RescueGroup(_rescueUnits);
    }
  }
}