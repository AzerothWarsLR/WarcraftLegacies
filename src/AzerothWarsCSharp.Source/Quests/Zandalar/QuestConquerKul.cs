using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Zandalar
{
  public sealed class QuestConquerKul : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R08D");

    public QuestConquerKul() : base("Conquer Boralus",
      "The Kul'tiran people and their fleet have been a threat to the Zandalari Empire for ages, it is time to put them to rest.",
      "ReplaceableTextures\\CommandButtons\\BTNGalleonIcon.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LegendNeutral.LegendDazaralor, true));
      AddQuestItem(new QuestItemLegendDead(LegendKultiras.LegendBoralus));
      ResearchId = QuestResearchId;
    }

    protected override string CompletionPopup => "Before setting sails we need to conquer Kul'tiras";

    protected override string RewardDescription => "Unlock shipyards";

    protected override string FailurePopup => "Zandalar has fallen.";

    protected override string PenaltyDescription => "You can no longer build shipyards, but you unlock Zulfarrak";

    protected override void OnFail()
    {
      unit u;
      group tempGroup;
      tempGroup = CreateGroup();
      GroupEnumUnitsInRect(tempGroup, Regions.Zulfarrak.Rect, null);
      u = FirstOfGroup(tempGroup);
      while (true)
      {
        if (u == null) break;

        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE) ||
            GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_AGGRESSIVE))
        {
          if (IsUnitType(u, UNIT_TYPE_HERO))
            KillUnit(u);
          else
            u.Rescue(Holder.Player);
        }

        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }

      DestroyGroup(tempGroup);
    }
  }
}