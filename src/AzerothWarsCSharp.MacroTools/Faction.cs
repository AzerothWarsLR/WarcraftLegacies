using System.Collections.Generic;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Libraries.MacroSystem
{
  public class Faction
  {
    public string Icon { get; }
    public int ControlPointCount { get; set; } = 0;
    public int Income { get; set; } = 0;
    public string Name { get; }
    public string PrefixColor { get; }
    internal Team Team { get; set; }
    public player Player { get; internal set; }
    private readonly List<Quest> _quests = new();

    internal void AddQuest(Quest quest)
    {
      _quests.Add(quest);
    }

    internal void RemoveQuest(Quest quest)
    {
      _quests.Remove(quest);
    }
    
    public Faction(string name, playercolor playerColor, string prefixColor, string iconName)
    {
      Name = name;
      Icon = iconName;
      PrefixColor = prefixColor;
    }
  }
}