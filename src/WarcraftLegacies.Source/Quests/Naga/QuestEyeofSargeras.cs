using MacroTools.ArtifactSystem;
using MacroTools.Data;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Spells;

namespace WarcraftLegacies.Source.Quests.Naga;

public sealed class QuestEyeofSargeras : QuestData
{
  private readonly LegendaryHero _illidan;
  private const int PermanentMetamorphosisId = ABILITY_ZBPA_METAMORPHOSIS_PERMANENT_ILLIDAN;
  private const int ActiveMetamorphosisId = ABILITY_AEVI_METAMORPHOSIS_ILLIDAN;
  private const int MetamorphosisBuff = BUFF_BEME_ILLIDAN;

  public QuestEyeofSargeras(Artifact eyeOfSargeras, LegendaryHero illidan) : base("The Eye of Sargeras",
    "The Eye of Sargeras is an extremely powerful artifact, it could be the key to satiate Illidan's thirst for power.",
    @"ReplaceableTextures\CommandButtons\BTNKazzakIon.blp")
  {
    _illidan = illidan;
    AddObjective(new ObjectiveLegendHasArtifact(illidan, eyeOfSargeras));
    Knowledge = 20;
  }

  public override string RewardFlavour =>
    "The Eye of Sargeras' power needs to be channeled by powerful arcanists, the Naga Sea Witch will be the perfect vessels.";

  protected override void OnComplete(Faction completingFaction)
  {
    RegisterMetamorphosis();
    completingFaction.ModAbilityAvailability(PermanentMetamorphosisId, 1);
    completingFaction.ModAbilityAvailability(ActiveMetamorphosisId, -1);
    ReplaceMetamorphosisOnIllidan();
  }

  protected override void OnAdd(Faction faction)
  {
    faction.ModAbilityAvailability(PermanentMetamorphosisId, -1);
  }

  private static void RegisterMetamorphosis()
  {
    var permanentMetamorphosis = new PermanentMetamorphosis(ABILITY_ZBPA_METAMORPHOSIS_PERMANENT_ILLIDAN)
    {
      DamageBonus = new LeveledAbilityField<int>
      {
        Base = 30,
        PerLevel = 30
      },
      HitPointBonus = new LeveledAbilityField<int>
      {
        Base = 250,
        PerLevel = 250
      },
      LearnEffectPath = @"Abilities\Spells\Undead\DarkRitual\DarkRitualTarget.mdl",
      UnitTypeId = UNIT_EEVM_DEMON_HUNTER_MORPHED_LEVEL_1_ILLIDARI
    };
    SpellSystem.Register(permanentMetamorphosis);
  }

  private void ReplaceMetamorphosisOnIllidan()
  {
    if (_illidan.Unit != null)
    {
      _illidan.Unit.RemoveAbility(MetamorphosisBuff);
      var activeMetamorphosisLevel = _illidan.Unit.GetAbilityLevel(ActiveMetamorphosisId);
      _illidan.Unit.SetAbilityLevelWithEvents(PermanentMetamorphosisId, activeMetamorphosisLevel);
      _illidan.Unit.SetAbilityLevel(ActiveMetamorphosisId, 0);
    }
  }
}
