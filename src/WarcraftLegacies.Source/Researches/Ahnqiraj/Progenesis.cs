using System.Linq;
using MacroTools.Extensions;
using MacroTools.ResearchSystems;

namespace WarcraftLegacies.Source.Researches.Ahnqiraj
{
  /// <summary>
  /// Replaces all worker units with soldier units - but only once.
  /// </summary>
  public sealed class Progenesis : Research
  {
    /// <inheritdoc />
    public Progenesis(int researchTypeId, int goldCost) : base(researchTypeId, goldCost)
    {
    }

    /// <inheritdoc />
    public override void OnResearch(player researchingPlayer)
    {
      var workers = CreateGroup()
        .EnumUnitsOfPlayer(researchingPlayer)
        .EmptyToList()
        .Where(IsValidTarget);
      
      foreach (var worker in workers)
      {
        var position = worker.GetPosition();
        var facing = worker.GetFacing();
        var hitPointsPercentage = worker.GetLifePercent();
        var owner = worker.OwningPlayer();

        AddSpecialEffect(@"Objects\Spawnmodels\Critters\Albatross\CritterBloodAlbatross.mdl", position.X, position.Y)
          .SetLifespan();
        
        worker.SafelyRemove();
        var soldier = CreateUnit(owner, UNIT_N06I_SILITHID_WARRIOR_C_THUN_SILITHID_WARRIOR, position.X, position.Y, facing);
        soldier.SetLifePercent(hitPointsPercentage);
      }
    }

    private static bool IsValidTarget(unit target) => GetUnitTypeId(target) == UNIT_U019_DRONE_C_THUN_WORKER &&
                                                      !IsUnitType(target, UNIT_TYPE_DEAD) &&
                                                      !IsUnitType(target, UNIT_TYPE_SUMMONED);
  }
}