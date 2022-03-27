namespace AzerothWarsCSharp.Source.Mechanics.BlackEmpire
{
  public class ReturnToNyalotha{

  
    private const string EFFECT = "Abilities\\Spells\\Items\\AIre\\AIreTarget.mdl";
  

    private static void ReturnUnitToNyalotha(unit whichUnit ){
      var angle = GetRandomReal(0, 360);
      var distance = GetRandomReal(100, 400);
      float x = GetPolarOffsetX(-25543, distance, angle);
      float y = GetPolarOffsetY(-1962, distance, angle);

      DestroyEffect(AddSpecialEffect(EFFECT, GetUnitX(whichUnit), GetUnitY(whichUnit)));
      DestroyEffect(AddSpecialEffect(EFFECT, x, y));

      SetUnitX(whichUnit, x);
      SetUnitY(whichUnit, y);
      IssueImmediateOrder(whichUnit, "stop");
    }

    static void ReturnToNyalotha( ){
      group tempGroup = CreateGroup();
      unit u;
      GroupEnumUnitsOfPlayer(tempGroup, FACTION_BLACKEMPIRE.Player, null);
      while(true){
        u = FirstOfGroup(tempGroup);
        if ( u == null){ break; }
        if (!IsUnitInRect(u, gg_rct_NyalothaInstance) && BlzIsUnitInvulnerable(u) == false && IsUnitType(u, UNIT_TYPE_ANCIENT) == false){
          if (IsUnitType(u, UNIT_TYPE_STRUCTURE)){
            KillUnit(u);
          }else {
            ReturnUnitToNyalotha(u);
          }
        }
        GroupRemoveUnit(tempGroup, u);
      }
      DestroyGroup(tempGroup);
      
      u = null;
    }

  }
}
