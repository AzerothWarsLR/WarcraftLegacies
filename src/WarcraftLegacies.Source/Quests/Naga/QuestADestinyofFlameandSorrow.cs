using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;


namespace WarcraftLegacies.Source.Quests.Naga
{
  public sealed class QuestADestinyofFlameandSorrow : QuestData
  {
    public QuestADestinyofFlameandSorrow() : base("A Destiny of Flame and Sorrow",
      "The Skull of Gul'dan calls for Illidan. If he could harness it's power, he would gain immeasureable power",
      "ReplaceableTextures\\CommandButtons\\BTNGuldanSkull.blp")
    {
      AddObjective(new ObjectiveLegendHasArtifact(LegendNaga.LegendIllidan, ArtifactSetup.ArtifactSkullofguldan));
      ResearchId = FourCC("R095");
    }

    protected override string CompletionPopup =>
      "The Skull of Gul'dan has given Illidan Demonic power beyond measure";

    protected override string RewardDescription =>
      "You can now cast Metamorphosis with Illidan";
  }
}