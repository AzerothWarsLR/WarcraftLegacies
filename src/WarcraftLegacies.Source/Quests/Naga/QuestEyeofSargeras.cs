using MacroTools.ArtifactSystem;
using MacroTools.Data;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using MacroTools.Spells;
using WarcraftLegacies.Source.Spells;

namespace WarcraftLegacies.Source.Quests.Naga;

public sealed class QuestEyeofSargeras : QuestData
{
  private readonly LegendaryHero _illidan;
  private const int PermanentMetamorphosisId = ABILITY_ZBPA_METAMORPHOSIS_PERMANENT_ILLIDAN;
  private const int ActiveMetamorphosisId = ABILITY_AEVI_METAMORPHOSIS_ILLIDAN;
  private const int MetamorphosisBuff = BUFF_BEME_ILLIDAN;

  public QuestEyeofSargeras(Artifact eyeOfSargeras, LegendaryHero illidan) : base("The Eye of Sargeras",
    "Illidan has long thirsted for power, and no artifact can match the destructive energies of the Dark Titan's eye. Though far too powerful to be consumed in its entirety, merely possessing the artifact will unleash Illidan's true demonic potential.",
    @"ReplaceableTextures\CommandButtons\BTNKazzakIon.blp")
  {
    _illidan = illidan;
    AddObjective(new ObjectiveLegendHasArtifact(illidan, eyeOfSargeras));
    Knowledge = 20;
  }

  public override string RewardFlavour =>
    "With the Eye of Sargeras in hand, Illidan has become more demon than Night Elf. He now wields a tool capable of sundering the world.";

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
    if (_illidan.Unit == null)
    {
      return;
    }

    _illidan.Unit.RemoveAbility(MetamorphosisBuff);
    var activeMetamorphosisLevel = _illidan.Unit.GetAbilityLevel(ActiveMetamorphosisId);
    for (var i = 0; i < activeMetamorphosisLevel; i++)
    {
      _illidan.Unit.SelectHeroSkill(PermanentMetamorphosisId);
    }
  }
}
