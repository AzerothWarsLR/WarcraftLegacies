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
    private readonly Artifact _sunwellVial;

    /// <inheritdoc />
    public QuestExtractSunwellVial(Capital sunwell, Artifact sunwellVial) : base("Eternity, Distilled",
      "The High Elves of Quel'thalas have in their possession a well of immense arcane energy. A mere vial of it would be of extraordinary value, if only we could get our hands on one.",
      @"ReplaceableTextures\CommandButtons\BTNPoTN_Sanctity_Potion.blp")
    {
      _sunwell = sunwell;
      _sunwellVial = sunwellVial;
      AddObjective(new ObjectiveCastSpellFromUnit(ABILITY_A0OC_EXTRACT_VIAL_ALL, sunwell.Unit!));
      AddObjective(new ObjectiveLegendHasArtifact(sunwell, sunwellVial, true));
      IsFactionQuest = false;
    }

    /// <inheritdoc/>
    protected override string RewardDescription => "A Vial of the Sunwell appears on the ground, and the Sunwell permanently loses 500 maximum mana";

    /// <inheritdoc/>
    public override string RewardFlavour => "We have extracted a single vial of the Sunwell's energies. Though the well remains functional, its vibrancy has been visibly diminished by our theft.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      var sunwellPosition = _sunwell.Unit!.GetPosition();
      _sunwellVial.Item.SetPositionSafe(sunwellPosition);

      UnitRemoveAbility(_sunwell.Unit!, ABILITY_A0OC_EXTRACT_VIAL_ALL);
      unit tempQualifier = _sunwell.Unit!;
      BlzSetUnitMaxMana(tempQualifier, 500);
    }

    /// <inheritdoc />
    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModAbilityAvailability(ABILITY_A0OC_EXTRACT_VIAL_ALL, 1);
    }
  }
}