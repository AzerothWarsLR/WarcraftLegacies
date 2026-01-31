using MacroTools.ArtifactSystem;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using MacroTools.Spells;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Spells;

namespace WarcraftLegacies.Source.Quests.Naga;

public sealed class QuestEyeofSargeras : QuestData
{
  private readonly LegendaryHero _illidan;
  private const int PermanentMetamorphosisId = ABILITY_ZBPA_METAMORPHOSIS_PERMANENT_ILLIDAN;
  private const int ActiveMetamorphosisId = ABILITY_AEVI_METAMORPHOSIS_ILLIDAN;
  private const int MetamorphosisBuff = BUFF_BEME_METAMORPHOSIS_ILLIDAN;

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

  protected override string RewardDescription => "Illidan's Metamorphosis becomes permanent";

  protected override void OnComplete(Faction completingFaction)
  {
    RegisterMetamorphosis();
    ReplaceMetamorphosisOnIllidan();
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
    SpellRegistry.Register(permanentMetamorphosis);
  }

  /// <summary>
  /// Replaces Illidan's existing active Metamorphosis with the passive version.
  /// <para>First, Illidan gains Engineering Upgrade, turning the active Metamorphosis into the passive one.</para>
  /// <para>If he has already learned Metamorphosis, he is forced to unlearn it, then learn the passive one, so that the OnLearn effect of it can trigger.</para>
  /// <para>After being replaced, he is then forced to re-learn all levels he had in Metamorphosis.</para>
  /// </summary>
  private void ReplaceMetamorphosisOnIllidan()
  {
    if (_illidan.Unit == null)
    {
      return;
    }

    _illidan.Unit.RemoveAbility(MetamorphosisBuff);
    var activeMetamorphosisLevel = _illidan.Unit.GetAbilityLevel(ActiveMetamorphosisId);

    if (activeMetamorphosisLevel > 0)
    {
      _illidan.Unit.RemoveAbility(ActiveMetamorphosisId);
      _illidan.Unit.SkillPoints += activeMetamorphosisLevel;
    }

    _illidan.Unit.AddAbility(ABILITY_ZBEU_ENGINEERING_UPGRADE_ILLIDAN);

    for (var i = 0; i < activeMetamorphosisLevel; i++)
    {
      _illidan.Unit.SelectHeroSkill(PermanentMetamorphosisId);
    }
  }
}
