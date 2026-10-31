using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.GameTime;
using MacroTools.Localization;
using MacroTools.PreplacedWidgets;
using WCSharp.Events;
using WCSharp.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.GameLogic.ThandolSpan;

/// <summary>
/// The Thandol Span starts collapsed with a crew repairing it, and rises again on a set turn. Foremen at either end
/// sell a payment that makes the repairs finish sooner.
/// </summary>
public static class ThandolSpanBridge
{
  /// <summary>The turn the repairs finish on if nobody pays to speed them up.</summary>
  public const int DefaultFinishTurn = 30;

  /// <summary>How many turns sooner each payment makes the repairs finish.</summary>
  public const int TurnsSavedPerPayment = 5;

  /// <summary>The earliest turn the repairs can finish on, however much is paid.</summary>
  public const int EarliestFinishTurn = 8;

  private const int SpeedUpCost = 300;

  private const int SpeedUpItemId = ITEM_I02A_PAY_THE_REPAIR_CREW;
  private const string QuestMarkerPath = @"Abilities\Spells\Other\TalkToMe\TalkToMe";
  private const float CountdownTextHeight = 150;

  private const int South = 0;
  private const int North = 1;
  private const float BridgeMiddleY = 185;

  private static readonly int[] _foremanTypes = { UNIT_N0Z6_THANDOL_FOREMAN, UNIT_N0Z5_THANDOL_FOREMAN };
  private static readonly int[] _workerTypes =
  {
    UNIT_H019_MASON_IRONFORGE_WORKER, UNIT_HPEA_PEASANT_LORDAERON_STORMWIND_WORKER
  };
  private static readonly Point[] _foremanSpots = { new(16165, -590), new(16110, 895) };
  private static readonly float[] _foremanFacings = { 240, 120 };
  private static readonly float[] _workerFacings = { 90, 270 };
  private static readonly Point[][] _startingWorkerSpots =
  {
    new[] { new Point(15535, -286), new Point(15923, -386) },
    new[] { new Point(15889, 695), new Point(15579, 717) }
  };
  private static readonly Point[][] _hiredWorkerSpots =
  {
    new[]
    {
      new Point(15660, -420), new Point(15800, -430), new Point(15580, -480), new Point(15880, -500),
      new Point(15730, -530)
    },
    new[]
    {
      new Point(15660, 770), new Point(15800, 780), new Point(15600, 830), new Point(15860, 840),
      new Point(15730, 870)
    }
  };
  private static readonly int[] _hiredWorkerCounts = { 0, 0 };
  private static readonly Point _countdownTextSpot = new(15580, 85);

  private static readonly int _rockChunkId = FourCC("LTrc");
  private static readonly List<unit> _foremen = new();
  private static readonly List<effect> _questMarkers = new();
  private static readonly List<unit> _workers = new();
  private static destructable? _bridge;
  private static texttag? _countdownText;
  private static readonly List<string> _payers = new();
  private static int _finishTurn = DefaultFinishTurn;

  /// <summary>Whether the bridge has been restored.</summary>
  public static bool IsRestored { get; private set; }

  /// <summary>Whether the bridge announces its restoration in chat. Turned off when something else announces it.</summary>
  public static bool AnnouncesRestoration { get; set; } = true;

  /// <summary>The coloured names of the factions that paid to speed up the repairs, in the order they first paid.</summary>
  public static IReadOnlyList<string> Payers => _payers;

  /// <summary>What restored the bridge early without the crew finishing, if anything.</summary>
  public static string? RestoredBy { get; private set; }

  /// <summary>The turn the bridge was restored on.</summary>
  public static int RestoredOnTurn { get; private set; }

  /// <summary>Fires once the bridge has been restored.</summary>
  public static event Action? Restored;

  /// <summary>Collapses the bridge, clears its old rocks, and sets the foremen and their crew to work.</summary>
  public static void Setup()
  {
    _bridge = AllPreplacedWidgets.Destructables.GetClosest(FourCC("LT08"), 15695, 457);
    _bridge.IsInvulnerable = false;
    _bridge.Kill();

    Regions.BridgeAmbient.Rect.EnumerateDestructables(null, () =>
    {
      var rock = GetEnumDestructable();
      if (rock.Type == _rockChunkId)
      {
        rock.Dispose();
      }
    });

    for (var i = 0; i < _foremanSpots.Length; i++)
    {
      var spot = _foremanSpots[i];
      var foreman = unit.Create(player.NeutralPassive, _foremanTypes[i], spot.X, spot.Y, _foremanFacings[i]);
      _foremen.Add(foreman);
      _questMarkers.Add(AddSpecialEffectTarget(QuestMarkerPath, foreman, "overhead"));
    }

    for (var side = South; side <= North; side++)
    {
      foreach (var spot in _startingWorkerSpots[side])
      {
        AddWorker(side, spot);
      }
    }

    _countdownText = CreateTextTag();
    SetTextTagPos(_countdownText, _countdownTextSpot.X, _countdownTextSpot.Y, CountdownTextHeight);
    SetTextTagPermanent(_countdownText, true);
    SetTextTagVisibility(_countdownText, true);
    RefreshCountdownText();

    PlayerUnitEvents.Register(ItemTypeEvent.IsPickedUp, OnSpeedUpBought, SpeedUpItemId);
    GameTimeManager.RegisterOnTurnRepeating(1, OnTurn);
  }

  /// <summary>Finishes the repairs straight away, unless the bridge is already restored.</summary>
  /// <param name="cause">What restored the bridge, such as "the Grand Alliance formed".</param>
  public static void RestoreNow(string cause)
  {
    if (IsRestored)
    {
      return;
    }

    RestoredBy = cause;
    Restore();
  }

  private static void OnTurn()
  {
    if (!IsRestored && GameTimeManager.Turn >= _finishTurn)
    {
      Restore();
    }
  }

  private static void OnSpeedUpBought()
  {
    if (IsRestored)
    {
      return;
    }

    var buyer = @event.Unit.Owner;
    if (_finishTurn <= EarliestFinishTurn)
    {
      buyer.Gold += SpeedUpCost;
      return;
    }

    var buyerFaction = buyer.GetPlayerData().Faction;
    if (buyerFaction != null && !_payers.Contains(buyerFaction.ColoredName))
    {
      _payers.Add(buyerFaction.ColoredName);
    }

    _finishTurn = Math.Max(EarliestFinishTurn, _finishTurn - TurnsSavedPerPayment);
    var side = @event.Unit.Y < BridgeMiddleY ? South : North;
    HireWorker(side);
    if (_finishTurn == EarliestFinishTurn)
    {
      foreach (var foreman in _foremen)
      {
        RemoveItemFromStock(foreman, SpeedUpItemId);
      }
    }

    if (GameTimeManager.Turn >= _finishTurn)
    {
      Restore();
      return;
    }

    RefreshCountdownText();
  }

  private static void HireWorker(int side)
  {
    var spots = _hiredWorkerSpots[side];
    AddWorker(side, spots[_hiredWorkerCounts[side] % spots.Length]);
    _hiredWorkerCounts[side]++;
  }

  private static void AddWorker(int side, Point spot)
  {
    var worker = unit.Create(player.NeutralPassive, _workerTypes[side], spot.X, spot.Y, _workerFacings[side]);
    worker.IsInvulnerable = true;
    worker.SetPathing(false);
    worker.X = spot.X;
    worker.Y = spot.Y;
    worker.SetAnimation("stand work");
    _workers.Add(worker);
  }

  private static void RefreshCountdownText()
  {
    if (_countdownText == null)
    {
      return;
    }

    SetTextTagText(_countdownText,
      Loc.Format("Repairs finish on turn {turn}", ("{turn}", _finishTurn.ToString())), 0.023f);
  }

  private static void Restore()
  {
    IsRestored = true;
    RestoredOnTurn = GameTimeManager.Turn;
    foreach (var worker in _workers)
    {
      worker.Dispose();
    }

    _workers.Clear();
    foreach (var marker in _questMarkers)
    {
      marker.Dispose();
    }

    _questMarkers.Clear();
    foreach (var foreman in _foremen)
    {
      foreman.Dispose();
    }

    _foremen.Clear();
    if (_countdownText != null)
    {
      DestroyTextTag(_countdownText);
      _countdownText = null;
    }

    if (_bridge != null)
    {
      DestructableRestoreLife(_bridge, GetDestructableMaxLife(_bridge), true);
      _bridge.IsInvulnerable = true;
    }

    if (AnnouncesRestoration)
    {
      foreach (var whichPlayer in Util.EnumeratePlayers())
      {
        whichPlayer.DisplayTextTo(Loc.Get(
          "The Thandol Span has been restored. Armies can cross between Arathi and the Wetlands once more."));
      }
    }

    Restored?.Invoke();
  }
}
