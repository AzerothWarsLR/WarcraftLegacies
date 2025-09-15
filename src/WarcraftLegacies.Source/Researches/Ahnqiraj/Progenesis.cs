using System.Linq;
using MacroTools.Extensions;
using MacroTools.ResearchSystems;
using MacroTools.Utils;
using WCSharp.Effects;

namespace WarcraftLegacies.Source.Researches.Ahnqiraj
{
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
        var position = worker.GetPosition();
        var facing = GetUnitFacing(worker);
        var hitPointsPercentage = worker.GetLifePercent();
        var owner = GetOwningPlayer(worker);

        EffectSystem.Add(AddSpecialEffect(@"Objects\Spawnmodels\Critters\Albatross\CritterBloodAlbatross.mdl", position.X, position.Y));
        
        worker.SafelyRemove();
        var soldier = CreateUnit(owner, TransformedUnitTypeId, position.X, position.Y, facing);
        soldier.SetLifePercent(hitPointsPercentage);
      }
    }

    private bool IsValidTarget(unit target) => TransformableUnitTypeIds.Contains(GetUnitTypeId(target)) &&
                                                      !IsUnitType(target, UNIT_TYPE_DEAD) &&
                                                      !IsUnitType(target, UNIT_TYPE_SUMMONED);
  }
}