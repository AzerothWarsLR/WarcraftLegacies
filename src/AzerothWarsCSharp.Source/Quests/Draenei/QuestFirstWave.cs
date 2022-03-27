using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

namespace AzerothWarsCSharp.Source.Quests.Draenei
{
  public sealed class QuestFirstWave : QuestData
  {
    private List<unit> _unitsToKill;
    
    public QuestFirstWave() : base("Broken Civilisation",
      "The Fel Orc attack will begin at any moment, the Draenei need to evacuate their civilians aboard the Exodar",
      "ReplaceableTextures\\CommandButtons\\BTNDraeneiDivineCitadel.blp")
    {
      AddQuestItem(new QuestItemTime(720));
      AddQuestItem(new QuestItemLegendNotPermanentlyDead(LegendDraenei.LegendExodarship));
      AddQuestItem(new QuestItemSelfExists());
      _unitsToKill = new List<unit>
      {
        PreplacedUnitSystem.GetUnitByUnitType(FourCC("o051")),
        PreplacedUnitSystem.GetUnitByUnitType(FourCC("o055")),
        PreplacedUnitSystem.GetUnitByUnitType(FourCC("o054")),
        PreplacedUnitSystem.GetUnitByUnitType(FourCC("n0BU")),
      };
    }
    
    protected override string CompletionPopup =>
      "The Draenei have holded long enough and most of their civilisation had time to join the Exodar";

    protected override string CompletionDescription =>
      "The Divine Citadel, Teleporter, Astral Sanctum and Crystal Spire will be deleted from Azuremyst";

    protected override void OnFail()
    {
      foreach (var unit in _unitsToKill)
      {
        KillUnit(unit);
      }
    }
  }
}