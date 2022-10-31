using AzerothWarsCSharp.MacroTools.Extensions;
using WCSharp.Events;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public sealed class ObjectiveControlUnit : Objective
  {
    private readonly unit _target;

    public ObjectiveControlUnit(unit target)
    {
      Description = "Your team controls " + GetUnitName(target);
      TargetWidget = target;
      _target = target;
      DisplaysPosition = true;

      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeChangesOwner, OnUnitChangeOwner);
    }

    public override Point Position => new(GetUnitX(_target), GetUnitY(_target));

    private void OnUnitChangeOwner()
    {
      if (IsPlayerOnSameTeamAsAnyEligibleFaction(_target.OwningPlayer()))
        Progress = QuestProgress.Complete;
    }
  }
}