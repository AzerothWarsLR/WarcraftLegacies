using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public class QuestItemLegendDead : QuestItemData
  {
    private readonly Legend _target;

    public override Point Position => new(GetUnitX(_target.Unit), GetUnitY(_target.Unit));

    public override bool DisplaysPosition => IsUnitType(_target.Unit, UNIT_TYPE_STRUCTURE) ||
                                             GetOwningPlayer(_target.Unit) == Player(PLAYER_NEUTRAL_AGGRESSIVE);

    private void OnDeath(object? sender, Legend legend)
    {
      Progress = QuestProgress.Complete;
    }

    public QuestItemLegendDead(Legend target)
    {
      _target = target;
      TargetWidget = target.Unit;
      if (IsUnitType(target.Unit, UNIT_TYPE_STRUCTURE))
      {
        Description = target.Name + " is destroyed";
      }
      else
      {
        Description = target.Name + " is dead";
      }

      target.PermanentlyDied += OnDeath;
    }
  }
}