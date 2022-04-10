using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public sealed class QuestItemControlPoint : QuestItemData
  {
    private readonly ControlPoint _target;

    public QuestItemControlPoint(ControlPoint target)
    {
      _target = target;
      Description = "Your team controls " + target.Name;
      TargetWidget = target.Unit;
      target.ChangedOwner += OnTargetChangeOwner;
      Faction.TeamJoin += OnFactionTeamJoin;
    }

    public override Point Position => new(GetUnitX(_target.Unit), GetUnitY(_target.Unit));

    internal override void OnAdd()
    {
      if (Holder.Team.ContainsPlayer(GetOwningPlayer(_target.Unit))) Progress = QuestProgress.Complete;

      Holder.JoinedTeam += OnFactionTeamJoin;
    }

    private void OnTargetChangeOwner(object? sender, ControlPointOwnerChangeEventArgs controlPointOwnerChangeEventArgs)
    {
      Progress = Holder.Team.ContainsPlayer(GetOwningPlayer(_target.Unit))
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