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

    private static Quest SetupCrystalGolems()
    {
      var quest = new Quest("Crystalsong Forest", "RockGolem")
      {
        CompletionFlavour = "Dalaran's Earth Golems have been infused with living crystal.",
        Flavour = "The living crystal of the Crystalsong Forest suffers from its proximity to the Legion. Freed from that corruption, it could be used to empower Dalaran's constructs."
      };
      return quest;
    }

    private static Quest SetupClaimDalaran()
    {
      var quest = new Quest("Outskirts", "ArcaneCastle")
      {
        CompletionFlavour = "Dalaran's outskirts are now secure. The city's mages are free to fight once more.",
        Flavour = "The territories of Dalaran are fragmented. Secure the lands and protect Dalaran citizens."
      };
      return quest;
    }

    private static Quest SetupFallenGuardian()
    {
      var quest = new Quest("The Fallen Guardian", "Medivh")
      {
        CompletionFlavour = "Medivh's spirit has been cleansed of Sargeras' influence, allowing him to return to Azeroth for a time.",
        Flavour = "Medivh's body was corrupted by Sargeras at conception. Now that he is dead, the secrets of the Tomb of Sargeras and Sargeras combined might allow the mages of Dalaran to cleanse his spirit."
      };
      return quest;
    }

    private static Quest SetupSoulGem()
    {
      var quest = new Quest("The Soul Gem", "SoulGem")
      {
        CompletionFlavour = "Jaina Proudmoore has discovered the Soul Gem within the ruined vaults at Scholomance.",
        Flavour = "Scholomance is home to a wide variety of profane artifacts. Bring Jaina there to see what might be discovered."
      };
      return quest;
    }

    private static Quest SetupKarazhan()
    {
      var quest = new Quest("Secrets of Karazhan", "TomeBrown")
      {
        CompletionFlavour = "Karazhan has been captured. Dalaran's archivists scour its halls for arcane resources.",
        Flavour = "The spire of Medivh stands mysteriously idle. Dalaran could make use of its grand magicks."
      };
      return quest;
    }

    private static Quest SetupNewGuardian()
    {
      var quest = new Quest("Guardian of Tirisfal", "Astral Blessing")
      {
        CompletionFlavour = "Dalaran has empowered Jaina to be the new Guardian of Tirisfal, endowing her with a portion of the Council of Tirisfal's power.",
        Flavour = "Medivh's death left Azeroth without a Guardian. The spell book he left behind could be used to empower a new one."
      };
      return quest;
    }

    private static Quest SetupShadowfang()
    {
      var quest = new Quest("Shadows of Silverspine Forest", "worgen")
      {
        CompletionFlavour = "Shadowfang has been liberated, and its military is now free to assist Dalaran.",
        Flavour = "The woods of Silverspine are unsafe for travellers. They need to be investigated."
      };
      return quest;
    }

    private static Quest SetupSouthshore()
    {
      var quest = new Quest("Murloc Troubles", "Murloc")
      {
        CompletionFlavour = "The Murlocs have been defeated. Southshore is safe.",
        Flavour = "A small murloc skirmish is attacking Southshore. Push them back."
      };
      return quest;
    }

    private static Quest SetupNexus()
    {
      var quest = new Quest("The Nexus", "BlueDragonNexus")
      {
        CompletionFlavour = "The new Lich King calls for Jaina, tempts her with power. The Nexus needs a master, and Jaina is perfect for it.",
        Flavour = "The Nexus powers have been absorbed by Jaina and she joins the Lich King in the eternal ice of Northrend."
      };
      return quest;
    }

    private static Quest SetupTheramore()
    {
      var quest = new Quest("Theramore", "HumanArcaneTower")
      {
        CompletionFlavour = "A sizeable isle off the coast of Dustwallow Marsh has been colonized and dubbed Theramore, marking the first human settlement to be established on Kalimdor.",
        Flavour = "The distant lands of Kalimdor remain untouched by human civilization. If the Third War proceeds poorly, it may become necessary to establish a forward base there."
      };
      return quest;
    }
    
    public static Faction Setup(player whichPlayer)
    {
      var dalaran = new Faction("Dalaran", PLAYER_COLOR_PINK, "|c00e55bb0", "Jaina");
      FactionSystem.FactionAddQuest(dalaran, SetupBlueDragonflight());
      FactionSystem.FactionAddQuest(dalaran, SetupCrystalGolems());
      FactionSystem.FactionAddQuest(dalaran, SetupClaimDalaran());
      FactionSystem.FactionAddQuest(dalaran, SetupFallenGuardian());
      FactionSystem.FactionAddQuest(dalaran, SetupSoulGem());
      FactionSystem.FactionAddQuest(dalaran, SetupKarazhan());
      FactionSystem.FactionAddQuest(dalaran, SetupNewGuardian());
      FactionSystem.FactionAddQuest(dalaran, SetupShadowfang());
      FactionSystem.FactionAddQuest(dalaran, SetupSouthshore());
      FactionSystem.FactionAddQuest(dalaran, SetupNexus());
      FactionSystem.FactionAddQuest(dalaran, SetupTheramore());
      FactionSystem.Add(dalaran);
      FactionSystem.PlayerSetFaction(whichPlayer, dalaran);
      return dalaran;
    }
  }
}