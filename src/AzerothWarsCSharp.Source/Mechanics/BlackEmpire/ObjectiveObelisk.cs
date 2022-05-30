using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
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
    }

    private void OnObeliskSummoned(object? sender, ControlPoint controlPoint)
    {
      if (controlPoint == _target)
      {
        Progress = QuestProgress.Complete;
      }
    }
  }
}