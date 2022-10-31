using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using MacroTools.Wrappers;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Forsaken
{
  public sealed class QuestUndercity : QuestData
  {
    private readonly List<unit> _rescueUnits = new();
    private readonly unit _innerWaygate1;
    private readonly unit _innerWaygate2;
    private readonly unit _outerWaygate1;
    private readonly unit _outerWaygate2;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestUndercity"/>.
    /// </summary>
    /// <param name="rescueRect">All units inside this are are made neutral at game start, then rescued when the quest is completed.</param>
    /// <param name="innerWaygate1">A Waygate in the interior of the Undercity, coming in from the side.</param>
    /// <param name="innerWaygate2">A Waygate in the interior of the Undercity, coming in from the side.</param>
    /// <param name="outerWaygate1">A Waygate at the exterior of the Undercity, coming out from the side.</param>
    /// <param name="outerWaygate2">A Waygate at the exterior of the Undercity, coming out from the side.</param>
    public QuestUndercity(Rectangle rescueRect, unit innerWaygate1, unit innerWaygate2, unit outerWaygate1, unit outerWaygate2) : base("Forsaken Independence",
      "The Forsaken had enough of living under the tyranny of the Lich King. Sylvanas has vowed to give them their freedom back and a home",
      "ReplaceableTextures\\CommandButtons\\BTNForsakenArrows.blp")
    {
      _innerWaygate1 = innerWaygate1;
      _innerWaygate2 = innerWaygate2;
      _outerWaygate1 = outerWaygate1;
      _outerWaygate2 = outerWaygate2;
      AddObjective(new ObjectiveResearch(Constants.UPGRADE_R050_DECLARE_FORSAKEN_INDEPENDENCE_FORSAKEN,
        Constants.UNIT_H08B_HAUNTED_CASTLE_FORSAKEN));
      AddObjective(new ObjectiveLegendInRect(LegendForsaken.SylvanasUndead, Regions.Terenas, "Capital City"));
      AddObjective(new ObjectiveLegendDead(LegendLordaeron.LegendCapitalpalace));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R04X_QUEST_COMPLETED_FORSAKEN_INDEPENDANCE;
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

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      SetPlayerTechResearched(LordaeronSetup.Lordaeron.Player, Constants.UPGRADE_R08G_FORSAKEN_ARE_INDEPENDANT, 1);
      SetPlayerTechResearched(LegionSetup.Legion.Player, Constants.UPGRADE_R08G_FORSAKEN_ARE_INDEPENDANT, 1);
      
      _innerWaygate1.SetWaygateDestination(Regions.Undercity_Exterior_1.Center);
      _innerWaygate2.SetWaygateDestination(Regions.Undercity_Exterior_2.Center);
      
      _outerWaygate1.SetWaygateDestination(Regions.Undercity_Interior_1.Center);
      _outerWaygate2.SetWaygateDestination(Regions.Undercity_Interior_2.Center);
      
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