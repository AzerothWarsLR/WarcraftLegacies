using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Druids
{
  public sealed class QuestDruidsKillWarsong : QuestData
  {
    private const int UNITTYPE_ID = FourCC("e012"); //Siege Ancient
    private const int RESEARCH_ID = FourCC("R05A"); //Research enabling Siege Ancient

    public QuestDruidsKillWarsong() : base("Enemies at the Gate",
      "Arriving from another planet && across the seas of Azeroth, the Orcs of the Warsong Clan have arrived to ravage the wilderness && consume its bounty. They must be stopped.",
      "ReplaceableTextures\\CommandButtons\\BTNHellScream.blp")
    {
      AddQuestItem(new QuestItemLegendDead(LEGEND_STONEMAUL));
      ;
      ;
    }


    protected override string CompletionPopup =>
      "The Warsong presence on Kalimdor has been eliminated. The sacred lands are safe from their hatchets.";

    protected override string RewardDescription => "Learn to train " + GetObjectName(UNITTYPE_ID) + "s";

    protected override void OnComplete()
    {
      SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1);
      DisplayUnitTypeAcquired(Holder.Player, UNITTYPE_ID, "You can now train Siege Ancients at the Ancient of War.");
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(UNITTYPE_ID, 6); //Siege Ancient
    }
  }
}