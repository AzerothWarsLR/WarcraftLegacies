using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Druids
{
  public sealed class QuestDruidsKillWarsong : QuestData
  {
    private const int UNITTYPE_ID = Constants.UNIT_E012_SIEGE_ANCIENT_DRUIDS_ELITE;

    public QuestDruidsKillWarsong() : base("Enemies at the Gate",
      "Arriving from another planet and across the seas of Azeroth, the Orcs of the Warsong Clan have arrived to ravage the wilderness and consume its bounty. They must be stopped.",
      "ReplaceableTextures\\CommandButtons\\BTNHellScream.blp")
    {
      AddObjective(new ObjectiveLegendDead(LegendWarsong.StonemaulKeep));
      ResearchId = FourCC("R05A");
    }
    
    protected override string CompletionPopup =>
      "The Warsong presence on Kalimdor has been eliminated. The sacred lands are safe from their hatchets.";

    protected override string RewardDescription => "Learn to train " + GetObjectName(UNITTYPE_ID) + "s";

    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player.DisplayUnitTypeAcquired(UNITTYPE_ID, "You can now train Siege Ancients at the Ancient of War.");
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(UNITTYPE_ID, 6); //Siege Ancient
    }
  }
}