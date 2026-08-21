using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Dalaran.Spells;

public sealed class DalaranShieldCancel : Spell
{
  private readonly DalaranShield _dalaranShield;

  public DalaranShieldCancel(int id, DalaranShield dalaranShield) : base(id)
  {
    _dalaranShield = dalaranShield;
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    _dalaranShield.Cancel();
  }
}
