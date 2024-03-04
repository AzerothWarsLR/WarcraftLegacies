using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace MacroTools.Spells
{
  /// <summary>
  /// Transfers the caster over to the player of the targeted unit if it is on the same <see cref="Team"/> as the caster
  /// </summary>
  public class Transfer : Spell
  {

    /// <summary>
    /// Initializes a new instance of <see cref="Transfer"/>.
    /// </summary>
    /// <param name="id"></param>
    public Transfer(int id) : base(id)
    {

    }

    /// <inheritdoc/>
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      var targetTeam = target.Owner.GetTeam();
      var casterTeam = caster.Owner.GetTeam();

      if (targetTeam == casterTeam)
        caster.SetOwner(target.Owner);
    }

  }
}
