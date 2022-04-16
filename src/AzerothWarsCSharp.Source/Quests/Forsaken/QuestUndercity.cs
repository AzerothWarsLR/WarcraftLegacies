using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Forsaken
{
  public sealed class QuestUndercity : QuestData
  {
    private readonly unit _waygateA;
    private readonly unit _waygateB;
    private readonly List<unit> _rescueUnits = new();

    public QuestUndercity(Rectangle rescueRect, unit waygateA, unit waygateB) : base("Forsaken Independance",
      "The Forsaken had enough of living under the tyranny of the Lich King. Sylvanas has vowed to give them their freedom back and a home",
      "ReplaceableTextures\\CommandButtons\\BTNForsakenArrows.blp")
    {
      _waygateA = waygateA;
      _waygateB = waygateB;
      AddQuestItem(new QuestItemResearch(Constants.UPGRADE_R050_DECLARE_FORSAKEN_INDEPENDENCE_FORSAKEN,
        FourCC("h08B")));
      AddQuestItem(new QuestItemLegendInRect(LegendForsaken.LegendSylvanasv, Regions.Terenas, "Capital City"));
      AddQuestItem(new QuestItemLegendDead(LegendLordaeron.LegendCapitalpalace));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R04X");
      Global = true;

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    //Todo: bad flavour
    protected override string CompletionPopup =>
      "Undercity is now under the " + Holder.Team.Name + " and they have declared independance.";

    protected override string RewardDescription =>
      "Control of all units in Undercity, unlock Nathanos and unally the Legion team";

    protected override void OnFail()
    {
      foreach (var unit in _rescueUnits) UnitRescue(unit, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    private static void ActivatePortal(unit waygate, Point destination)
    {
      WaygateActivate(waygate, true);
      ShowUnit(waygate, true);
      WaygateSetDestination(waygate, destination.X, destination.Y);
    }

    protected override void OnComplete()
    {
      foreach (var unit in _rescueUnits) UnitRescue(unit, Holder.Player);
      SetPlayerTechResearched(LordaeronSetup.FactionLordaeron.Player, FourCC("R08G"), 1);
      SetPlayerTechResearched(LegionSetup.FactionLegion.Player, FourCC("R08G"), 1);
      ActivatePortal(_waygateA, Regions.Undercity_Interior_2.Center);
      ActivatePortal(_waygateB, Regions.Undercity_Interior_1.Center);
      Holder.Team = TeamSetup.Forsaken;
      Holder.Name = "Forsaken";
      Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNBansheeRanger.blp";
      //Todo: make the below into a Faction property
      SetPlayerStateBJ(Holder.Player, PLAYER_STATE_FOOD_CAP_CEILING, 300);
      PlayThematicMusicBJ("war3mapImported\\ForsakenTheme.mp3");
    }
  }
}