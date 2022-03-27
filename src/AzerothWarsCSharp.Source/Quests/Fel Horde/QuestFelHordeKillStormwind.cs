using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;

namespace AzerothWarsCSharp.Source.Quests.Fel_Horde
{
  public sealed class QuestFelHordeKillStormwind : QuestData
  {
    private const int UNIT_LIMIT = 6;


    private static readonly int ResearchId = FourCC("R05Z");
    private static readonly int UnittypeId = FourCC("n086");
    private static readonly int BuildingId = FourCC("o030");
    private I2S(UNIT_LIMIT) + " " +
    private GetObjectName(UNITTYPE_ID) + "s from the " +
    private GetObjectName(BUILDING_ID);


    protected override string CompletionPopup =>
      "StormwindFourCC(s annihilation has left behind the corpses of thousands of elite knights. As occurred during the Second War, these corpses have been filled with the souls of slain Shadow Council members, recreating the indominatable order of Death Knights.";

    protected override string CompletionDescription =>
    return "Teron Gorefiend can be trained at the altar && learn to train " +
  }

  protected override void OnComplete(){
  internal SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1);
  }

  protected override void OnAdd( ){
  Holder.ModObjectLimit(RESEARCH_ID, Faction.UNLIMITED);
  Holder.ModObjectLimit(UNITTYPE_ID, UNIT_LIMIT);
  }

  public QuestFelHordeKillStormwind ( ) : base("Those Who Came Before",
  "During the Second War, the souls of slain Shadow Council members were infused into the corpses of Stormwind knights to create the Death Knights. If Stormwind were to fall again, the unholy order could return."
  , "ReplaceableTextures\\CommandButtons\\BTNAcolyte.blp"){
  this.
  internal AddQuestItem(

  internal new QuestItemLegendDead(LEGEND_STORMWINDKEEP));
    
  }
}

}