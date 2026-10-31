using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WarcraftLegacies.Source.Shared;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>Whenever an enemy dies near Moira, friendly units near her restore some of their hit points.</summary>
public sealed class VoiceOfTheThrone
{
  public required int AbilityTypeId { get; init; }
  public required LeveledAbilityField<float> HealFraction { get; init; }
  public required float Radius { get; init; }
  public required string HealEffectPath { get; init; }

  /// <summary>Starts listening for deaths.</summary>
  public void Register() => PlayerUnitEvents.Register(UnitTypeEvent.Dies, OnUnitDies);

  private void OnUnitDies()
  {
    var moira = AllLegends.Ironforge.Moira.Unit;
    if (moira == null || !moira.Alive)
    {
      return;
    }

    var level = moira.GetAbilityLevel(AbilityTypeId);
    var dying = @event.Unit;
    if (level == 0 || !dying.IsEnemyTo(moira.Owner) || dying.IsUnitType(unittype.Structure) || !IsInRange(moira, dying))
    {
      return;
    }

    var fraction = HealFraction.GetValue(level);
    foreach (var ally in GlobalGroup.EnumUnitsInRange(moira.X, moira.Y, Radius))
    {
      if (!ally.Alive || !ally.IsAllyTo(moira.Owner) || ally.IsUnitType(unittype.Structure) ||
          ally.UnitType == DummyCasterManager.UnitTypeId)
      {
        continue;
      }

      ally.Life += ally.MaxLife * fraction;
      AddSpecialEffectTarget(HealEffectPath, ally, "origin").Dispose();
    }
  }

  private bool IsInRange(unit moira, unit other)
  {
    var dx = moira.X - other.X;
    var dy = moira.Y - other.Y;
    return dx * dx + dy * dy <= Radius * Radius;
  }
}
