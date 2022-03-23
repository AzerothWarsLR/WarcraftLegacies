
namespace AzerothWarsCSharp.Source.Mechanics.Frostwolf
{
  public class StructurePacking{

  
    private const int KODO_ID = FourCC(oosc);
  


    //! runtextmacro AIDS()
    effect PackedBuildingEffect

    private static bool AIDS_filter(unit u ){
      if (GetUnitTypeId(u) == KODO_ID){
        return true;
      }
      return false;
    }

    private void AIDS_onDestroy( ){
      DestroyEffect(PackedBuildingEffect);
      PackedBuildingEffect = null;
    }



    private static Table _byStructureId;

    private int _buildAbility;


    void SetupKodo(unit whichUnit ){

      BlzSetSpecialEffectScale(e, 025);
      BlzSetSpecialEffectTime(e, 100);
      PackKodo(GetUnitId(whichUnit)).PackedBuildingEffect = e;
      UnitAddAbility(whichUnit, _buildAbility);
      e = null;
    }





    this.buildAbility = buildAbility;
    ;;
  }
}



    }

    private static void PackBuilding(unit building, unit kodo ){
      if (thistype.byStructureId[GetUnitTypeId(building)] == 0){
        BJDebugMsg("ERROR: there is no PackableStructure setup for building "+ GetUnitName(building));
        return;
      }
      thistype(thistype.byStructureId[GetUnitTypeId(building)]).SetupKodo(kodo);
      RemoveUnit(building);
    }

    private static void OnAnyUnitCastSpell( ){
      if (GetUnitTypeId(GetTriggerUnit()) == KODO_ID){
        KillUnit(GetTriggerUnit());
        RemoveUnit(GetTriggerUnit());
      }
    }

    private static void OnTrainAnyUnit( ){
      if (GetUnitTypeId(GetTrainedUnit()) == KODO_ID){
        thistype.packBuilding(GetTriggerUnit(), GetTrainedUnit());
        RemoveUnit(GetTriggerUnit());
      }
    }

    private static void OnInit( ){
      trigger trig = CreateTrigger();
      TriggerRegisterAnyUnitEventBJ( trig, EVENT_PLAYER_UNIT_TRAIN_FINISH );
      TriggerAddAction( trig,  thistype.OnTrainAnyUnit);

      trig = CreateTrigger();
      TriggerRegisterAnyUnitEventBJ( trig, EVENT_PLAYER_UNIT_SPELL_ENDCAST );
      TriggerAddAction( trig,  thistype.OnAnyUnitCastSpell);

      thistype.byStructureId = Table.create();
    }


}
