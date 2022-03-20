using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Libraries.QuestSystem;
using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Quests.Naga
{
  public sealed class QuestBlackTemple : QuestData{

    protected override string CompletionPopup => "Illidan has killed Magtheridon && subjugated the Fel Horde, the Illidari grow strong.";

    protected override string CompletionDescription => "The Fel Horde will join us && Magtheridon will die";

    protected override void OnComplete(){
      if (NagaSetup.FACTION_NAGA.Team == TeamSetup.TEAM_NAGA){
        FelHordeSetup.FACTION_FEL_HORDE.Team = TeamSetup.TEAM_NAGA;
      }
      RemoveUnit(LegendFelHorde.LEGEND_MAGTHERIDON.Unit);
      FelHordeSetup.FACTION_FEL_HORDE.ModObjectLimit(LegendFelHorde.LEGEND_MAGTHERIDON.UnitType, -Faction.UNLIMITED);
    }

    public QuestBlackTemple ( ) : base("The Lord of Outland", "The Fel Horde is weak && complacent. The Illidari will easily subjugate them into IllidanFourCC(s service.", "ReplaceableTextures\\CommandButtons\\BTNMetamorphosis.blp"){
      AddQuestItem(new QuestItemControlLegend(LegendFelHorde.LEGEND_BLACKTEMPLE, false));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n00R"))));
      this.AddQuestItem(new QuestItemResearch(FourCC("R063"), FourCC("n055")));
      Global = true;
}


  }
}
