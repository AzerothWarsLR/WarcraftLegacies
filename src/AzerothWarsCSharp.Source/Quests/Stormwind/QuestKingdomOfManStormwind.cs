using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ArtifactSystem;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static AzerothWarsCSharp.MacroTools.Libraries.Display;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestKingdomOfManStormwind : QuestData
  {
    private const int EXPERIENCE_REWARD = 6000;

    public QuestKingdomOfManStormwind() : base("Kingdom of Man",
      "Before the First War, all of humanity was united under the banner of the Arathorian Empire. Reclaim its greatness by uniting mankind once again.",
      "ReplaceableTextures\\CommandButtons\\BTNFireKingCrown.blp")
    {
      AddObjective(new ObjectiveLegendNotPermanentlyDead(LegendStormwind.LegendVarian));
      AddObjective(new ObjectiveAcquireArtifact(ArtifactSetup.ArtifactCrownlordaeron));
      AddObjective(new ObjectiveAcquireArtifact(ArtifactSetup.ArtifactCrownstormwind));
      AddObjective(new ObjectiveControlLegend(LegendFelHorde.LegendBlacktemple, false));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n010"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01G"))));
      ResearchId = FourCC("R01N");
      Global = true;
    }

    protected override string CompletionPopup =>
      "The people of the Eastern Kingdoms have been united under the banner of Stormwind. Long live High King Varian Wrynn!";

    protected override string RewardDescription =>
      "You gain a research improving all of your units, the Crowns of Lordaeron and Stormwind are merged, and Varian gains " +
      I2S(EXPERIENCE_REWARD) + ".";

    protected override void OnComplete(Faction completingFaction)
    {
      unit crownHolder = ArtifactSetup.ArtifactCrownstormwind.OwningUnit;
      RemoveItem(ArtifactSetup.ArtifactCrownlordaeron.Item);
      RemoveItem(ArtifactSetup.ArtifactCrownstormwind.Item);
      crownHolder.AddItemSafe(ArtifactSetup.ArtifactCrowneasternkingdoms.Item);
      ArtifactSetup.ArtifactCrownlordaeron.LocationType = ArtifactLocationType.Hidden;
      ArtifactSetup.ArtifactCrownlordaeron.LocationDescription = "Melted down";
      ArtifactSetup.ArtifactCrownstormwind.LocationType = ArtifactLocationType.Hidden;
      ArtifactSetup.ArtifactCrownstormwind.LocationDescription = "Melted down";
      SetPlayerTechResearched(completingFaction.Player, ResearchId, 1);
      DisplayResearchAcquired(completingFaction.Player, ResearchId, 1);
      BlzSetUnitName(LegendStormwind.LegendVarian.Unit, "High King");
      AddHeroXP(LegendStormwind.LegendVarian.Unit, EXPERIENCE_REWARD, true);
    }
  }
}