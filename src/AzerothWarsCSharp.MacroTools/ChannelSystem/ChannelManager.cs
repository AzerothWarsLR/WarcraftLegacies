using System.Collections.Generic;
using WCSharp.Events;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.ChannelSystem
{
  public static class ChannelManager
  {
    static ChannelManager()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeDies, OnDeath);
      PeriodicEvents.AddPeriodicEvent(Action);
    }

    private static readonly List<Channel> Channels = new();
    private static readonly Dictionary<unit, List<Channel>> ChannelsByUnit = new();

    private static int _index;
    private static int _size;

    private static bool Action()
    {
      _size = Channels.Count;
      _index = 0;

      while (_index < _size)
      {
        var channel = Channels[_index];
        if (channel.Active) channel.Action();

        if (channel.Active)
        {
          _index++;
        }
        else
        {
          _size--;
          Channels[_index] = Channels[_size];
          Channels.RemoveAt(_size);
          channel.Dispose();
        }
      }

      return true;
    }

    private static void OnDeath()
    {
      var unit = GetTriggerUnit();
      if (_index < _size)
      {
        var channel = Channels[_index];
        if (channel.Active && channel.Caster == unit)
        {
          channel.OnDeath(true);
          channel.Active = false;
        }
      }

      if (ChannelsByUnit.TryGetValue(unit, out var channelsOnUnit))
        foreach (var channel in channelsOnUnit)
          if (channel.Active)
          {
            channel.OnDeath(false);
            channel.Active = false;
          }
    }

    public static void Add(Channel channel)
    {
      if (ChannelsByUnit.TryGetValue(channel.Caster, out var buffsOnUnit))
        buffsOnUnit.Add(channel);
      else
        ChannelsByUnit.Add(channel.Caster, new List<Channel>
        {
          channel
        });

      Channels.Add(channel);
      channel.Active = true;
      channel.Apply();
      PlayerUnitEvents.Register(PlayerUnitEvent.SpellEndCast, channel.OnStop, channel.SpellId);
    }

    internal static void Remove(Channel channel)
    {
      if (ChannelsByUnit.TryGetValue(channel.Caster, out var channelsOnUnit))
      {
        if (channelsOnUnit.Count == 1)
          ChannelsByUnit.Remove(channel.Caster);
        else
          channelsOnUnit.Remove(channel);
        PlayerUnitEvents.Unregister(PlayerUnitEvent.SpellEndCast, channel.OnStop);
      }
    }
  }
}