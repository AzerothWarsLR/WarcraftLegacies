using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Utils;
using MacroTools.Wrappers;
using WarcraftLegacies.Source.Objectives;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;
using Environment = MacroTools.Utils.Environment;

namespace WarcraftLegacies.Source.Factions.FelHorde;

/// <summary>
/// Holds Magtheridon in chains outside Hellfire Citadel, bound by Sunfury warlocks, until one of the Fel Horde's
/// heroes channels beside him to free him.
/// </summary>
public sealed class ChainedMagtheridon
{
  private const string ChainsEffect = @"Abilities\Spells\Human\AerialShackles\AerialShacklesTarget.mdl";
  private const float ChainsScale = 2.5f;
  private const string BindingLightning = "LEAS";
  private const float BinderCastPeriod = 1.5f;
  private const string BinderCircleEffect = @"Abilities\Spells\Undead\UndeadMine\UndeadMineCircle.mdl";
  private const int BinderCount = 3;
  private const float BinderDistance = 350;
  private const float BinderHandHeight = 80;
  private const float MagtheridonChestHeight = 150;
  private const float ChainOffsetX = -744;
  private const float ChainOffsetY = 428;
  private const string RuneEffect = @"war3mapImported\Fortitude Rune Aura.mdx";
  private const float RuneDistance = 250;
  private const float RuneHeight = 100;
  private const float RescueRadius = 128;
  private const int RescueDuration = 30;
  private const float CastAnimationPeriod = 1;

  private readonly FelHordeFaction _felHorde;
  private readonly LegendaryHero _magtheridon;
  private readonly Point _chainPoint;
  private readonly Point _runePoint;
  private readonly TriggerWrapper _entersRescueArea = new();
  private readonly List<unit> _binders = new();
  private readonly List<lightning> _bindings = new();
  private readonly List<effect> _binderCircles = new();
  private timer? _binderCastTimer;
  private effect? _chains;
  private effect? _rune;
  private Channel? _channel;

  /// <summary>Whether Magtheridon is in chains right now.</summary>
  public bool IsChained { get; private set; }

  public ChainedMagtheridon(FelHordeFaction felHorde, LegendaryHero magtheridon, Point hellfireCitadel)
  {
    _felHorde = felHorde;
    _magtheridon = magtheridon;
    _chainPoint = new Point(hellfireCitadel.X + ChainOffsetX, hellfireCitadel.Y + ChainOffsetY);
    _runePoint = new Point(_chainPoint.X, _chainPoint.Y - RuneDistance);
    var rescueArea = rect.Create(_runePoint.X - RescueRadius, _runePoint.Y - RescueRadius,
      _runePoint.X + RescueRadius, _runePoint.Y + RescueRadius);
    _entersRescueArea.Trigger.RegisterEnterRegion(GeneralHelpers.RectToRegion(rescueArea));
    _entersRescueArea.Trigger.AddAction(OnEntersRescueArea);
  }

  /// <summary>Puts Magtheridon in chains outside Hellfire Citadel, bringing him back if he has fallen.</summary>
  public void Chain()
  {
    var owner = _felHorde.Player;
    if (IsChained || owner == null)
    {
      return;
    }

    _magtheridon.ClearUnitDependencies();
    _magtheridon.ForceCreate(owner, _chainPoint, 270);
    var magtheridonUnit = _magtheridon.Unit;
    if (magtheridonUnit == null)
    {
      return;
    }

    IsChained = true;
    magtheridonUnit.SetPausedEx(true);
    magtheridonUnit.IsInvulnerable = true;
    _chains = effect.Create(ChainsEffect, magtheridonUnit.X, magtheridonUnit.Y);
    _chains.Scale = ChainsScale;
    CreateBinders(magtheridonUnit);
    var runePath = player.LocalPlayer == owner ? RuneEffect : "";
    _rune = effect.Create(runePath, _runePoint.X, _runePoint.Y);
    _rune.SetColor(owner);
    _rune.SetHeight(RuneHeight + Environment.GetPositionZ(_runePoint));

    owner.DisplayTextTo(Loc.Get(
      "Illidan's warlocks have bound Magtheridon in fel chains before the gates of Hellfire Citadel. Send one of your champions to his side to break the binding."));
    owner.PingMinimapSimple(_chainPoint.X, _chainPoint.Y, 5);
  }

  private void CreateBinders(unit magtheridonUnit)
  {
    var magtheridonZ = Environment.GetPositionZ(_chainPoint) + MagtheridonChestHeight;
    for (var i = 0; i < BinderCount; i++)
    {
      var angle = 90 + i * 360f / BinderCount;
      var position = new Point(MathEx.GetPolarOffsetX(_chainPoint.X, BinderDistance, angle),
        MathEx.GetPolarOffsetY(_chainPoint.Y, BinderDistance, angle));
      _binderCircles.Add(effect.Create(BinderCircleEffect, position.X, position.Y));
      var binder = unit.Create(player.NeutralPassive, UNIT_N0E3_WARLOCK_SUNFURY, position.X, position.Y, angle + 180);
      binder.SetPausedEx(true);
      binder.IsInvulnerable = true;
      binder.SetAnimation("spell channel");
      _binders.Add(binder);

      var binderZ = Environment.GetPositionZ(position) + BinderHandHeight;
      _bindings.Add(AddLightningEx(BindingLightning, false, position.X, position.Y, binderZ, magtheridonUnit.X,
        magtheridonUnit.Y, magtheridonZ));
    }

    _binderCastTimer = timer.Create();
    _binderCastTimer.Start(BinderCastPeriod, true, () =>
    {
      foreach (var binder in _binders)
      {
        binder.SetAnimation("spell channel");
      }
    });
  }

  private void RemoveBinders()
  {
    if (_binderCastTimer != null)
    {
      _binderCastTimer.Dispose();
      _binderCastTimer = null;
    }

    foreach (var binding in _bindings)
    {
      DestroyLightning(binding);
    }

    foreach (var binder in _binders)
    {
      binder.SetPausedEx(false);
      binder.IsInvulnerable = false;
      binder.Kill();
    }

    foreach (var circle in _binderCircles)
    {
      circle.Dispose();
    }

    _bindings.Clear();
    _binderCircles.Clear();
    _binders.Clear();
  }

  private void OnEntersRescueArea()
  {
    var hero = @event.EnteringUnit;
    var magtheridonUnit = _magtheridon.Unit;
    if (!IsChained || _channel != null || magtheridonUnit == null || hero == magtheridonUnit ||
        hero.Owner != _felHorde.Player || !hero.IsUnitType(unittype.Hero) || !hero.Alive)
    {
      return;
    }

    var facing = MathEx.GetAngleBetweenPoints(_runePoint.X, _runePoint.Y, magtheridonUnit.X, magtheridonUnit.Y);
    _channel = new Channel(hero, RescueDuration, facing, _runePoint);
    _channel.Finished += OnChannelFinished;
    KeepCasting(hero);
  }

  /// <summary>Replays the hero's casting animation for the whole channel, since most heroes have no looping one.</summary>
  private void KeepCasting(unit hero)
  {
    var channel = _channel;
    hero.SetAnimation("spell channel");
    timer.Create().Start(CastAnimationPeriod, true, () =>
    {
      if (_channel != channel || !hero.Alive)
      {
        @event.ExpiredTimer.Dispose();
        return;
      }

      hero.SetAnimation("spell channel");
    });
  }

  private void OnChannelFinished(Channel channel)
  {
    channel.Finished -= OnChannelFinished;
    channel.Dispose();
    _channel = null;
    if (channel.FinishedWithoutInterruption)
    {
      Free();
    }
  }

  private void Free()
  {
    var magtheridonUnit = _magtheridon.Unit;
    if (magtheridonUnit == null)
    {
      return;
    }

    IsChained = false;
    if (_chains != null)
    {
      _chains.Dispose();
      _chains = null;
    }

    RemoveBinders();
    if (_rune != null)
    {
      _rune.Dispose();
      _rune = null;
    }

    magtheridonUnit.SetPausedEx(false);
    magtheridonUnit.IsInvulnerable = false;
    var blackTemple = AllLegends.FelHorde.BlackTemple.Unit;
    if (blackTemple != null)
    {
      _magtheridon.AddUnitDependency(blackTemple);
    }

    var message = Loc.Format(
      "{felHorde} has torn through the warlocks' binding. Magtheridon walks free, though the Fel Horde still answers to Illidan.",
      ("{felHorde}", _felHorde.ColoredName));
    foreach (var whichPlayer in WCSharp.Shared.Util.EnumeratePlayers())
    {
      whichPlayer.DisplayTextTo(message);
    }
  }
}
