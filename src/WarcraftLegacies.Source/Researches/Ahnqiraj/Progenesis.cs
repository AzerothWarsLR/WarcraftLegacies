using System.Linq;
using MacroTools.Extensions;
using MacroTools.ResearchSystems;
using MacroTools.Utils;
using WCSharp.Effects;

namespace WarcraftLegacies.Source.Researches.Ahnqiraj;

/// <summary>
/// Replaces all worker units with soldier units - but only once.
/// </summary>
public sealed class Progenesis : Research
{
  /// <summary>
  /// All unit types that get transformed by the <see cref="Progenesis"/>.
  /// </summary>
  public required int[] TransformableUnitTypeIds { get; init; }

  /// <summary>
  /// The unit type ID to transform into.
  /// </summary>
  public required int TransformedUnitTypeId { get; init; }

  /// <inheritdoc />
  public Progenesis(int researchTypeId, int goldCost) : base(researchTypeId, goldCost)
  {
  }

  /// <inheritdoc />
  public override void OnResearch(player researchingPlayer)
  {
    var workers = GlobalGroup
      .EnumUnitsOfPlayer(researchingPlayer)
      .Where(IsValidTarget);

    foreach (var worker in workers)
    {
      var workerX = worker.X;
      var workerY = worker.Y;
      var facing = worker.Facing;
      var hitPointsPercentage = worker.GetLifePercent();
      var owner = worker.Owner;

      EffectSystem.Add(effect.Create(@"Objects\Spawnmodels\Critters\Albatross\CritterBloodAlbatross.mdl", workerX, workerY));

      worker.SafelyRemove();
      var soldier = unit.Create(owner, TransformedUnitTypeId, workerX, workerY, facing);
      soldier.SetLifePercent(hitPointsPercentage);
    }
  }

  private bool IsValidTarget(unit target) => TransformableUnitTypeIds.Contains(target.UnitType) &&
                                                    !target.IsUnitType(unittype.Dead) &&
                                                    !target.IsUnitType(unittype.Summoned);
}
