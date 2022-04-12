using AzerothWarsCSharp.MacroTools.Artifacts;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestStromgarde : QuestData
  {
    private static readonly int HeroId = FourCC("H00Z");

    private readonly QuestItemAnyUnitInRect _questItemAnyUnitInRect;

    public QuestStromgarde() : base("Stromgarde",
      "Although Stromgarde's strength has dwindled since the days of the Arathorian Empire, it remains a significant bastion of humanity. They could be convinced to mobilize their forces for Stormwind.",
      "ReplaceableTextures\\CommandButtons\\BTNTheCaptain.blp")
    {
      _questItemAnyUnitInRect = new QuestItemAnyUnitInRect(Regions.Stromgarde.Rect, "Stromgarde", true);
      AddQuestItem(_questItemAnyUnitInRect);
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = Constants.UPGRADE_R01M_QUEST_COMPLETED_STROMGARDE_STORMWIND;
    }

    protected override string CompletionPopup => "Galen Trollbane has pledged his forces to Stormwind's cause.";

    protected override string RewardDescription =>
      "Control of all units at Stromgarde, the artifact Trol'kalar, and you can summon the hero Galen Trollbane from the Altar of Kings";

    private static void GiveStromgarde(player whichPlayer)
    {
      group tempGroup = CreateGroup();
      unit u;
      //Transfer all Neutral Passive units in Stromgarde
      GroupEnumUnitsInRect(tempGroup, Regions.Stromgarde.Rect, null);
      while (true)
      {
        u = FirstOfGroup(tempGroup);
        if (u == null) break;
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) UnitRescue(u, whichPlayer);
        GroupRemoveUnit(tempGroup, u);
      }

      //Cleanup
      DestroyGroup(tempGroup);
    }

    protected override void OnFail()
    {
      GiveStromgarde(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      SetItemPosition(ArtifactSetup.ArtifactTrolkalar.Item, 140889, 12363);
      ArtifactSetup.ArtifactTrolkalar.Status = ArtifactStatus.Ground;
    }

    protected override void OnComplete()
    {
      GiveStromgarde(Holder.Player);
      UnitAddItemSafe(_questItemAnyUnitInRect.TriggerUnit, ArtifactSetup.ArtifactTrolkalar.Item);
      SetPlayerTechResearched(Holder.Player, ResearchId, 1);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(ResearchId, Faction.UNLIMITED);
      Holder.ModObjectLimit(HeroId, 1);
    }
  }
}