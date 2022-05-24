using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Legion
{
  public sealed class QuestArgusControl : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestArgusControl() : base("Argus Incursion",
      "The planet of Argus is not fully under the control of the Legion. Bring it under control!",
      "ReplaceableTextures\\CommandButtons\\BTNMastersLodge.blp")
    {
      AddQuestItem(new ObjectiveKillUnit(PreplacedUnitSystem.GetUnit(Constants.UNIT_H09U_ELEKK_KNIGHT_DRAENEI, Regions.OutlandToArgus.Center)));
      AddQuestItem(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n0BF"))));
      AddQuestItem(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n0BH"))));
      AddQuestItem(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n0BG"))));
      AddQuestItem(new ObjectiveSelfExists());
      ResearchId = FourCC("R055");
      _rescueUnits.Add(PreplacedUnitSystem.GetUnit(FourCC("n0BE"), Regions.Eastern_Northrend.Center));
      _rescueUnits.Add(PreplacedUnitSystem.GetUnit(FourCC("n0BE"), Regions.InstanceOutland.Center));
    }

    protected override string RewardDescription => "Enable to research Astral Walk and build a shop";
    protected override string CompletionPopup => "Enable to research Astral Walk and build a shop";

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
    }
  }
}