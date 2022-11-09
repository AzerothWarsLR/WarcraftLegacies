using MacroTools.ArtifactSystem;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Libraries;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Lordaeron
{
  public sealed class QuestKingdomOfManLordaeron : QuestData
  {
    private static readonly int RewardResearchId = FourCC("R01N");

    public QuestKingdomOfManLordaeron() : base("Kingdom of Man",
      "Before the First War, all of humanity was united under the banner of the Arathorian Empire. Reclaim its greatness by uniting mankind once again.",
      "ReplaceableTextures\\CommandButtons\\BTNFireKingCrown.blp")
    {
      AddObjective(new ObjectiveControlLegend(LegendLordaeron.Arthas, true));
      AddObjective(new ObjectiveAcquireArtifact(ArtifactSetup.ArtifactCrownlordaeron));
      AddObjective(new ObjectiveAcquireArtifact(ArtifactSetup.ArtifactCrownstormwind));
      AddObjective(new ObjectiveLegendDead(LegendScourge.LegendLichking));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n010"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01G"))));
      Global = true;
    }

    protected override string CompletionPopup =>
      "The people of the Eastern Kingdoms have been united under the banner of Lordaeron. Long live High King Arthas Menethil!";

    protected override string RewardDescription =>
      "You gain a research improving all of your units, the Crowns of Lordaeron and Stormwind are merged, and Arthas becomes High King";


    protected override void OnComplete(Faction completingFaction)
    {
      //Artifact
      unit crownHolder = ArtifactSetup.ArtifactCrownstormwind.OwningUnit;
      RemoveItem(ArtifactSetup.ArtifactCrownlordaeron.Item);
      RemoveItem(ArtifactSetup.ArtifactCrownstormwind.Item);
      crownHolder.AddItemSafe(ArtifactSetup.ArtifactCrowneasternkingdoms.Item);
      ArtifactSetup.ArtifactCrownlordaeron.LocationType = ArtifactLocationType.Hidden;
      ArtifactSetup.ArtifactCrownlordaeron.LocationDescription = "Melted down";
      ArtifactSetup.ArtifactCrownstormwind.LocationType = ArtifactLocationType.Hidden;
      ArtifactSetup.ArtifactCrownstormwind.LocationDescription = "Melted down";
      //Research
      SetPlayerTechResearched(completingFaction.Player, RewardResearchId, 1);
      Display.DisplayResearchAcquired(completingFaction.Player, RewardResearchId, 1);
      //High King Arthas
      LegendLordaeron.Arthas.UnitType = FourCC("Harf");
      LegendLordaeron.Arthas.ClearUnitDependencies();
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(RewardResearchId, Faction.UNLIMITED);
    }
  }
}