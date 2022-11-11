//Illidan Goes to Aetheneum, Finds Immoltar and kills him

using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Quests.Naga
{
  public sealed class QuestIllidanChapterOne : QuestData
  {
    private readonly QuestData _questToDiscover;

    public QuestIllidanChapterOne(QuestData questToDiscover) : base("Chapter One: The Aetheneum Secrets",
      "In order to gain the power he craves, Illidan must plunder the hidden Aetheneum library for its secrets.",
      "ReplaceableTextures\\CommandButtons\\BTNDoomlord.blp")
    {
      this.AddObjective(new ObjectiveLegendReachRect(LegendNaga.LegendIllidan, Regions.Dire_Maul_Entrance, "Feralas"));
      this.AddObjective(new ObjectiveLegendReachRect(LegendNaga.LegendIllidan, Regions.AethneumLibraryEntrance,
        "the Aetheneum Library"));
      this.AddObjective(new ObjectiveLegendReachRect(LegendNaga.LegendIllidan, Regions.ImmolFight,
        "Immol'thar's Lair"));
      AddObjective(new ObjectiveLegendDead(LegendNeutral.LegendImmolthar));
      _questToDiscover = questToDiscover;
      ;
      ;
    }

    protected override string CompletionPopup =>
      "Illidan has learned of the existence of the Skull of GulFourCC(dan, hidden in Dalaran";

    protected override string RewardDescription => "Chapter Two - The Skull of GulFourCC(dan";

    protected override void OnComplete(Faction completingFaction)
    {
      _questToDiscover.Progress = QuestProgress.Incomplete;
    }
  }
}