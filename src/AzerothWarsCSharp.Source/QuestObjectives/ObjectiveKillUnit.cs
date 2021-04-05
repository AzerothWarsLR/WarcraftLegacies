using System;
using WCSharp.Events;
using WCSharp.Utils.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Libraries
{
  public sealed class ObjectiveKillUnit : Objective
  {
    public override Point Location { get
      {
        return new Point(GetUnitX(_target), GetUnitY(_target));
      } 
    }

    private void OnTargetDeath()
    {
      if (Holder.Team.ContainsPlayer(GetOwningPlayer(GetKillingUnit())))
      {
        Progress = QuestProgress.Complete;
      } 
      else
      {
        Progress = QuestProgress.Failed;
      }
    }

    public ObjectiveKillUnit(Faction holder, unit target) : base(holder)
    {
      _target = target ?? throw new ArgumentNullException(nameof(target));
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeDies, OnTargetDeath);
      Description = "Kill " + GetUnitName(target);
    }

    private readonly unit _target;
  }
}
