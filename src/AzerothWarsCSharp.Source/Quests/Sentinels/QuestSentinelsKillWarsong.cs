using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Sentinels
{
  public sealed class QuestSentinelsKillWarsong : QuestData
  {
    private static readonly int ResearchId = FourCC("R007");

    public QuestSentinelsKillWarsong() : base("Green-skinned Brutes",
      "The Warsong Clan has arrived near Ashenvale && begun threatening the wilds. These invaders must be repelled.",
      "ReplaceableTextures\\CommandButtons\\BTNRaider.blp")
    {
      AddQuestItem(new QuestItemLegendDead(LEGEND_STONEMAUL));
      ;
      ;
    }


    protected override string CompletionPopup =>
      "The Warsong presence on Kalimdor has been eliminated. The land has been protected from their misbegotten race.";

    protected override string CompletionDescription => "Enable the Watcher Bastion to be built";

    protected override void OnComplete()
    {
      SetPlayerTechResearched(Holder.Player, ResearchId, 1);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(ResearchId, UNLIMITED);
    }
  }
}