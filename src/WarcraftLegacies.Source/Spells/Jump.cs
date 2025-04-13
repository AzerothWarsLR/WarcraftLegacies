using WCSharp.Shared.Data;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Spells.JumpSystem;




namespace WarcraftLegacies.Source.Spells
{
  /// <summary>
  /// A spell that allows a unit to perform a jump to a specified target point.
  /// </summary>
  public class JumpSpell : Spell
  {
    private readonly float _jumpSpeed;
    private readonly float _maxHeight;

    public JumpSpell(int id, float jumpSpeed, float maxHeight) : base(id)
    {
      _jumpSpeed = jumpSpeed;
      _maxHeight = maxHeight;
    }

    /// <inheritdoc />
    public override void OnCast(unit caster, unit? target, Point targetPoint)
    {
      JumpSystem.TriggerJump(caster, targetPoint, _jumpSpeed, _maxHeight); 
    }
  }
}