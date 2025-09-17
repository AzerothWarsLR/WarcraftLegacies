using MacroTools.ArtifactSystem;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using WCSharp.Effects;

namespace WarcraftLegacies.Source.Quests.Naga
{
  /// <inheritdoc/>
  public sealed class QuestFlameAndSorrow : QuestData
  {
    private readonly Artifact _skullofGuldan;
    private readonly LegendaryHero _illidan;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestFlameAndSorrow"/> class.
    /// </summary>
    public QuestFlameAndSorrow(Artifact skullofGuldan, LegendaryHero illidan) : base("A Destiny of Flame and Sorrow",
      "The Skull of Gul'dan is an artifact of immeasurable demonic power, and is found somewhere on these isles. Illidan must extract its energies before he has the strength to force his way into Outland.",
      @"ReplaceableTextures\CommandButtons\BTNMetamorphosis.blp")
    {
      _skullofGuldan = skullofGuldan;
      _illidan = illidan;
      AddObjective(new ObjectiveLegendHasArtifact(illidan, skullofGuldan));
      ResearchId = UPGRADE_R095_QUEST_COMPLETED_A_DESTINY_OF_FLAME_AND_SORROW;
    }

    /// <inheritdoc/>
    public override string RewardFlavour =>
      "Illidan crushes the Skull of Gul'dan, absorbing the long-dead Warlock's phenomenal demonic energies for himself. He now has the power to tear upon a portal through reality to his seat of power, the Black Temple.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "Illidan consumes the Skull of Gul'dan to learn Metamorphosis and Portal to Black Temple";

    /// <inheritdoc />
    protected override void OnComplete(Faction whichFaction)
    {
      if (_illidan.Unit != null) 
        BlzSetUnitSkin(_illidan.Unit, UNIT_EEVI_DEMON_HUNTER_HYBRID_ILLIDARI);

      var effect = AddSpecialEffect(@"Abilities\Spells\Demon\DarkPortal\DarkPortalTarget.mdl", 
        GetUnitX(_illidan.Unit), 
        GetUnitY(_illidan.Unit));
      EffectSystem.Add(effect);
      
      ArtifactManager.Destroy(_skullofGuldan);
    }
  }
}