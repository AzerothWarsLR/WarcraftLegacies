using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public sealed class ObjectiveControlPoint : Objective
  {
    private readonly ControlPoint _target;

    public ObjectiveControlPoint(ControlPoint target)
    {
      _target = target;
      Description = "Your team controls " + target.Name;
      TargetWidget = target.Unit;
      target.ChangedOwner += OnTargetChangeOwner;
      DisplaysPosition = true;
    }

    public override Point Position => new(GetUnitX(_target.Unit), GetUnitY(_target.Unit));

    internal override void OnAdd(Faction whichFaction)
    {
      if (IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Unit.OwningPlayer()))
        Progress = QuestProgress.Complete;

      whichFaction.JoinedTeam += OnFactionTeamJoin;
    }

    private void OnTargetChangeOwner(object? sender, ControlPointOwnerChangeEventArgs controlPointOwnerChangeEventArgs)
    {
      Progress = IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Unit.OwningPlayer())
        ? QuestProgress.Complete
        : QuestProgress.Incomplete;
    }

    private void OnFactionTeamJoin(object? sender, Faction faction)
    {
      if (IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Unit.OwningPlayer()))
        Progress = QuestProgress.Complete;
    }
  }
}