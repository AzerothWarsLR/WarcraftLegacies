using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
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
      AddQuestItem(new QuestItemKillUnit(PreplacedUnitSystem.GetUnit(FourCC("h09U")))); //Knight
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n0BF"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n0BH"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n0BG"))));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R055");
      _rescueUnits.Add(PreplacedUnitSystem.GetUnit(FourCC("n0BE")));
      _rescueUnits.Add(PreplacedUnitSystem.GetUnit(FourCC("n0BE")));
    }

    protected override string RewardDescription => "Enable to research Astral Walk and build a shop";
    protected override string CompletionPopup => "Enable to research Astral Walk and build a shop";

    protected override void OnComplete()
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Holder.Player);
    }
  }
}