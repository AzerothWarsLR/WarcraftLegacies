using MacroTools.PassiveAbilitySystem;
using WCSharp.Buffs;


namespace MacroTools.Mechanics.DemonGates
{
  /// <summary>
  /// Units spawned at Demon Gates spawn at the Focal Demon Gate instead, if one exists.
  /// </summary>
  public sealed class FocalDemonGate : PassiveAbility
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="FocalDemonGate"/> class.
    /// </summary>
    /// <param name="unitTypeId"><inheritdoc /></param>
    public FocalDemonGate(int unitTypeId) : base(unitTypeId)
    {
    }
    
    /// <inheritdoc />
    public override void OnConstruction()
    {
      var buff = new FocalDemonGateBuff(GetTriggerUnit());
      BuffSystem.Add(buff);
    }
  }
}