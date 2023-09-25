using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Powers
{
  public sealed class Immortality : Power
  {
    private readonly float _healChance;
    private readonly float _healAmountPercentage;

    /// <summary>The effect that appears when a unit is healed.</summary>
    public string Effect { get; init; } = "";
    
    public Immortality(float healChance, float healAmountPercentage)
    {
      _healChance = healChance;
      _healAmountPercentage = healAmountPercentage;
      Name = "Immortality";
      Description = $"When a unit you control would take lethal damage, it has a {healChance*100}% chance to instead restore hit points until it has {healAmountPercentage*100}% of its maximum hit points.";
    }
    
    /// <inheritdoc />
    public override void OnAdd(player whichPlayer) => 
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerTakesDamage, OnDamage, GetPlayerId(whichPlayer));

    /// <inheritdoc />
    public override void OnRemove(player whichPlayer) => 
      PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerTakesDamage, OnDamage, GetPlayerId(whichPlayer));
    
    private void OnDamage()
    {
      var damagedUnit = GetTriggerUnit();
      if (!(GetEventDamage() >= damagedUnit.GetHitPoints()) || !(GetRandomReal(0, 1) < _healChance)) 
        return;
      
      damagedUnit.SetCurrentHitpoints((int)(damagedUnit.GetMaximumHitPoints() * _healAmountPercentage));
      AddSpecialEffect(Effect, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit()))
        .SetLifespan(1);
    }
  }
}