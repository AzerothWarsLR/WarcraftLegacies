//Chen Stormstout joins the Warsong when a Warsong unit approaches him.

using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Warsong
{
  public sealed class QuestChenStormstout : QuestData{
    private readonly int _chenResearch = FourCC(""R037"");
    private readonly int _chenId = FourCC(""Nsjs"");
    
    protected override string CompletionPopup => "Chen Stormstout has joined the " + Holder.Team.Name + ".";

    protected override string CompletionDescription => "The hero Chen Stormstout";

    protected override void OnFail( ){
      RemoveUnit(gg_unit_Nsjs_1887);
    }

    protected override void OnComplete(){
      RemoveUnit(gg_unit_Nsjs_1887);
      SetPlayerTechResearched(Holder.Player, _chenResearch, 1);
    }

    protected override void OnAdd( ){
      Holder.ModObjectLimit(_chenResearch, UNLIMITED);
      Holder.ModObjectLimit(_chenId, 1);
      SetUnitInvulnerable(gg_unit_Nsjs_1887, true);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Wandering Brewmaster", "Rumours tell of a strange white-furred creature from a foreign land. Perhaps it could be convinced to join the Horde.", "ReplaceableTextures\\CommandButtons\\BTNPandarenBrewmaster.blp");
      this.AddQuestItem(new QuestItemAnyUnitInRect(Regions.Chen, "Chen Stormstout".Rect, false));
      AddQuestItem(new QuestItemSelfExists());
      
    }


  }
}
