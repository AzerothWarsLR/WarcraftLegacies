using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;

namespace AzerothWarsCSharp.Source.Quests.Quelthalas
{
  public sealed class QuestQueldanil : QuestData
  {
    private readonly List<unit> _rescueUnits;
    
    public QuestQueldanil(rect rescueRect) : base("Quel'danil Lodge", "Quel'danil Lodge is a High Elven outpost situated in the Hinterlands. It's been some time since the rangers there have been in contact with Quel'thalas.", "ReplaceableTextures\\CommandButtons\\BTNBearDen.blp"){
      AddQuestItem(new QuestItemAnyUnitInRect(Regions.QuelDanil_Lodge.Rect, "Quel'danil Lodge", true));
      AddQuestItem(new QuestItemTime(1200));
      ResearchId = FourCC("R074");
      _rescueUnits = new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList();
    }
    
    protected override string CompletionPopup =>
      "Quel'thalas has finally reunited with its lost rangers in the Hinterlands.";

    protected override string CompletionDescription => "Control of Quel'danil Lodge";

    protected override void OnComplete()
    {
      foreach (var unit in _rescueUnits)
      {
        UnitRescue(unit, Holder.Player);
      }
    }
  }
}