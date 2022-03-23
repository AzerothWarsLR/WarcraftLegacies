using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Mechanics.BlackEmpire;

namespace AzerothWarsCSharp.Source.Quests.BlackEmpire
{
  public sealed class QuestFirstObelisk : QuestData
  {
    private readonly List<unit> _rescueUnits = new();
    
    protected override string CompletionPopup =>
      "The first Obelisk has been summoned, but Nya'lotha's connection to Azeroth is not yet stable. More Obelisks must be erected.";

    protected override string CompletionDescription =>
      "Unlock the northern zone of Ny'alotha, and the next Herald you train will open a temporary portal to Uldum.";

    protected override void OnComplete()
    {
      foreach (var unit in _rescueUnits)
      {
        UnitRescue(unit, Holder.Player ?? Player(PLAYER_NEUTRAL_AGGRESSIVE));
      }
      RemoveUnit(Herald.Instance.Unit);
      BlackEmpirePortal.GoToNext();
    }

    public QuestFirstObelisk(rect rescueArea) : base("The First Obelisk",
      "The twisted floatity of Ny'alotha is a mere shadow of Azeroth, but that will soon change. The first step in merging the two realities is to establish an Obelisk in Northrend.",
      "ReplaceableTextures\\CommandButtons\\BTNIceCrownObelisk.blp")
    {
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueArea).EmptyToList())
      {
        SetUnitInvulnerable(unit, true);
        _rescueUnits.Add(unit);
      }
      AddQuestItem(new QuestItemObelisk(ControlPoint.GetFromUnitType(FourCC("n02S"))));
    }
  }
}