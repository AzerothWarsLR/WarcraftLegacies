using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.FactionSystem
{
  public static class PlayerExtensions
  {
    public static void SetControlPointCount(this player player, int value)
    {
      PlayerData.ByHandle(player).ControlPointCount = value;
    }
    
    public static int GetControlPointCount(this player player)
    {
      return PlayerData.ByHandle(player).ControlPointCount;
    }
    
    public static void AddGold(this player player, float gold)
    {
      PlayerData.ByHandle(player).AddGold(gold);
    }
    
    public static void SetObjectLevel(this player player, int objectId, int level)
    {
      PlayerData.ByHandle(player).SetObjectLevel(objectId, level);
    }
    
    public static void ModObjectLimit(this player player, int objectId, int limit)
    {
      PlayerData.ByHandle(player).ModObjectLimit(objectId, limit);
    }
    
    public static Faction? GetFaction(this player player)
    {
      return PlayerData.ByHandle(player).Faction;
    }

    public static void SetFaction(this player player, Faction faction)
    {
      PlayerData.ByHandle(player).Faction = faction;
    }

    public static float GetControlPointValue(this player player)
    {
      return PlayerData.ByHandle(player).ControlPointValue;
    }

    public static void SetControlPointValue(this player player, float value)
    {
      PlayerData.ByHandle(player).ControlPointValue = value;
    }
  }
}