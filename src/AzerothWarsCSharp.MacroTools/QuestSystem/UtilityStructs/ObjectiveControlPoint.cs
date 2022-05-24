using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public sealed class ObjectiveControlPoint : FactionObjective
  {
    private readonly ControlPoint _target;

    public ObjectiveControlPoint(ControlPoint target)
    {
      _target = target;
      Description = "Your team controls " + target.Name;
      TargetWidget = target.Unit;
      target.ChangedOwner += OnTargetChangeOwner;
      Faction.TeamJoin += OnFactionTeamJoin;
      DisplaysPosition = true;
    }

    public override Point Position => new(GetUnitX(_target.Unit), GetUnitY(_target.Unit));

    internal override void OnAdd()
    {
      if (IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Unit.GetOwningPlayer())) 
        Progress = QuestProgress.Complete;

      Holder.JoinedTeam += OnFactionTeamJoin;
    }

    private void OnTargetChangeOwner(object? sender, ControlPointOwnerChangeEventArgs controlPointOwnerChangeEventArgs)
    {
      Progress = IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Unit.GetOwningPlayer())
        ? QuestProgress.Complete
        : QuestProgress.Incomplete;
    }

    private void OnFactionTeamJoin(object? sender, Faction faction)
    {
      if (faction.Team == Holder.Team && GetOwningPlayer(_target.Unit) == faction.Player)
        Progress = QuestProgress.Complete;
    }
  }
}