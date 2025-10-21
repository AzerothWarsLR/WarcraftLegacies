using System.Linq;
using MacroTools.DummyCasters;
using MacroTools.SpellSystem;
using MacroTools.Utils;
using WCSharp.Buffs;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells.IceBlock;

public sealed class IceBlockSpell : Spell
{
  /// <summary>
  /// The unit type from which to spawn the ice block dummy.
  /// <remarks>When the dummy is dispelled by an AoE dispel effect, the Ice Block dissipates.</remarks>
  /// </summary>
  public required int DummyUnitTypeId { get; init; }

  public required string CastEffectPath { get; init; }

  public required string IceBlockEffectPath { get; init; }

  /// <summary>
  /// The ability ID for the dummy spell that applies the Ice Block buff. When dispelled, Ice Block ends.
  /// </summary>
  public required int BuffApplicatorTypeId { get; init; }

  /// <summary>
  /// The buff applied by <see cref="BuffApplicatorTypeId"/>.
  /// </summary>
  public required int BuffTypeId { get; init; }

  /// <inheritdoc />
  public IceBlockSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    var ability = caster.GetAbility(Id);
    var radius = ability.GetAreaOfEffect_aare(level - 1);

    var dummyUnit = unit.Create(caster.Owner, DummyUnitTypeId, targetPoint.X, targetPoint.Y);
    var targets = GlobalGroup.EnumUnitsInRange(targetPoint, radius)
      .Where(x => x != dummyUnit && x.Alive && !x.IsInvulnerable)
      .ToList();

    DummyCasterManager
      .GetGlobalDummyCaster()
      .CastUnit(caster, BuffApplicatorTypeId, ORDER_INNER_FIRE, 1, dummyUnit, DummyCastOriginType.Target);

    var iceBlockBuff = new IceBlockBuff(caster, dummyUnit)
    {
      Targets = targets,
      IceBlockEffectPath = IceBlockEffectPath,
      DissipateEffectPath = CastEffectPath,
      BuffId = BuffTypeId,
      Duration = ability.GetDurationNormal_adur(0)
    };

    BuffSystem.Add(iceBlockBuff);

    effect.Create(CastEffectPath, targetPoint.X, targetPoint.Y);
  }
}
