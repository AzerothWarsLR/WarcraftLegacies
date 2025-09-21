namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
/// Provides a set of dummy quests that provide information to players.
/// </summary>
public static class InfoQuests
{
  /// <summary>
  /// Creates a series of dummy quests that provide information to players.
  /// </summary>
  public static void Setup()
  {
    var creditsAndDiscordQuest = quest.Create();
    creditsAndDiscordQuest.SetTitle("Discord & Credits");
    creditsAndDiscordQuest.SetIcon(@"ReplaceableTextures\CommandButtons\BTNManual3.blp");
    creditsAndDiscordQuest.SetDescription(@"Please visit our Discord at: https://discord.gg/4eGZn

An enormous thank you to...

Previous Azeroth Wars developers: Augur, Crusader793, Bhaal_Spawn., EagleMan, Avrion, Railen, Thurr, Rhemar, SteakonSpear, Talinn, LuneLune, Dave_Rolf and Richardik,
And to our code contributors, Naowsx, Savantic, Headhunter and Tracy,
and to the artists who have created the swathe of custom icons and models that we use: Ujimasa Hojo, General Frank, Shiv, Malvodion, nGy, UgoUgo, JetFangInferno, -Grendel,  SpasMaster, Eagle XI, Mythic, Hamsta, assasin_lord, Hayate, R.A.N.G.I.T.,  Stefan.K,  Eusira, 00110000, Pyritie, Sunchips, Dojo, PeeKay, nhocklanhox6, dhguardianes, HappyTauren, HerrDave, Shyster, takakenji, JesusHipster, Boogles, Kwaliti, Tauer, WhiteDeath, and Mechanical Man");
    creditsAndDiscordQuest.IsRequired = false;
  }
}
