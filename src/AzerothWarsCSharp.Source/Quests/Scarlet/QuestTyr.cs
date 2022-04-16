using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Scarlet
{
  public sealed class QuestTyr : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestTyr(Rectangle rescueRect) : base("The Scarlet Enclave",
      "The legions at Tyr's Hand remain neutral for the moment, but when the time is right, they will align themselves with the Scarlet Crusade.",
      "ReplaceableTextures\\CommandButtons\\BTNCastle.blp")
    {
      AddQuestItem(new QuestItemTime(1000));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R03R");

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup =>
      "Tyr's Hand has joined the war and its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string RewardDescription => "Control of all units in Tyr's Hand";

    protected override void OnFail()
    {
      foreach (var unit in _rescueUnits) UnitRescue(unit, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      foreach (var unit in _rescueUnits) UnitRescue(unit, Holder.Player);
    }
  }
}