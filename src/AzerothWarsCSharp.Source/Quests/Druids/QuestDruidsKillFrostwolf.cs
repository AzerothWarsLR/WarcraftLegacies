using AzerothWarsCSharp.MacroTools.QuestSystem;

namespace AzerothWarsCSharp.Source.Quests.Druids
{
  public sealed class QuestDruidsKillFrostwolf : QuestData
  {
    private static readonly int ResearchId = FourCC("R044");
    private static readonly int ElementalGuardianId = FourCC("e00X");
    private GetObjectName(ELEMENTAL_GUARDIAN_ID);


    protected override string CompletionPopup =>
      "The Frostwolves have been driven from Kalimdor. Their departure reveals the existence of a powerful nature spirit that now heeds the of the Druids.";

    protected override string CompletionDescription =>
    return "The demihero " +
  }

  protected override void OnComplete(){
  internal SetPlayerTechResearched(this.Holder.Player, RESEARCH_ID, 1);
  internal DisplayUnitTypeAcquired(this.Holder.Player, ELEMENTAL_GUARDIAN_ID,
  "You can now train the Elemental Guardian from the Altar of Elders.");
  }

  protected override void OnAdd( ){
  this.Holder.ModObjectLimit(ELEMENTAL_GUARDIAN_ID, 1);
  this.Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
  }

  public QuestDruidsKillFrostwolf ( ) : base("Natural Contest",
  "The Frostwolf Clan has arrived on the shores of Kalimdor. Though their respect of the wild spirits is to be admired, their presence can!be tolerated."
  , "ReplaceableTextures\\CommandButtons\\BTNHeroTaurenChieftain.blp"){
  this.
  internal AddQuestItem(

  internal new QuestItemLegendDead(LEGEND_THUNDERBLUFF));
    ;;
  }
}

}