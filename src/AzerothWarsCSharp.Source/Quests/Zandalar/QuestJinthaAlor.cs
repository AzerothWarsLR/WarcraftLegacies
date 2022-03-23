using AzerothWarsCSharp.MacroTools.QuestSystem;

namespace AzerothWarsCSharp.Source.Quests.Zandalar
{
  public sealed class QuestJinthaAlor : QuestData
  {
    private static readonly int JinthaalorResearch = FourCC("R02N");
    private static readonly int BearRiderId = FourCC("o02K");
    private static readonly int TrollShrineId = FourCC("o04X");
    private GetObjectName(TROLL_SHRINE_ID);


    protected override string CompletionPopup =>
      "JinthaFourCC(Alor has fallen. The Vilebranch trolls lend their might to the " + Holder.Team.Name + ".";

    protected override string CompletionDescription =>
    return "Control of JinthaFourCC("Alor, 300
    private gold Tribute&&
    private the Ability
    private to Train" + GetObjectName(BEAR_RIDER_ID") + "s from the " +
  }

  protected override void OnComplete(){
  internal SetPlayerTechResearched(Holder.Player, JINTHAALOR_RESEARCH, 1);
  internal AdjustPlayerStateBJ(300, this.Holder.Player, PLAYER_STATE_RESOURCE_GOLD );
  }

  protected override void OnAdd( ){
  this.Holder.ModObjectLimit(JINTHAALOR_RESEARCH, UNLIMITED);
  }

  public QuestJinthaAlor ( ) : base("The Ancient Egg", "The Vilebranch trolls of JinthaFourCC("Alor are controlled by
  their fear of the Soulflayer")s egg, hidden within their shrine. Smash it to gain their loyalty.",
  "ReplaceableTextures\\CommandButtons\\BTNForestTrollShadowPriest.blp"){
  this.
  internal AddQuestItem(

  internal new QuestItemControlLegend(LEGEND_JINTHAALOR, false));
    
  }
}

}