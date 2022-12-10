using MacroTools.FactionSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.QuestSystem.UtilityStructs
{
  /// <summary>
  /// Completed when a specific <see cref="Legend"/> is dead.
  /// </summary>
  public sealed class ObjectiveLegendDead : Objective
  {
    private readonly Legend _target;

    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveLegendDead"/> class.
    /// </summary>
    /// <param name="target">The <see cref="Legend"/> that has to die for this objective to be completed.</param>
    public ObjectiveLegendDead(LegendaryHero target)
    {
      _target = target;
      TargetWidget = target.Unit;
      Description = IsUnitType(target.Unit, UNIT_TYPE_STRUCTURE)
        ? $"{target.Name} is destroyed"
        : $"{target.Name} is dead";
      DisplaysPosition = IsUnitType(_target.Unit, UNIT_TYPE_STRUCTURE) ||
                         GetOwningPlayer(_target.Unit) == Player(PLAYER_NEUTRAL_AGGRESSIVE);
      target.PermanentlyDied += OnDeath;
    }

    /// <inheritdoc/>
    public override Point Position => new(GetUnitX(_target.Unit), GetUnitY(_target.Unit));

    private void OnDeath(object? sender, Legend legend)
    {
      Progress = QuestProgress.Complete;
    }
  }
}