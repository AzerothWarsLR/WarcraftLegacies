using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.PassiveAbilitySystem;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Cthun
{
  public sealed class QuestTitanJailors : QuestData
  {
    private readonly AllLegendSetup _allLegendSetup;
    private readonly List<unit> _rescueUnits;
    private readonly List<unit> _blockerUnits;

    public QuestTitanJailors(AllLegendSetup allLegendSetup, Rectangle rescueRect, Rectangle blockersRect) 
      : base("Titan Jailors",
        "C'thun is currently watched by a Titan Construct, we must rid the temple of hostiles and destroy the Titan to free our god.",
        @"ReplaceableTextures\CommandButtons\BTNArmorGolem.blp")
    {
      AddObjective(new ObjectiveControlPoint(UNIT_NLSE_TEMPLE_OF_AHN_QIRAJ, 1500));
      AddObjective(new ObjectiveExpire(660, Title));
      AddObjective(new ObjectiveSelfExists());

      _allLegendSetup = allLegendSetup;

      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);

      var unitsInBlockers = GlobalGroup.EnumUnitsInRect(blockersRect)
          .Where(unit => unit.OwningPlayer() == Player(PLAYER_NEUTRAL_PASSIVE))
          .ToList();

      foreach (var unit in unitsInBlockers)
      {
        unit.SetInvulnerable(true);
        unit.PauseEx(true);
      }

      _blockerUnits = unitsInBlockers;
    }

    public override string RewardFlavour => "With the Titan Construct defeat, C'thun is now free";

    protected override string RewardDescription => "Control of all units in inner Ahn'Qiraj and gain control of C'thun";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _blockerUnits)
      {
        unit.Remove();
      }

      var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
        ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
        : completingFaction.Player;

      rescuer.RescueGroup(_rescueUnits);
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _blockerUnits)
      {
        unit.Remove();
      }

      completingFaction.Player.RescueGroup(_rescueUnits);

      var cthun = _allLegendSetup.Ahnqiraj.Cthun.Unit;
      if (cthun != null)
      {
        PassiveAbilityManager.ForceOnCreated(cthun);
      }
    }
  }

  public static class GlobalGroup
  {
    public static IEnumerable<unit> EnumUnitsInRect(Rectangle rect)
    {
      var units = new List<unit>();
      var group = CreateGroup();

      GroupEnumUnitsInRect(group, rect.Rect, null);
      unit u = FirstOfGroup(group);
      
      while (u != null)
      {
        units.Add(u);
        GroupRemoveUnit(group, u);
        u = FirstOfGroup(group);
      }

      DestroyGroup(group);
      return units;
    }
  }
}