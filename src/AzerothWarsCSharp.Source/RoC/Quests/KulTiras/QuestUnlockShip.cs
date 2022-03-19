using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.KulTiras
{
  public class QuestUnlockShip{


    protected override string CompletionPopup => 
      return "The Proudmoore capital ship is now ready to sails!";
    }

    protected override string CompletionDescription => 
      return "Unpause the Proudmoore capital ship && unlocks the buildings inside.";
    }

    private string operator FailurePopup( ){
      return "Boralus has fallen, Katherine has escaped on the Proudmoore Capital Ship with a handful of Survivors.";
    }

    private string operator FailureDescription( ){
      return "You lose everything you control, but you gain Katherine at the capital ship.";
    }

    protected override void OnComplete(){
      RescueNeutralUnitsInRect(gg_rct_ShipAmbient, this.Holder.Player);
      PauseUnitBJ( false, gg_unit_h08T_0260 );
    }

    private void OnFail( ){
      unit u;
      player holderPlayer = this.Holder.Person.Player;
      LEGEND_KATHERINE.StartingXp = GetHeroXP(LEGEND_KATHERINE.Unit);
      this.Holder.obliterate();
      LEGEND_KATHERINE.Spawn(this.Holder.Player, -15223, -22856, 110);
      UnitAddItem(LEGEND_KATHERINE.Unit, CreateItem(FourCC(I00M), GetUnitX(LEGEND_KATHERINE.Unit), GetUnitY(LEGEND_KATHERINE.Unit)));
      if (GetLocalPlayer() == this.Holder.Player){
        SetCameraPosition(GetRectCenterX(gg_rct_ShipAmbient), GetRectCenterY(gg_rct_ShipAmbient));
      }
      RescueNeutralUnitsInRect(gg_rct_ShipAmbient, this.Holder.Player);
      PauseUnitBJ( false, gg_unit_h08T_0260 );
      SetUnitOwner(gg_unit_h08T_0260, this.Holder.Player, true);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Zandalar Menace", "The Troll Empire of Zandalar is a danger to the safety of KulFourCC(tiras && the Alliance. Before setting sail, we must eliminate them.", "ReplaceableTextures\\CommandButtons\\BTNGalleonIcon.blp");
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_DAZARALOR, false));
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_BORALUS, true));
      ;;
    }


  }
}
