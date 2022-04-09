using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Quests.Forsaken
{
  public sealed class QuestUndercity : QuestData
  {
    protected override string CompletionPopup =>
      "Undercity is now under the " + Holder.Team.Name + " && they have declared independance.";

    protected override string RewardDescription =>
      "Control of all units in Undercity, unlock Nathanos and unally the Legion team";

    protected override void OnFail()
    {
      RescueNeutralUnitsInRect(Regions.UndercityUnlock.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      RescueNeutralUnitsInRect(Regions.UndercityUnlock.Rect, Holder.Player);
      SetPlayerTechResearched(LordaeronSetup.FactionLordaeron.Player, FourCC("R08G"), 1);
      SetPlayerTechResearched(LegionSetup.FactionLegion.Player, FourCC("R08G"), 1);
      WaygateActivateBJ(true, gg_unit_n08F_1739);
      WaygateActivateBJ(true, gg_unit_n08F_1798);
      ShowUnitShow(gg_unit_n08F_1739);
      ShowUnitShow(gg_unit_n08F_1798);
      WaygateSetDestinationLocBJ(gg_unit_n08F_1739, GetRectCenter(gg_rct_Undercity_Interior_2));
      WaygateSetDestinationLocBJ(gg_unit_n08F_1798, GetRectCenter(gg_rct_Undercity_Interior_1));
      Holder.Team = TeamSetup.TeamForsaken;
      Holder.Name = "Forsaken";
      Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNBansheeRanger.blp";
      SetPlayerStateBJ(Holder.Player, PLAYER_STATE_FOOD_CAP_CEILING, 300);
      PlayThematicMusicBJ("war3mapImported\\ForsakenTheme.mp3");
    }

    public QuestUndercity() : base("Forsaken Independance",
      "The Forsaken had enough of living under the tyranny of the Lich King. Sylvanas has vowed to give them their freedom back && a home",
      "ReplaceableTextures\\CommandButtons\\BTNForsakenArrows.blp")
    {
      AddQuestItem(new QuestItemResearch(RESEARCH_ID, FourCC("h08B")));
      AddQuestItem(new QuestItemLegendInRect(LegendForsaken.LegendSylvanasv, Regions.Terenas.Rect, "Capital City"));
      AddQuestItem(new QuestItemLegendDead(LegendLordaeron.LegendCapitalpalace));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R04X");
      Global = true;
    }
  }
}