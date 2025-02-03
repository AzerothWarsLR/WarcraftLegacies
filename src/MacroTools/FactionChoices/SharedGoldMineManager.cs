using System.Collections.Generic;
using MacroTools.FactionSystem;
using static War3Api.Common;



namespace MacroTools.FactionChoices
{
  public class SharedGoldMineManager
  {
    private readonly Dictionary<unit, List<Faction>> _sharedGoldMines = new Dictionary<unit, List<Faction>>();

    public void RegisterSharedGoldMine(unit goldMine, Faction faction)
    {
      if (!_sharedGoldMines.ContainsKey(goldMine))
      {
        _sharedGoldMines[goldMine] = new List<Faction>();
      }
      _sharedGoldMines[goldMine].Add(faction);
    }

    public bool IsSharedGoldMine(unit goldMine)
    {
      return _sharedGoldMines.ContainsKey(goldMine) && _sharedGoldMines[goldMine].Count > 1;
    }
  }
}