using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;

namespace AzerothWarsCSharp.Source.Quests.Quelthalas
{
  public sealed class QuestTempestKeep : QuestData
  {
    private static readonly int QUEST_RESEARCH_ID = FourCC("R073"); //This research is given when the quest is completed


    protected override string CompletionPopup =>
  }

  protected override string CompletionDescription => "Control of the TempestKeep";

  protected override void OnComplete(){
  internal SetUnitOwner(LEGEND_KAEL.Unit, Player(PLAYER_NEUTRAL_AGGRESSIVE), true);
  this.Holder.obliterate();
  internal SetUnitOwner(LEGEND_KAEL.Unit, this.Holder.Player, true);
  FACTION_QUELTHALAS.AddQuest(SUMMON_KIL);
  SUMMON_KIL.Progress = QUEST_PROGRESS_UNDISCOVERED;
  FACTION_QUELTHALAS.AddQuest(GREAT_TREACHERY);
  GREAT_TREACHERY.Progress = QUEST_PROGRESS_UNDISCOVERED;
  FACTION_QUELTHALAS.AddQuest(STAY_LOYAL);
  STAY_LOYAL.Progress = QUEST_PROGRESS_UNDISCOVERED;
  FACTION_QUELTHALAS.ModObjectLimit(FourCC("H00Q"), -UNLIMITED); //Anasterian
  FACTION_QUELTHALAS.ModObjectLimit(FourCC("Hvwd"), -UNLIMITED); //Sylvanas
  FACTION_QUELTHALAS.ModObjectLimit(FourCC("n075"), -UNLIMITED); //Vareesa
  FACTION_QUELTHALAS.ModObjectLimit(FourCC("n00A"), -UNLIMITED); //Farstrider
  FACTION_QUELTHALAS.ModObjectLimit(FourCC("hhes"), -UNLIMITED); //Swordsman
  FACTION_QUELTHALAS.ModObjectLimit(FourCC("nbel"),UNLIMITED); //Sunfury
  FACTION_QUELTHALAS.ModObjectLimit(FourCC("n09S"), 6); //Ranger
  FACTION_QUELTHALAS.ModObjectLimit(FourCC("n02F"), 6); //Felblood Warlock
  FACTION_QUELTHALAS.ModObjectLimit(FourCC("e01B"), 6); //Arcane Anihilator
  FACTION_QUELTHALAS.ModObjectLimit(FourCC("H00Q"), -UNLIMITED); //Anasterian
  FACTION_QUELTHALAS.ModObjectLimit(FourCC("Hvwd"), -UNLIMITED); //sylvanas
  internal RemoveUnit(LEGEND_ANASTERIAN.Unit);
  internal RemoveUnit(LEGEND_SYLVANAS.Unit);
  internal SetUnitPosition(LEGEND_KAEL.Unit, 4067, -21695);
  internal SetUnitPosition(LEGEND_LORTHEMAR.Unit, 4067, -21695);
  internal UnitRemoveAbilityBJ(FourCC("A0IP"), LEGEND_KAEL.Unit);
  GeneralHelpers.RescueUnitsInGroup(udg_TempestKeep, this.Holder.Player);
  this.Holder.Team = TEAM_NAGA;
  internal UnitAddAbility(LEGEND_KAEL.Unit, FourCC("A0IK"));
  internal UnitAddAbility(LEGEND_KAEL.Unit, FourCC("A0IF"));
  internal AdjustPlayerStateBJ(2000, this.Holder.Player, PLAYER_STATE_RESOURCE_GOLD );
  internal AdjustPlayerStateBJ(4000, this.Holder.Player, PLAYER_STATE_RESOURCE_LUMBER );
  this.Holder.Name = "Blood Elves";
  this.Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNBloodMage2blp";
  if (GetLocalPlayer() == this.Holder.Player){
    SetCameraPosition(GetRectCenterX(Regions.TempestKeepSpawn).Rect, GetRectCenterY(gg_rct_TempestKeepSpawn));
  }
  }

  public QuestTempestKeep ( ) : base("In Search of Masters",
  "The Blood Elves are starved for magic; they need to search for more powerful sources of it. Maybe Outland is the answer to their plight."
  , "ReplaceableTextures\\CommandButtons\\BTNBloodelvenWarrior.blp"){
  this.
  internal AddQuestItem(
  internal new QuestItemCastSpell(FourCC("A0IP"), true));
  this.
  internal AddQuestItem(

  internal new QuestItemControlLegend(LEGEND_KAEL, true));
    this.ResearchId = QUEST_RESEARCH_ID;
  
  }
}

}