using MacroTools.Spells;
using WCSharp.Effects;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Druids.Spells;

public sealed class RootTapSpell : Spell
{
  public required float LifeFraction { get; init; }
  public required float ManaPerLife { get; init; }
  public required string EffectPath { get; init; }

  public RootTapSpell(int id) : base(id)
  {
  }

  public override void OnStartCast(unit caster, unit target, Point targetPoint)
  {
    if (CanAfford(caster))
    {
      return;
    }

    caster.SetPausedEx(true);
    caster.IssueOrder("stop");
    caster.SetPausedEx(false);
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    if (!CanAfford(caster))
    {
      return;
    }

    var lifeCost = caster.MaxLife * LifeFraction;
    caster.Life -= lifeCost;
    caster.Mana += lifeCost * ManaPerLife;
    EffectSystem.Add(effect.Create(EffectPath, caster, "origin"));
  }

  private bool CanAfford(unit caster) =>
    caster.Mana < caster.MaxMana && caster.Life > caster.MaxLife * LifeFraction + 1;
}
