using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.Extensions;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace AzerothWarsCSharp.Source.Quests.Druids
{
  public sealed class QuestAshenvale : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestAshenvale(Rectangle rescueRect) : base("The Spirits of Ashenvale",
      "The forest needs healing. Regain control of it to summon it's Guardian, the Demigod Cenarius",
      "ReplaceableTextures\\CommandButtons\\BTNKeeperC.blp")
    {
      AddObjective(
        new ObjectiveLegendReachRect(LegendDruids.LegendMalfurion, Regions.AshenvaleUnlock, "Ashenvale"));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n07C"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01Q"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n08U"))));
      AddObjective(new ObjectiveUpgrade(FourCC("etol"), FourCC("etol")));
      AddObjective(new ObjectiveExpire(1440));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = FourCC("R06R");
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup => "Ashenvale is under control and Cenarius can now be awaken";

    protected override string RewardDescription =>
      "Control of all units in Ashenvale and make Cenarius trainable at the Altar";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      _rescueUnits.Clear();
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      if (GetLocalPlayer() == completingFaction.Player) PlayThematicMusic("war3mapImported\\DruidTheme.mp3");
      _rescueUnits.Clear();
    }
  }
}