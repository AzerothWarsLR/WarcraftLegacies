using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Setup.Legends;

namespace AzerothWarsCSharp.Source.Quests.BlackEmpire
{
  public sealed class QuestBladeOfTheBlackEmpire : QuestData
  {
    private readonly QuestData _sequel;

    public QuestBladeOfTheBlackEmpire(QuestData sequel) : base("Xal'atath",
      "Xal'atath is one of the oldest and most powerful entities serving the Old Gods, living inside a cursed blade. A human priestess stole it long ago; the blade is entombed with her in Duskwood Crypt.",
      "ReplaceableTextures\\CommandButtons\\BTNmidnightGS.blp")
    {
      _sequel = sequel;
      AddQuestItem(new ObjectiveLegendInRect(LegendBlackEmpire.legendVolazj, Regions.DuskwoodCrypt,
        "Duskwood Graveyard Crypt"));
      AddQuestItem(new ObjectiveControlLegend(LegendNeutral.LegendDuskwoodgraveyard, false));
    }

    protected override string CompletionPopup => "Herald Volazj has found the Black Blade, Xal'alath.";

    protected override string RewardDescription =>
      "Xal'alath will be ours and the Tomb of Tyr quest will be revealed.";

    protected override void OnComplete(Faction completingFaction)
    {
      if (LegendBlackEmpire.legendVolazj.Unit != null && ArtifactSetup.ArtifactXalatath != null)
        LegendBlackEmpire.legendVolazj.Unit.AddItemSafe(ArtifactSetup.ArtifactXalatath.Item);
      BlackEmpireSetup.FactionBlackempire.AddQuest(_sequel);
      _sequel.Progress = QuestProgress.Incomplete;
    }
  }
}