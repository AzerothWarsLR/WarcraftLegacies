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
      var workers = CreateGroup().EnumUnitsOfType(UNIT_U019_DRONE_C_THUN_WORKER).EmptyToList();
      foreach (var worker in workers)
      {
        var position = worker.GetPosition();
        var facing = worker.GetFacing();
        var hitPointsPercentage = worker.GetLifePercent();
        var owner = worker.OwningPlayer();
        
        worker.SafelyRemove();
        var soldier = CreateUnit(owner, UNIT_N06I_SILITHID_WARRIOR_C_THUN_SILITHID_WARRIOR, position.X, position.Y, facing);
        soldier.SetLifePercent(hitPointsPercentage);
      }
    }
  }
}