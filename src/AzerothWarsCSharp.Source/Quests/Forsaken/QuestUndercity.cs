using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;

using static War3Api.Common; using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Forsaken
{
  public sealed class QuestUndercity : QuestData
  {
    private readonly unit _waygateA;
    private readonly unit _waygateB;
    
    //Todo: bad flavour
    protected override string CompletionPopup =>
      "Undercity is now under the " + Holder.Team.Name + " and they have declared independance.";

    protected override string RewardDescription =>
      "Control of all units in Undercity, unlock Nathanos and unally the Legion team";

    protected override void OnFail()
    {
      RescueNeutralUnitsInRect(Regions.UndercityUnlock.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    private static void ActivatePortal(unit waygate, Point destination)
    {
      WaygateActivate(waygate, true);
      ShowUnit(waygate, true);
      WaygateSetDestination(waygate, destination.X, destination.Y);
    }
    
    protected override void OnComplete()
    {
      RescueNeutralUnitsInRect(Regions.UndercityUnlock.Rect, Holder.Player);
      SetPlayerTechResearched(LordaeronSetup.FactionLordaeron.Player, FourCC("R08G"), 1);
      SetPlayerTechResearched(LegionSetup.FactionLegion.Player, FourCC("R08G"), 1);
      ActivatePortal(_waygateA, Regions.Undercity_Interior_2.Center);
      ActivatePortal(_waygateB, Regions.Undercity_Interior_1.Center);
      Holder.Team = TeamSetup.TeamForsaken;
      Holder.Name = "Forsaken";
      Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNBansheeRanger.blp";
      //Todo: make the below into a Faction property
      SetPlayerStateBJ(Holder.Player, PLAYER_STATE_FOOD_CAP_CEILING, 300);
      PlayThematicMusicBJ("war3mapImported\\ForsakenTheme.mp3");
    }

    public QuestUndercity(unit waygateA, unit waygateB) : base("Forsaken Independance",
      "The Forsaken had enough of living under the tyranny of the Lich King. Sylvanas has vowed to give them their freedom back && a home",
      "ReplaceableTextures\\CommandButtons\\BTNForsakenArrows.blp")
    {
      _waygateA = waygateA;
      _waygateB = waygateB;
      AddQuestItem(new QuestItemResearch(Constants.UPGRADE_R050_DECLARE_FORSAKEN_INDEPENDENCE_FORSAKEN, FourCC("h08B")));
      AddQuestItem(new QuestItemLegendInRect(LegendForsaken.LegendSylvanasv, Regions.Terenas.Rect, "Capital City"));
      AddQuestItem(new QuestItemLegendDead(LegendLordaeron.LegendCapitalpalace));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R04X");
      Global = true;
    }
  }
}