using MacroTools.ArtifactSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests
{
  public sealed class QuestExtractSunwellVial : QuestData
  {
    private readonly Capital _sunwell;

    /// <inheritdoc />
    public QuestExtractSunwellVial(Capital sunwell, Artifact sunwellVial) : base("Eternity, Distilled",
      "The High Elves of Quel'thalas have in their possession a well of immense arcane energy. A mere vial of it would be of extraordinary value, if only we could get our hands on one.",
      @"ReplaceableTextures\CommandButtons\BTNPoTN_Sanctity_Potion.blp")
    {
      _sunwell = sunwell;
      AddObjective(new ObjectiveCastSpellFromUnit(ABILITY_A0OC_EXTRACT_VIAL_ALL, sunwell.Unit!));
      AddObjective(new ObjectiveLegendHasArtifact(sunwell, sunwellVial));
    }

    /// <inheritdoc/>
    protected override string RewardDescription => "A Vial of the Sunwell appears on the ground, and the Sunwell permanently loses 500 maximum mana";

    /// <inheritdoc/>
    public override string RewardFlavour => "We have extracted a single vial of the Sunwell's energies. Though the well remains functional, its vibrancy has been visibly diminished by our theft.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      var sunwellPosition = _sunwell.Unit!.GetPosition();
      var vial = CreateItem(ITEM_I018_VIAL_OF_THE_SUNWELL, sunwellPosition.X, sunwellPosition.Y);
      ArtifactManager.Register(new Artifact(vial));
      _sunwell.Unit!
        .RemoveAbility(ABILITY_A0OC_EXTRACT_VIAL_ALL)
        .SetMaximumMana(500);
    }

    /// <inheritdoc />
    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModAbilityAvailability(ABILITY_A0OC_EXTRACT_VIAL_ALL, 1);
    }
  }
}