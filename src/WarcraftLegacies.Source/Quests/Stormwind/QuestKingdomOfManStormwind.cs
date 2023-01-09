using MacroTools.ArtifactSystem;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.ObjectiveSystem.Objectives.ArtifactBased;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Stormwind
{
  /// <summary>
  /// Stormwind can secure the Eastern Kingdoms to become High King.
  /// </summary>
  public sealed class QuestKingdomOfManStormwind : QuestData
  {
    private readonly Artifact _crownOfLordaeron;
    private readonly Artifact _crownOfStormwind;
    private const int RewardResearchId = Constants.UPGRADE_R01N_ARATHORIAN_LEGACY_LORDAERON_STORMWIND_QUEST;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestKingdomOfManStormwind"/> class.
    /// </summary>
    public QuestKingdomOfManStormwind(Artifact crownOfLordaeron, Artifact crownOfStormwind) : base("Kingdom of Man",
      "Before the First War, all of humanity was united under the banner of the Arathorian Empire. Reclaim its greatness by uniting mankind once again.",
      "ReplaceableTextures\\CommandButtons\\BTNFireKingCrown.blp")
    {
      _crownOfLordaeron = crownOfLordaeron;
      _crownOfStormwind = crownOfStormwind;
      AddObjective(new ObjectiveControlLegend(LegendStormwind.Varian, true));
      AddObjective(new ObjectiveAcquireArtifact(crownOfLordaeron));
      AddObjective(new ObjectiveAcquireArtifact(crownOfStormwind));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N010_STORMWIND_CITY_30GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N01G_LORDAERON_CITY_30GOLD_MIN)));
      Global = true;
    }

    /// <inheritdoc/>
    protected override string CompletionPopup =>
      "The people of the Eastern Kingdoms have been united under the banner of Lordaeron. Long live High King Varian Wrynn!";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "You gain a research improving all of your units, the Crowns of Lordaeron and Stormwind are merged, and Varian gains 2000 experience, 10 Strength, and 10 Agility";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      SetPlayerTechResearched(completingFaction.Player, RewardResearchId, 1);
      completingFaction.Player?.DisplayResearchAcquired(RewardResearchId, 1);
      
      if (LegendStormwind.Varian != null)
      {
        LegendStormwind.Varian.ClearUnitDependencies();
        LegendStormwind.Varian.Unit?.AddHeroAttributes(10, 10, 0);
      }

      var crownHolder = _crownOfStormwind.OwningUnit;
      
      ArtifactManager.Destroy(_crownOfLordaeron);
      ArtifactManager.Destroy(_crownOfStormwind);

      var crownOfTheEasternKingdoms = new Artifact(CreateItem(Constants.ITEM_I00U_CROWN_OF_THE_EASTERN_KINGDOMS, 0, 0));
      ArtifactManager.Register(crownOfTheEasternKingdoms);
      crownHolder?.AddItemSafe(crownOfTheEasternKingdoms.Item);
    }

    /// <inheritdoc/>
    protected override void OnAdd(Faction whichFaction) =>
      whichFaction.ModObjectLimit(RewardResearchId, Faction.UNLIMITED);
  }
}