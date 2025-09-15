using WCSharp.Shared.Data;

namespace MacroTools.SpellSystem
{
  /// <summary>
  /// A castable ability which can be invoked by a unit.
  /// <para>Provides a set of overrideable methods that, when implemented, define everything that a given custom spell does.</para>
  /// </summary>
  public abstract class Spell
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Spell"/> class.
    /// </summary>
    /// <param name="id">The <see cref="Spell"/> instance is invoked when a Warcraft 3 spell with this object ID is
    /// cast by any unit.</param>
    protected Spell(int id)
    {
      Id = id;
    }

    /// <summary>
    /// The <see cref="Spell"/> instance is invoked when a Warcraft 3 spell with this object ID is cast by any unit.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Invoked when the <see cref="Spell"/> instance is learned by any unit.
    /// </summary>
    public virtual void OnLearn(unit learner)
    {
    }

    /// <summary>
    /// Invoked when any unit stops casting this <see cref="Spell"/> instance.
    /// </summary>
    public virtual void OnStop(unit caster)
    {
    }

    /// <summary>
    /// Invoked when any unit starts casting this <see cref="Spell"/> instance.
    /// </summary>
    /// <param name="caster">The unit starting the spell.</param>
    /// <param name="target">The target of the spell, if any.</param>
    /// <param name="targetPoint">The target location of the spell, if any.</param>
    public virtual void OnStartCast(unit caster, unit target, Point targetPoint)
    {
    }

    /// <summary>
    /// Invoked when any unit starts the effect of this <see cref="Spell"/> instance.
    /// </summary>
    /// <param name="caster">The unit starting the spell.</param>
    /// <param name="target">The target of the spell, if any.</param>
    /// <param name="targetPoint">The target location of the spell, if any.</param>
    public virtual void OnCast(unit caster, unit target, Point targetPoint)
    {
    }

    /// <summary>
    /// The current level of this <see cref="Spell"/> instance for any specified unit.
    /// </summary>
    protected int GetAbilityLevel(unit whichUnit) => GetUnitAbilityLevel(whichUnit, Id);
  }
}