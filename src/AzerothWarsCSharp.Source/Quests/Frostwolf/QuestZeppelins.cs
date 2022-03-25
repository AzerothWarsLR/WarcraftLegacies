using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Frostwolf
{
  public sealed class QuestZeppelins : QuestData
  {
    private const int LIMIT_CHANGE = 2;


    private static readonly int ResearchId = FourCC("R058");
    private static readonly int UnittypeId = FourCC("nzep");

    public QuestZeppelins() : base("The Spirits of Ashenvale",
      "The Sentinels have laid claim over Kalimdor. As long as they survive, the Orcs will never be safe.",
      "ReplaceableTextures\\CommandButtons\\BTNGoblinZeppelin.blp")
    {
      AddQuestItem(new QuestItemLegendDead(LEGEND_AUBERDINE));
      AddQuestItem(new QuestItemLegendDead(LEGEND_FEATHERMOON));
      ;
      ;
    }


    protected override string CompletionPopup =>
      "The Sentinels have been slain. With their Hippogryphs no longer terrorizing the skies, the Horde can field its refurbished Zeppelins.";

    protected override string CompletionDescription => "Learn to train " + GetObjectName(UnittypeId) + "s";

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(UnittypeId, LIMIT_CHANGE);
      Holder.ModObjectLimit(ResearchId, Faction.UNLIMITED);
    }

    protected override void OnComplete()
    {
      SetPlayerTechResearched(Holder.Player, ResearchId, 1);
      DisplayUnitTypeAcquired(Holder.Player, UnittypeId, "You can now train Zeppelins from the Goblin Laboratory.");
    }
  }
}