using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.Source.Quests.KulTiras
{
  public sealed class QuestTheramore : QuestData
  {
    private static readonly int RequiredResearch = FourCC("R06K");

    private readonly List<unit> _rescueUnits = new();

    public QuestTheramore(Rectangle rescueRect) : base("Theramore",
      "The distant lands of Kalimdor remain untouched by human civilization. If the Third War proceeds poorly, it may become necessary to establish a forward base there.",
      "ReplaceableTextures\\CommandButtons\\BTNHumanArcaneTower.blp")
    {
      AddObjective(new ObjectiveResearch(RequiredResearch, FourCC("h076")));
      AddObjective(new ObjectiveSelfExists());
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
          SetUnitOwner(unit, Player(PLAYER_NEUTRAL_PASSIVE), true);
        }
    }

    protected override string CompletionPopup =>
      "A sizeable isle off the coast of Dustwallow Marsh has been colonized and dubbed Theramore, marking the first human settlement to be established on Kalimdor.";

    protected override string RewardDescription => "Control of all units at Theramore";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      completingFaction.ModObjectLimit(RequiredResearch, -Faction.UNLIMITED);
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      completingFaction.ModObjectLimit(RequiredResearch, -Faction.UNLIMITED);
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(RequiredResearch, Faction.UNLIMITED);
    }
  }
}