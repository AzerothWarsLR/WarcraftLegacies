using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Sentinels
{
  public sealed class QuestVaultoftheWardens : QuestData{

  
    private const int RESEARCH_ID = FourCC("R06H");
    private const int WARDEN_ID = FourCC("h045");
  


    protected override string CompletionPopup => "With the Broken Isles && the Tomb of Sargeras secured, work has begun on a maximum security prison named the Vault of the Wardens.";

    protected override string CompletionDescription => "The Vault of the Wardens && 4 free Wardens appear at the Broken Isles, && you learn to train Wardens";

    protected override void OnComplete(){
      CreateUnit(this.Holder.Player, FourCC("n04G"), GetRectCenterX(Regions.VaultoftheWardens), GetRectCenterY(gg_rct_VaultoftheWardens).Rect, 220);
      GeneralHelpers.CreateUnits(this.Holder.Player, WARDEN_ID, GetRectCenterX(Regions.VaultoftheWardens), GetRectCenterY(gg_rct_VaultoftheWardens), 270.Rect, 4);
      SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1);
      DisplayUnitTypeAcquired(Holder.Player, WARDEN_ID, "You can now train Wardens from the Vault of the Wardens, Sentinel Enclaves, && your capitals.");
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(WARDEN_ID, 8);
      this.Holder.ModObjectLimit(RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Vault of the Wardens", "In millenia past, the most vile entities of Azeroth were imprisoned in a facility near Zin-Ashari. The Broken Isles, now raised from the sea floor, would be a strategic location for a newer edition of such a prison.", "ReplaceableTextures\\CommandButtons\\BTNReincarnationWarden.blp");
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n05Y"))));
      this.AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
