using MacroTools.Setup;
using MacroTools.Utils;
using WCSharp.Effects;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.BansheesHost.Spells;

/// <summary>Enemies that die near a hero with this ability may rise as spirits that fight for its owner for a while.</summary>
public sealed class MourningChorus
{
  public required int AbilityTypeId { get; init; }
  public required int HeroTypeId { get; init; }
  public required int SpiritTypeId { get; init; }
  public required float Radius { get; init; }
  public required float SpiritDuration { get; init; }
  public required int[] ChanceByLevel { get; init; }
  public required string RiseEffectPath { get; init; }

  /// <summary>Starts listening for deaths.</summary>
  public void Register()
  {
    for (var playerId = 0; playerId < 28; playerId++)
    {
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerUnitDies, OnUnitDies, playerId);
    }
  }

  private void OnUnitDies()
  {
    var dying = @event.Unit;
    if (dying.IsUnitType(unittype.Structure) || dying.IsUnitType(unittype.Mechanical) ||
        dying.IsUnitType(unittype.Summoned) || dying.IsUnitType(unittype.Hero))
    {
      return;
    }

    foreach (var nearby in GlobalGroup.EnumUnitsInRange(dying.X, dying.Y, Radius))
    {
      if (nearby.UnitType != HeroTypeId || !nearby.Alive || dying.Owner.IsAlly(nearby.Owner))
      {
        continue;
      }

      var level = nearby.GetAbilityLevel(AbilityTypeId);
      if (level == 0 || GetRandomInt(1, 100) > ChanceByLevel[level - 1])
      {
        continue;
      }

      var spirit = unit.Create(nearby.Owner, SpiritTypeId, dying.X, dying.Y, dying.Facing);
      spirit.ApplyTimedLife(0, SpiritDuration);
      EffectSystem.Add(effect.Create(RiseEffectPath, dying.X, dying.Y), 1);
      return;
    }
  }
}
