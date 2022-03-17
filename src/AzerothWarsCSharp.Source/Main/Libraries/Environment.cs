namespace AzerothWarsCSharp.Source.Main.Libraries
{
  public class Environment{

  
    const int MAX_PLAYERS = 28;
    private unit PosUnit;
  

    native UnitAlive(unit id ){
      native GetUnitGoldCost(int unitid ){
        native GetUnitWoodCost(int unitid ){

          //Player(21) is used as a hostile computer player in this map. Use this to check if a player is neutral hostile or this pseudo-player.
          static boolean IsPlayerNeutralHostile(player whichPlayer ){
            if (whichPlayer == Player(21) || whichPlayer == Player(PLAYER_NEUTRAL_AGGRESSIVE)){
              return true;
            }
            return false;
          }

          static float GetPositionZ(float x, float y ){
            SetUnitX(PosUnit,x);
            SetUnitY(PosUnit,y);
            return BlzGetUnitZ(PosUnit);
          }

          static boolean IsUnitInRect(unit u, rect r ){
            return GetUnitX(u) > GetRectMinX(r)-32 && GetUnitX(u) < GetRectMaxX(r)+32 && GetUnitY(u) > GetRectMinY(r)-32 && GetUnitY(u) < GetRectMaxY(r)+32;
          }

          private static void OnInit( ){
            PosUnit = CreateUnit(Player(PLAYER_NEUTRAL_PASSIVE), FourCC(u00X), 0, 0, 0);
          }

        }
}
