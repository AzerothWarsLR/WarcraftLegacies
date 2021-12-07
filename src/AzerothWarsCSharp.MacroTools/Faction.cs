using System;
using System.Collections.Generic;
using System.Linq;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools
{
  public class Faction
  {
    private readonly List<Quest> _quests = new();

    private int _controlPointCount;

    private string _icon;

    private int _income;

    private string _name;

    private playercolor _playerColor;

    private string _prefixColor;

    public Faction(string name, playercolor playerColor, string prefixColor, string iconName)
    {
      _name = name;
      _playerColor = playerColor;
      _icon = iconName;
      _prefixColor = prefixColor;
    }

    public string Icon
    {
      get => _icon;
      set
      {
        _icon = value;
        IconChanged?.Invoke(this, new FactionEventArgs(this));
      }
    }

    public playercolor PlayerColor
    {
      get => _playerColor;
      set
      {
        _playerColor = value;
        PlayerColorChanged?.Invoke(this, new FactionEventArgs(this));
      }
    }

    public int ControlPointCount
    {
      get => _controlPointCount;
      set
      {
        _controlPointCount = value;
        ControlPointCountChanged?.Invoke(this, new FactionEventArgs(this));
      }
    }

    public int Income
    {
      get => _income;
      set
      {
        _income = value;
        IncomeChanged?.Invoke(this, new FactionEventArgs(this));
      }
    }

    public string ColoredName => _prefixColor + _name + "|r";

    public string Name
    {
      get => _name;
      set
      {
        _name = value;
        NameChanged?.Invoke(this, new FactionEventArgs(this));
      }
    }

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
    public event EventHandler<FactionEventArgs>? NameChanged;
    public event EventHandler<FactionEventArgs>? IconChanged;
    public event EventHandler<FactionEventArgs>? PlayerColorChanged;
    public event EventHandler<FactionEventArgs>? ControlPointCountChanged;
    public event EventHandler<FactionEventArgs>? IncomeChanged;
    public event EventHandler<FactionEventArgs>? PrefixColorChanged;

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
  }
}