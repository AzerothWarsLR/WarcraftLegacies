using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestCivilWar : QuestData
  {
    protected override string CompletionPopup => "The Lich King has rebelled against his demon masters";

    protected override string RewardDescription => "Unally from the Legion team";

    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player?.SetTeam(TeamSetup.Scourge);
    }

    public QuestCivilWar() : base("Civil War",
      "The Lich King wants to break free from his Demon Master, but he will need a champion first",
      "ReplaceableTextures\\CommandButtons\\BTNTheLichKingQuest.blp")
    {
      AddObjective(new ObjectiveResearch(FourCC("R07W"), FourCC("u000")));
      AddObjective(new ObjectiveControlLegend(LegendLordaeron.LegendArthas, false));
      AddObjective(new ObjectiveTime(900));
      Global = true;
    }
  }
}