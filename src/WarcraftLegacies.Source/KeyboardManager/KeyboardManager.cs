using System;
using System.Collections.Generic;


namespace WarcraftLegacies.Source.KeyboardManager
{
    public class KeyboardManager
    {
        private readonly Dictionary<player, Action<oskeytype, int, bool>> _keyHandlers;
        private readonly trigger _keyTrigger;

        public KeyboardManager()
        {
            _keyHandlers = new Dictionary<player, Action<oskeytype, int, bool>>();
            _keyTrigger = CreateTrigger();
            TriggerAddAction(_keyTrigger, OnKeyEvent);
        }

        public void RegisterKeyboardEvents(player whichPlayer, Action<oskeytype, int, bool> handler)
        {
            if (whichPlayer == null) throw new ArgumentNullException(nameof(whichPlayer));
            if (handler == null) throw new ArgumentNullException(nameof(handler));
            
            for (int keyCode = 8; keyCode <= 255; keyCode++)
            {
                var osKey = ConvertOsKeyType(keyCode);
                BlzTriggerRegisterPlayerKeyEvent(_keyTrigger, whichPlayer, osKey, 0, true);
                BlzTriggerRegisterPlayerKeyEvent(_keyTrigger, whichPlayer, osKey, 0, false);
            }

            _keyHandlers[whichPlayer] = handler;
        }

        private void OnKeyEvent()
        {
            try
            {
                var triggerPlayer = GetTriggerPlayer();
                if (_keyHandlers.TryGetValue(triggerPlayer, out var handler))
                {
                    var key = BlzGetTriggerPlayerKey();
                    var metaKey = BlzGetTriggerPlayerMetaKey();
                    var isKeyDown = BlzGetTriggerPlayerIsKeyDown();

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
            
            if ((metaKey & 1) != 0) parts.Add("SHIFT");
            if ((metaKey & 2) != 0) parts.Add("CTRL");
            if ((metaKey & 4) != 0) parts.Add("ALT");
            if ((metaKey & 8) != 0) parts.Add("META");
            
            return parts.Count > 0 ? string.Join("+", parts) : "NONE";
        }
    }

    public class KeyboardDebugger
    {
        private readonly KeyboardManager _keyboardManager;

        public KeyboardDebugger()
        {
            _keyboardManager = new KeyboardManager();
        }

        public void Initialize(player whichPlayer)
        {
            _keyboardManager.RegisterKeyboardEvents(whichPlayer, OnKeyEvent);
        }

        private void OnKeyEvent(oskeytype key, int metaKey, bool isKeyDown)
        {
            string action = isKeyDown ? "pressed" : "released";
            string modifiers = KeyboardManager.GetMetaKeyString(metaKey);
            
            DisplayTextToPlayer(GetTriggerPlayer(), 0, 0, 
                $"Debug: Key detected - Code: {key.ToString()}, Action: {action}, Modifiers: {modifiers}");
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

        private void OnKeyEvent(oskeytype key, int metaKey, bool isKeyDown)
        {
          if (isKeyDown)
          {
            if (key == OSKEY_F4)
            {
              DisplayTextToPlayer(GetTriggerPlayer(), 0, 0, "R key detected. Attempting hero selection...");
              SelectFourthHero(GetTriggerPlayer());
            }
          }
        }
        
        private void SelectFourthHero(player whichPlayer)
        {
            group heroGroup = CreateGroup();
            GroupEnumUnitsOfPlayer(heroGroup, whichPlayer, null);
            
            int heroCount = 0;
            unit fourthHero = null;

            unit firstOfGroup = FirstOfGroup(heroGroup);
            while (firstOfGroup != null)
            {
                if (IsUnitType(firstOfGroup, UNIT_TYPE_HERO))
                {
                    heroCount++;
                    if (heroCount == 4)
                    {
                        fourthHero = firstOfGroup;
                        break;
                    }
                }
                GroupRemoveUnit(heroGroup, firstOfGroup);
                firstOfGroup = FirstOfGroup(heroGroup);
            }

            DestroyGroup(heroGroup);

            if (fourthHero != null)
            {
                group selectedGroup = CreateGroup();
                GroupEnumUnitsSelected(selectedGroup, whichPlayer, null);
                
                firstOfGroup = FirstOfGroup(selectedGroup);
                while (firstOfGroup != null)
                {
                    if (IsUnitSelected(firstOfGroup, whichPlayer))
                    {
                        SelectUnit(firstOfGroup, false);
                    }
                    GroupRemoveUnit(selectedGroup, firstOfGroup);
                    firstOfGroup = FirstOfGroup(selectedGroup);
                }
                DestroyGroup(selectedGroup);
                SelectUnit(fourthHero, true);
                DisplayTextToPlayer(whichPlayer, 0, 0, "Fourth hero selected.");
            }
            else
            {
                DisplayTextToPlayer(whichPlayer, 0, 0, "No fourth hero found.");
            }
        }
    }
}