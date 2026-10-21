using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>Completed when one <see cref="LegendaryHero"/> lands the killing blow on another.</summary>
public sealed class ObjectiveLegendKilledByLegend : Objective
{
  public ObjectiveLegendKilledByLegend(LegendaryHero target, LegendaryHero killer)
  {
    SetDescription("{killer} has killed {target}", ("{killer}", Loc.Get(killer.Name)), ("{target}", Loc.Get(target.Name)));
    target.Died += _ =>
    {
      var killingUnit = @event.KillingUnit;
      if (killingUnit != null && killingUnit == killer.Unit)
      {
        Progress = QuestProgress.Complete;
      }
    };
  }
}
