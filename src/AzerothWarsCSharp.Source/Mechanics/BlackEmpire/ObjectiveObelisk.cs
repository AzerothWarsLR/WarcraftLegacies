using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Mechanics.BlackEmpire
{
  public sealed class ObjectiveObelisk : Objective
  {
    private readonly ControlPoint _target;

    public ObjectiveObelisk(ControlPoint target)
    {
      _target = target;
      Description = $"Summon a Nya'lothan Obelisk on {GetUnitName(target.Unit)}";
      BlackEmpireObeliskChannel.ObeliskSummoned += OnObeliskSummoned;
      TargetWidget = target.Unit;
      DisplaysPosition = true;
    }

    public override Point Position => new(GetUnitX(_target.Unit), GetUnitY(_target.Unit));

    private void OnObeliskSummoned(object? sender, ControlPoint controlPoint)
    {
      if (controlPoint == _target)
      {
        Progress = QuestProgress.Complete;
      }
    }
  }
}