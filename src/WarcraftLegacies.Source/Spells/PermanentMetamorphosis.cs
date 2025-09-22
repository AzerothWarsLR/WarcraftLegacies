using MacroTools.SpellSystem;

namespace WarcraftLegacies.Source.Spells;

public sealed class PermanentMetamorphosis : IEffectOnLearn
{
  /// <summary>
  /// The unit is transformed to look like this unit type when the ability is learned.
  /// </summary>
  public int DemonFormTypeId { get; init; }



  /// <inheritdoc />
  public void OnLearn(unit learner)
  {
    if (learner.Skin != DemonFormTypeId)
    {
      learner.Skin = DemonFormTypeId;
    }
  }
}
