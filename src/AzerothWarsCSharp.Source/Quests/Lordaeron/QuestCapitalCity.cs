using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Setup.Legends;
using WCSharp.Shared.Data;


namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestCapitalCity : QuestData
  {
    private readonly List<unit> _rescueUnits = new();
    private readonly unit _unitToMakeInvulnerable;

    public QuestCapitalCity(Rectangle rescueRect, unit unitToMakeInvulnerable, IEnumerable<QuestData> prequisites) :
      base("Hearthlands",
        "The territories of Lordaeron are fragmented. Regain control of the old Alliance's hold to secure the kingdom.",
        "ReplaceableTextures\\CommandButtons\\BTNCastle.blp")
    {
      AddObjective(new ObjectiveControlLegend(LegendNeutral.LegendCaerdarrow, false));
      foreach (var prequisite in prequisites) AddObjective(new ObjectiveCompleteQuest(prequisite));
      AddObjective(new ObjectiveExpire(1472));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R04Y_QUEST_COMPLETED_HEARTHLANDS;
      _unitToMakeInvulnerable = unitToMakeInvulnerable;
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect.Rect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }

      Required = true;
    }

    //Todo: bad flavour
    protected override string CompletionPopup =>
      "The Capital City of Lordaeron has been literated.";

    protected override string RewardDescription => "Control of all units in Capital City";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      LegendLordaeron.LegendUther.AddUnitDependency(LegendLordaeron.LegendCapitalpalace.Unit);
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      SetUnitInvulnerable(_unitToMakeInvulnerable, true);
      if (GetLocalPlayer() == completingFaction.Player)
        PlayThematicMusic("war3mapImported\\CapitalCity.mp3");
      LegendLordaeron.LegendUther.AddUnitDependency(LegendLordaeron.LegendCapitalpalace.Unit);
    }
  }
}