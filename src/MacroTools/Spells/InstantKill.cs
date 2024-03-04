using MacroTools.SpellSystem;
using WCSharp.Shared.Data;


namespace MacroTools.Spells
{
  /// <summary>
  /// Instantly kills a unit.
  /// </summary>
  public sealed class InstantKill : Spell
  {
    /// <summary>
    /// Defines which 
    /// </summary>
    public enum KillTarget
    {
      /// <summary>
      /// The caster
      /// </summary>
      Self,
      /// <summary>
      /// The targeted unit
      /// </summary>
      Target,
    }

    /// <summary>
    /// Defines who is affected by the spell
    /// </summary>
    public KillTarget Target { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="InstantKill"/>.
    /// </summary>
    /// <param name="id"></param>
    /// 
    public InstantKill(int id) : base(id)
    {

    }

    /// <inheritdoc/>
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      switch (Target)
      {
        case KillTarget.Self:
          KillUnit(caster);
          break;
        case KillTarget.Target:
          KillUnit(target);
          break;
      }
     
    }
  }
}
