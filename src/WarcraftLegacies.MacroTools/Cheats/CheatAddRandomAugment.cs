using System;
using WarcraftLegacies.MacroTools.Augments;
using WarcraftLegacies.MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.MacroTools.Cheats
{
   /// <summary>
   /// Gives the cheater a random <see cref="Augment"/>.
   /// </summary>
   public static class CheatAddRandomAugment
   {
      private const string Command = "-addrandomaugment";

      private static void Actions()
      {
         try
         {
            if (!TestSafety.CheatCondition()) return;
            GetTriggerPlayer().GetFaction()?.AddAugment(AugmentSystem.GetRandom(GetTriggerPlayer()));
            DisplayTextToPlayer(GetTriggerPlayer(), 0, 0, "|cffD27575CHEAT:|r Attempted to add random augment.");
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex);
         }
      }

      public static void Setup()
      {
         var trig = CreateTrigger();
         foreach (var player in WCSharp.Shared.Util.EnumeratePlayers()) TriggerRegisterPlayerChatEvent(trig, player, Command, false);
         TriggerAddAction(trig, Actions);
      }
   }
}