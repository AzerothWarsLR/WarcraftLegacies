using MacroTools.UnitTraits;
using WCSharp.Buffs;

namespace MacroTools.Mechanics.DemonGates;

/// <summary>
/// Units spawned at Demon Gates spawn at the Focal Demon Gate instead, if one exists.
/// </summary>
public sealed class FocalDemonGate : UnitTrait, IEffectOnConstruction
{
  /// <inheritdoc />
  public void OnConstruction()
  {
    var buff = new FocalDemonGateBuff(@event.Unit);
    BuffSystem.Add(buff);
  }
}
