using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
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
  internal SetUnitOwner(LegendQuelthalas.LegendKael.Unit, Player(PLAYER_NEUTRAL_AGGRESSIVE), true);
  this.Holder.Obliterate();
  internal SetUnitOwner(LegendQuelthalas.LegendKael.Unit, this.Holder.Player, true);
  QuelthalasSetup.FactionQuelthalas.AddQuest(SUMMON_KIL);
  SUMMON_KIL.Progress = QUEST_PROGRESS_UNDISCOVERED;
  QuelthalasSetup.FactionQuelthalas.AddQuest(GREAT_TREACHERY);
  GREAT_TREACHERY.Progress = QUEST_PROGRESS_UNDISCOVERED;
  QuelthalasSetup.FactionQuelthalas.AddQuest(STAY_LOYAL);
  STAY_LOYAL.Progress = QUEST_PROGRESS_UNDISCOVERED;
  QuelthalasSetup.FactionQuelthalas.ModObjectLimit(FourCC("H00Q"), -Faction.UNLIMITED); //Anasterian
  QuelthalasSetup.FactionQuelthalas.ModObjectLimit(FourCC("Hvwd"), -Faction.UNLIMITED); //Sylvanas
  QuelthalasSetup.FactionQuelthalas.ModObjectLimit(FourCC("n075"), -Faction.UNLIMITED); //Vareesa
  QuelthalasSetup.FactionQuelthalas.ModObjectLimit(FourCC("n00A"), -Faction.UNLIMITED); //Farstrider
  QuelthalasSetup.FactionQuelthalas.ModObjectLimit(FourCC("hhes"), -Faction.UNLIMITED); //Swordsman
  QuelthalasSetup.FactionQuelthalas.ModObjectLimit(FourCC("nbel"),UNLIMITED); //Sunfury
  QuelthalasSetup.FactionQuelthalas.ModObjectLimit(FourCC("n09S"), 6); //Ranger
  QuelthalasSetup.FactionQuelthalas.ModObjectLimit(FourCC("n02F"), 6); //Felblood Warlock
  QuelthalasSetup.FactionQuelthalas.ModObjectLimit(FourCC("e01B"), 6); //Arcane Anihilator
  QuelthalasSetup.FactionQuelthalas.ModObjectLimit(FourCC("H00Q"), -Faction.UNLIMITED); //Anasterian
  QuelthalasSetup.FactionQuelthalas.ModObjectLimit(FourCC("Hvwd"), -Faction.UNLIMITED); //sylvanas
  internal RemoveUnit(LEGEND_ANASTERIAN.Unit);
  internal RemoveUnit(LEGEND_SYLVANAS.Unit);
  internal SetUnitPosition(LegendQuelthalas.LegendKael.Unit, 4067, -21695);
  internal SetUnitPosition(LEGEND_LORTHEMAR.Unit, 4067, -21695);
  internal UnitRemoveAbilityBJ(FourCC("A0IP"), LegendQuelthalas.LegendKael.Unit);
  GeneralHelpers.RescueUnitsInGroup(udg_TempestKeep, this.Holder.Player);
  this.Holder.Team = TeamSetup.TeamNaga;
  internal UnitAddAbility(LegendQuelthalas.LegendKael.Unit, FourCC("A0IK"));
  internal UnitAddAbility(LegendQuelthalas.LegendKael.Unit, FourCC("A0IF"));
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

  internal new QuestItemControlLegend(LegendQuelthalas.LegendKael, true));
    this.ResearchId = QUEST_RESEARCH_ID;
  
  }
}

}