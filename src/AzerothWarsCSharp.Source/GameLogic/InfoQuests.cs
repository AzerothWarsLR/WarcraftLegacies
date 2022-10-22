using static War3Api.Common;

namespace AzerothWarsCSharp.Source.GameLogic
{
   /// <summary>
   /// Provides a set of dummy quests that provide information to players.
   /// </summary>
   public static class InfoQuests
   {
      public static void Setup()
      {
         var commandQuest = CreateQuest();
         QuestSetTitle(commandQuest, "Commands");
         QuestSetIconPath(commandQuest, @"ReplaceableTextures\CommandButtons\BTNDizzy.blp");
         QuestSetDescription(commandQuest, 
@"General:
-info for useful commands
-obs makes you into an observer
Camera:
-reset sets the camera at default height.
-mid/(-med) sets the camera to a height slightly below default.
-far sets the camera  to a height slightly above default.");

         var discordQuest = CreateQuest();
         QuestSetTitle(discordQuest, "Discord");
         QuestSetIconPath(discordQuest, @"ReplaceableTextures\CommandButtons\BTNDrum.blp");
         QuestSetDescription(discordQuest, "Please visit our Discord at: https://discord.gg/4eGZn");

         var creditsQuest = CreateQuest();
         QuestSetTitle(creditsQuest, "Credits");
         QuestSetIconPath(creditsQuest, @"ReplaceableTextures\CommandButtons\BTNManual3.blp");
         QuestSetDescription(creditsQuest, @"An enormous thank you to...

The Azeroth wars past developers: Augur, Crusader793, Bhaal_Spawn., EagleMan, Avrion, Railen, Thurr, Rhemar, SteakonSpear, Talinn, LuneLune. Dave_Rolf and Richardik.

And the artists who have created the swathe of custom icons and models that we use: Ujimasa Hojo. General Frank, Shiv, Malvodion, nGy, UgoUgo, JetFangInferno, -Grendel,  SpasMaster, Eagle XI, Mythic, Hamsta, assasin_lord, Hayate, R.A.N.G.I.T.,  Stefan.K,  Eusira, 00110000, Pyritie, Sunchips, Dojo, PeeKay, nhocklanhox6, dhguardianes, HappyTauren, HerrDave, Shyster, takakenji, JesusHipster, Boogles, Kwaliti, Tauer, WhiteDeath, and Mechanical Man");
      }
   }
}