using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.QuestOutcomes;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class DalaranSetup
  {
    private static Quest SetupBlueDragonflight()
    {
      var questBlueDragons = new Quest("The Blue Dragonflight", "AzureDragon")
      {
        CompletionFlavour = "The Nexus has been captured. The Blue Dragonflight fights for Dalaran.",
        Flavour = "The Blue Dragons of Northrend are the wardens of magic on Azeroth. They might be convinced to willingly join the mages of Dalaran."
      };
      questBlueDragons.AddOutcome(new QuestOutcomeUnlockUnitType(FourCC("n0AC"), new[]{FourCC("hbar")}, FourCC("R00U")));
      return questBlueDragons;
    }
    
    public static Faction Setup(player whichPlayer)
    {
      var dalaran = new Faction("Dalaran", PLAYER_COLOR_PINK, "|c00e55bb0", "Jaina");
      FactionSystem.FactionAddQuest(dalaran, SetupBlueDragonflight());
      FactionSystem.Add(dalaran);
      FactionSystem.PlayerSetFaction(whichPlayer, dalaran);
      return dalaran;
    }
  }
}