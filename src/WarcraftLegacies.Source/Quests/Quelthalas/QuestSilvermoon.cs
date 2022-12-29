using System.Collections.Generic;
using MacroTools;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace WarcraftLegacies.Source.Quests.Quelthalas
{
  public sealed class QuestSilvermoon : QuestData
  {
    private readonly unit _elvenRunestone;
    private readonly List<unit> _rescueUnits = new();

    public QuestSilvermoon(Rectangle rescueRect, unit elvenRunestone, PreplacedUnitSystem preplacedUnitSystem) : base("The Siege of Silvermoon",
      "Silvermoon has been besieged by Trolls. Clear them out and destroy their city of Zul'aman.",
      "ReplaceableTextures\\CommandButtons\\BTNForestTrollTrapper.blp")
    {
      _elvenRunestone = elvenRunestone;
      AddObjective(new ObjectiveKillUnit(
        preplacedUnitSystem.GetUnit(Constants.UNIT_O00O_CHIEFTAN_OF_THE_AMANI_TRIBE_CREEP_ZUL_AMAN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(FourCC("n01V"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(FourCC("n01L"))));
      AddObjective(new ObjectiveUpgrade(FourCC("h03T"), FourCC("h033")));
      AddObjective(new ObjectiveExpire(1480));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R02U_QUEST_COMPLETED_THE_SIEGE_OF_SILVERMOON;

      foreach (var unit in CreateGroup().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          _rescueUnits.Add(unit);
          SetUnitInvulnerable(unit, true);
        }

      Required = true;
    }

    //Todo: bad flavour
    protected override string CompletionPopup =>
      "Silvermoon siege has been lifted, and its military is now free to assist the Alliance.";

    protected override string RewardDescription =>
      "Control of all units in Silvermoon and enable Anasterian to be trained at the Altar";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(Faction completingFaction)
    {
      SetPlayerTechResearched(completingFaction.Player, FourCC("R02U"), 1);
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      if (UnitAlive(_elvenRunestone))
        SetUnitInvulnerable(LegendQuelthalas.LegendSilvermoon.Unit, true);
      SetUnitInvulnerable(LegendQuelthalas.LegendSunwell.Unit, true);
      if (GetLocalPlayer() == completingFaction.Player)
        PlayThematicMusic("war3mapImported\\SilvermoonTheme.mp3");
    }
  }
}