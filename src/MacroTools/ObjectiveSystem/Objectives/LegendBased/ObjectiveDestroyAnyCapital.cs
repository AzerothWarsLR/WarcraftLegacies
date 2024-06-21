using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.QuestSystem;

namespace MacroTools.ObjectiveSystem.Objectives.LegendBased
{
  public sealed class ObjectiveDestroyAnyCapital : Objective
  {
    /// <summary>
    /// The <see cref="Capital"/> that was destroyed to complete the objective, if any.
    /// </summary>
    public Capital? DestroyedCapital { get; set; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveDestroyAnyCapital"/> class.
    /// </summary>
    public ObjectiveDestroyAnyCapital()
    {
      Description = "Destroy any enemy capital";
    }
    
    /// <inheritdoc />
    internal override void OnAdd(Faction faction)
    {
      CapitalManager.CapitalDestroyed += (_, capital) =>
      {
        foreach (var eligibleFaction in EligibleFactions)
        {
          if (eligibleFaction.Player?.GetTeam() != capital.OwningPlayer?.GetTeam())
          {
            DestroyedCapital = capital;
            Progress = QuestProgress.Complete;
          }
        }
      };
    }
  }
}