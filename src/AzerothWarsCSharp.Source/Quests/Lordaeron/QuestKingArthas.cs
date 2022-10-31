using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Extensions;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestKingArthas : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R08A"); //This research is given when the quest is completed
    private readonly unit _terenas;

    public QuestKingArthas(unit terenas) : base("Line of Succession",
      "Arthas Menethil is the one true heir of the Kingdom of Lordaeron. The only thing standing in the way of his coronation is the world-ending threat of the Scourge.",
      "ReplaceableTextures\\CommandButtons\\BTNArthas.blp")
    {
      AddObjective(new ObjectiveLegendNotPermanentlyDead(LegendLordaeron.LegendCapitalpalace));
      AddObjective(new ObjectiveControlLegend(LegendLordaeron.LegendArthas, true));
      AddObjective(new ObjectiveLegendDead(LegendScourge.LegendLichking));
      AddObjective(new ObjectiveLegendInRect(LegendLordaeron.LegendArthas, Regions.King_Arthas_crown, "King Terenas"));
      ResearchId = QuestResearchId;
      _terenas = terenas;
      Required = true;
    }
    
    protected override string CompletionPopup =>
      "With the Lich King eliminated, the Kingdom of Lordaeron is free of its greatest threat. King Terenas Menethil proudly abdicates in favor of his son.";

    protected override string RewardDescription =>
      "Arthas gains 2000 experience and the Crown of Lordaeron, and he can no longer permanently die";

    protected override void OnComplete(Faction completingFaction)
    {
      BlzSetUnitName(LegendLordaeron.LegendArthas.Unit, "King of Lordaeron");
      BlzSetUnitName(_terenas, "King Emeritus Terenas Menethil");
      RemoveUnit(_terenas);
      AddHeroXP(LegendLordaeron.LegendArthas.Unit, 2000, true);
      LegendLordaeron.LegendArthas.Unit.AddItemSafe(ArtifactSetup.ArtifactCrownlordaeron.Item);
      LegendLordaeron.LegendArthas.ClearUnitDependencies();
    }
  }
}