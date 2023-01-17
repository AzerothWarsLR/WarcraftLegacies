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
      "The rangers of Quel'danil have been reunited with the forces of Quel'thalas.";

    protected override string RewardDescription => "Grants control of Quel'danil Lodge and it's rangers";

    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player.RescueGroup(_rescueUnits);
    }
  }
}