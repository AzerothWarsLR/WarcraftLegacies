using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace AzerothWarsCSharp.Source.Quests.Forsaken
{
  public sealed class QuestUndercity : QuestData
  {
    private readonly List<unit> _rescueUnits = new();
    private readonly unit _waygateA;
    private readonly unit _waygateB;

    public QuestUndercity(Rectangle rescueRect, unit waygateA, unit waygateB) : base("Forsaken Independence",
      "The Forsaken had enough of living under the tyranny of the Lich King. Sylvanas has vowed to give them their freedom back and a home",
      "ReplaceableTextures\\CommandButtons\\BTNForsakenArrows.blp")
    {
      _waygateA = waygateA;
      _waygateB = waygateB;
      AddObjective(new ObjectiveResearch(Constants.UPGRADE_R050_DECLARE_FORSAKEN_INDEPENDENCE_FORSAKEN,
        FourCC("h08B")));
      AddObjective(new ObjectiveLegendInRect(LegendForsaken.SylvanasUndead, Regions.Terenas, "Capital City"));
      AddObjective(new ObjectiveLegendDead(LegendLordaeron.LegendCapitalpalace));
      AddObjective(new ObjectiveSelfExists());
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
    /// <inheritdoc />
    protected override string CompletionPopup =>
      "Undercity is now under the Forsaken's control and they have declared independance.";

    /// <inheritdoc />
    protected override string RewardDescription =>
      "Control of all units in Undercity, unlock Nathanos and unally the Legion team";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    private static void ActivatePortal(unit waygate, Point destination)
    {
      WaygateActivate(waygate, true);
      ShowUnit(waygate, true);
      WaygateSetDestination(waygate, destination.X, destination.Y);
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      SetPlayerTechResearched(LordaeronSetup.Lordaeron.Player, FourCC("R08G"), 1);
      SetPlayerTechResearched(LegionSetup.Legion.Player, FourCC("R08G"), 1);
      ActivatePortal(_waygateA, Regions.Undercity_Interior_2.Center);
      ActivatePortal(_waygateB, Regions.Undercity_Interior_1.Center);
      completingFaction.Player?.SetTeam(TeamSetup.Forsaken);
      completingFaction.Name = "Forsaken";
      completingFaction.Icon = "ReplaceableTextures\\CommandButtons\\BTNBansheeRanger.blp";
      SetPlayerState(completingFaction.Player, PLAYER_STATE_FOOD_CAP_CEILING, 300);
      PlayThematicMusic("war3mapImported\\ForsakenTheme.mp3");
      completingFaction.AddQuest(new QuestRetakeSunwell());
      completingFaction.AddQuest(new QuestTheNine());
      completingFaction.AddQuest(new QuestTakeRevenge());
    }
  }
}