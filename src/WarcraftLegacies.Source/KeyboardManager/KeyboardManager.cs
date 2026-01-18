using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using WCSharp.Api.Enums;

namespace WarcraftLegacies.Source.KeyboardManager;

public class KeyboardManager
{
  private readonly Dictionary<player, Action<oskeytype, MetaKey, bool>> _keyHandlers;
  private readonly trigger _keyTrigger;

  public KeyboardManager()
  {
    _keyHandlers = new Dictionary<player, Action<oskeytype, MetaKey, bool>>();
    _keyTrigger = trigger.Create();
    _keyTrigger.AddAction(OnKeyEvent);
  }

  public void RegisterKeyboardEvents(player whichPlayer, Action<oskeytype, MetaKey, bool> handler)
  {
    if (whichPlayer == null)
    {
      throw new ArgumentNullException(nameof(whichPlayer));
    }

    if (handler == null)
    {
      throw new ArgumentNullException(nameof(handler));
    }

    for (var keyCode = 8; keyCode <= 255; keyCode++)
    {
      var osKey = oskeytype.Convert(keyCode);
      _keyTrigger.RegisterPlayerKeyEvent(whichPlayer, osKey, 0, true);
      _keyTrigger.RegisterPlayerKeyEvent(whichPlayer, osKey, 0, false);
    }

    _keyHandlers[whichPlayer] = handler;
  }

  private void OnKeyEvent()
  {
    try
    {
      var triggerPlayer = @event.Player;
      if (_keyHandlers.TryGetValue(triggerPlayer, out var handler))
      {
        var key = @event.PlayerKey;
        var metaKey = @event.PlayerMetaKey;
        var isKeyDown = @event.PlayerIsKeyDown;

        handler(key, metaKey, isKeyDown);
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error in keyboard event handler: {ex}");
    }
  }

  public static string GetMetaKeyString(int metaKey)
  {
    var parts = new List<string>();

    if ((metaKey & 1) != 0)
    {
      parts.Add("SHIFT");
    }

    if ((metaKey & 2) != 0)
    {
      parts.Add("CTRL");
    }

    if ((metaKey & 4) != 0)
    {
      parts.Add("ALT");
    }

    if ((metaKey & 8) != 0)
    {
      parts.Add("META");
    }

    return parts.Count > 0 ? string.Join("+", parts) : "NONE";
  }
}

public class HeroHotkeyManager
{
  private readonly KeyboardManager _keyboardManager;

  public HeroHotkeyManager()
  {
    _keyboardManager = new KeyboardManager();
  }

  public void Initialize(player whichPlayer)
  {
    _keyboardManager.RegisterKeyboardEvents(whichPlayer, OnKeyEvent);
  }

  private void OnKeyEvent(oskeytype key, MetaKey metaKey, bool isKeyDown)
  {
    if (isKeyDown && key == oskeytype.F4)
    {
      SelectFourthHero(@event.Player);
    }
  }

  private static void SelectFourthHero(player whichPlayer)
  {
    var heroGroup = group.Create();
    heroGroup.EnumUnitsOfPlayer(whichPlayer);

    var heroCount = 0;
    unit fourthHero = null;

    var firstOfGroup = heroGroup.First;
    while (firstOfGroup != null)
    {
      if (firstOfGroup.IsUnitType(unittype.Hero))
      {
        heroCount++;
        if (heroCount == 4)
        {
          fourthHero = firstOfGroup;
          break;
        }
      }
      heroGroup.Remove(firstOfGroup);
      firstOfGroup = heroGroup.First;
    }

    heroGroup.Dispose();

    if (fourthHero != null)
    {
      var wasAlreadySelected = fourthHero.IsSelectedTo(whichPlayer);

      if (wasAlreadySelected)
      {
        whichPlayer.RepositionCamera(fourthHero.X, fourthHero.Y);
      }
      else
      {
        var selectedGroup = group.Create();
        selectedGroup.EnumUnitsSelected(whichPlayer);

        firstOfGroup = selectedGroup.First;
        while (firstOfGroup != null)
        {
          if (firstOfGroup.IsSelectedTo(whichPlayer))
          {
            firstOfGroup.Select(false);
          }
          selectedGroup.Remove(firstOfGroup);
          firstOfGroup = selectedGroup.First;
        }
        selectedGroup.Dispose();
        if (whichPlayer == player.LocalPlayer)
        {
          fourthHero.Select();
        }
      }
    }
  }
}
