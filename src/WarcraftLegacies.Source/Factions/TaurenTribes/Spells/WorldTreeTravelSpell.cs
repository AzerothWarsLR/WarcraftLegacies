using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Legends;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Spells;

public sealed class WorldTreeTravelSpell : Spell
{
  private readonly Dictionary<unit, timer> _channels = new();
  private readonly Dictionary<unit, effect> _channelEffects = new();
  private readonly HashSet<unit> _completedChannels = new();

  public required Capital Destination { get; init; }

  public required float ChannelDuration { get; init; }

  public required float Radius { get; init; }

  public required int MaximumUnits { get; init; }

  public required string ChannelEffect { get; init; }

  public required string ArrivalEffect { get; init; }

  public required Func<unit, bool> TryBeginChannel { get; init; }

  public required Action<unit> EndChannel { get; init; }

  public required Action OnTravelled { get; init; }

  public WorldTreeTravelSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var destination = Destination.Unit;
    if (destination == null || !destination.Alive || destination.Owner != caster.Owner || destination == caster)
    {
      DisplayTextToPlayer(caster.Owner, 0, 0, "You must own the destination World Tree to travel there.");
      IssueImmediateOrder(caster, "stop");
      return;
    }

    if (!TryBeginChannel(caster))
    {
      DisplayTextToPlayer(caster.Owner, 0, 0, "Another World Tree is already sending travellers through the roots.");
      IssueImmediateOrder(caster, "stop");
      return;
    }

    var channel = timer.Create();
    _completedChannels.Remove(caster);
    channel.Start(ChannelDuration - 0.1f, false, () => _completedChannels.Add(caster));
    _channels[caster] = channel;
    _channelEffects[caster] = effect.Create(ChannelEffect, caster, "origin");
  }

  public override void OnStop(unit caster)
  {
    if (!_channels.TryGetValue(caster, out var channel))
    {
      return;
    }

    _channels.Remove(caster);
    channel.Dispose();
    if (_channelEffects.TryGetValue(caster, out var channelEffect))
    {
      _channelEffects.Remove(caster);
      channelEffect.Dispose();
    }

    EndChannel(caster);
    var finished = _completedChannels.Remove(caster);
    if (finished)
    {
      Travel(caster);
    }
  }

  private void Travel(unit source)
  {
    var destination = Destination.Unit;
    if (destination == null || !destination.Alive || destination.Owner != source.Owner)
    {
      return;
    }

    var travellers = GlobalGroup.EnumUnitsInRange(source.X, source.Y, Radius)
      .Where(x => x.Owner == source.Owner && x.Alive && !x.IsUnitType(unittype.Structure))
      .OrderBy(x => MathEx.GetDistanceBetween(source.X, source.Y, x))
      .Take(MaximumUnits)
      .ToList();

    foreach (var traveller in travellers)
    {
      traveller.SetPosition(destination.X + traveller.X - source.X, destination.Y + traveller.Y - source.Y);
    }

    effect.Create(ArrivalEffect, destination.X, destination.Y).Dispose();
    OnTravelled();
  }
}
