using MacroTools.Artifacts;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ArtifactBased;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.Stormwind.Quests.Stromgarde;

/// <summary>Stromgarde, heir of Arathor, can unite the Eastern Kingdoms with Thoras as High King.</summary>
public sealed class QuestStromgardeKingdomOfMan : QuestData
{
  private const int RewardResearchId = UPGRADE_R01N_ARATHORIAN_LEGACY_LORDAERON_STORMWIND_QUEST;

  private readonly Artifact _crownOfLordaeron;
  private readonly Artifact _crownOfStormwind;
  private readonly LegendaryHero _thoras;

  public QuestStromgardeKingdomOfMan(Artifact crownOfLordaeron, Artifact crownOfStormwind, LegendaryHero thoras) :
    base("Kingdom of Man",
      "Stromgarde was the capital of the Arathorian Empire, the first kingdom of men. Its Trollbane kings are Arathor's heirs. Unite mankind under their banner once more.",
      @"ReplaceableTextures\CommandButtons\BTNFireKingCrown.blp")
  {
    _crownOfLordaeron = crownOfLordaeron;
    _crownOfStormwind = crownOfStormwind;
    _thoras = thoras;
    AddObjective(new ObjectiveControlLegend(thoras, true));
    AddObjective(new ObjectiveAcquireArtifact(crownOfLordaeron));
    AddObjective(new ObjectiveAcquireArtifact(crownOfStormwind));
    AddObjective(new ObjectiveControlPoint(UNIT_N010_STORMWIND_CITY));
    AddObjective(new ObjectiveControlPoint(UNIT_N01G_LORDAERON_CITY));
    Global = true;
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "The kingdoms of men stand united once more under the heirs of Arathor. Long live High King Thoras Trollbane!";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    "You gain a research improving all of your units, the Crowns of Lordaeron and Stormwind are merged, and Thoras gains 10 Strength and 10 Agility";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    var owner = completingFaction.Player;
    if (owner != null)
    {
      owner.SetTechResearched(RewardResearchId, 1);
      owner.DisplayResearchAcquired(RewardResearchId, 1);
    }

    _thoras.ClearUnitDependencies();
    var thoras = _thoras.Unit;
    if (thoras != null)
    {
      thoras.AddHeroAttributes(10, 10, 0);
    }

    var crownHolder = _crownOfStormwind.OwningUnit;
    ArtifactManager.Destroy(_crownOfLordaeron);
    ArtifactManager.Destroy(_crownOfStormwind);
    var crownOfTheEasternKingdoms = new Artifact(item.Create(ITEM_I00U_CROWN_OF_THE_EASTERN_KINGDOMS, 0, 0));
    ArtifactManager.Register(crownOfTheEasternKingdoms);
    if (crownHolder != null)
    {
      crownHolder.AddItemSafe(crownOfTheEasternKingdoms.Item);
    }
  }

  /// <inheritdoc/>
  protected override void OnAdd(Faction whichFaction) =>
    whichFaction.ModObjectLimit(RewardResearchId, Faction.Unlimited);
}
