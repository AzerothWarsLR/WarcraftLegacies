using System;
using System.Collections.Generic;
using System.Linq;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools
{
  public class Faction
  {
    public event EventHandler<FactionEventArgs>? NameChanged;
    public event EventHandler<FactionEventArgs>? IconChanged;
    public event EventHandler<FactionEventArgs>? PlayerColorChanged;
    public event EventHandler<FactionEventArgs>? ControlPointCountChanged;
    public event EventHandler<FactionEventArgs>? IncomeChanged;
    public event EventHandler<FactionEventArgs>? PrefixColorChanged;

    private string _icon;
    public string Icon
    {
      get => _icon;
      set
      {
        _icon = value;
        IconChanged?.Invoke(this, new FactionEventArgs(this));
      }
    }

    private playercolor _playerColor;

    public playercolor PlayerColor
    {
      get => _playerColor;
      set
      {
        _playerColor = value;
        PlayerColorChanged?.Invoke(this, new FactionEventArgs(this));
      }
    }

    private int _controlPointCount = 0;
    public int ControlPointCount
    {
      get => _controlPointCount;
      set
      {
        _controlPointCount = value;
        ControlPointCountChanged?.Invoke(this, new FactionEventArgs(this));
      }
    }

    private int _income = 0;
    public int Income
    {
      get => _income;
      set
      {
        _income = value;
        IncomeChanged?.Invoke(this, new FactionEventArgs(this));
      }
    }

    private string _name;
    public string Name
    {
      get => _name;
      set
      {
        _name = value;
        NameChanged?.Invoke(this, new FactionEventArgs(this));
      }
    }

    private string _prefixColor;
    public string PrefixColor
    {
      get => _prefixColor;
      set
      {
        _prefixColor = value;
        PrefixColorChanged?.Invoke(this, new FactionEventArgs(this));
      }
    }
    
    internal Team? Team { get; set; }
    
    public player? Player { get; internal set; }
    private readonly List<Quest> _quests = new();

    public List<Quest> GetQuests()
    {
      return _quests.ToList();
    }
    
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
      PlayerColor = playerColor;
      Icon = iconName;
      PrefixColor = prefixColor;
    }
  }
}