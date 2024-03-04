using MacroTools.ArtifactSystem;
using MacroTools.Extensions;
using MacroTools.SpellSystem;

using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells
{
  /// <summary>
  /// Extract a Vial from the Sunwell.
  /// </summary>
  public sealed class ExtractSunwellVial : Spell
  {
    private readonly int _sunwellVialItemTypeId;

    /// <inheritdoc />
    public ExtractSunwellVial(int id, int sunwellVialItemTypeId) : base(id)
    {
      _sunwellVialItemTypeId = sunwellVialItemTypeId;
    }

    /// <inheritdoc />
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      var spawnX = GetUnitX(caster);
      var spawnY = GetUnitY(caster) - 150;
      var vial = CreateItem(_sunwellVialItemTypeId, spawnX, spawnY);
      ArtifactManager.Register(new Artifact(vial));
      caster.RemoveAbility(Id);
    }
  }
}