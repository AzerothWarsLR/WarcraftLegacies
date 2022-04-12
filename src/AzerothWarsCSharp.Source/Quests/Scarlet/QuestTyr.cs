using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Scarlet
{
  public sealed class QuestTyr : QuestData
  {
    public QuestTyr() : base("The Scarlet Enclave",
      "The legions at Tyr's Hand remain neutral for the moment, but when the time is right, they will align themselves with the Scarlet Crusade.",
      "ReplaceableTextures\\CommandButtons\\BTNCastle.blp")
    {
      AddQuestItem(new QuestItemTime(1000));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R03R");
    }

    protected override string CompletionPopup =>
      "Tyr's Hand has joined the war && its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string RewardDescription => "Control of all units in Tyr's Hand";

    protected override void OnFail()
    {
      RescueNeutralUnitsInRect(Regions.TyrUnlock.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      RescueNeutralUnitsInRect(Regions.TyrUnlock.Rect, Holder.Player);
    }
  }
}