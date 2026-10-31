using WCSharp.Events;

namespace WarcraftLegacies.Source.Shared.UnitTraits;

/// <summary>Plays a chosen animation whenever a unit type attacks, for models without an attack animation.</summary>
public sealed class AttackAnimation
{
  public required string Animation { get; init; }

  public void Register(int unitTypeId)
  {
    PlayerUnitEvents.Register(UnitTypeEvent.Attacks, OnAttack, unitTypeId);
  }

  private void OnAttack()
  {
    SetUnitAnimation(@event.Attacker, Animation);
    QueueUnitAnimation(@event.Attacker, "stand");
  }
}
