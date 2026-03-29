using System.Collections.Generic;
using MacroTools.Factions;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.BlackEmpire.Quests;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.BlackEmpire;

public sealed class BlackEmpireFaction : Faction
{
  /// <inheritdoc />
  public BlackEmpireFaction() : base("Black Empire",
    playercolor.Maroon, @"ReplaceableTextures\CommandButtons\BTNNzothIcon.blp")
  {
    ControlPointDefenderUnitTypeId = UNIT_N0DV_CONTROL_POINT_DEFENDER_NZOTH_TOWER;
    TraditionalTeam = TeamSetup.OldGods;
    StartingGold = new StartingGold
    {
      Instant = 200,
      Income = 120,
      Turns = 10
    };
    IntroText = $"You are playing as the {PrefixCol}Black Empire of N'zoth|r.\n\n" +
                "You start in Nyalotha, restore the city to its glory by repelling the invaders from Azeroth.\n\n" +
                "Then, move onto Kalimdor with your allies. You will quickly run into the Sentinels.\n\n" +
                "Be sure to train Forsaken Ones, they are powerful units.";

    Nicknames = new List<string>
    {
      "be",
      "black empire",
      "blackempire",
      "black",
      "nzoth",
      "n'zoth",
      "nz"
    };
    ProcessObjectInfo(BlackEmpireObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterQuests();
    BlackEmpireSpells.Setup();
    BlackEmpireTraits.Setup();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }

  private void RegisterQuests()
  {
    var questGorma = AddQuest(new QuestTwilightlanding(Regions.BlackEmpireOutpost1));
    StartingQuest = questGorma;

    AddQuest(new QuestWakingCity(questGorma, Regions.Nyalotha));
    AddQuest(new QuestGiftofFlesh());
    AddQuest(new QuestWakingDream(AllLegends.BlackE.Zaqul));
    AddQuest(new QuestMawofShuma(AllLegends.BlackE.Yorsahj));
    AddQuest(new QuestMawofGorath(AllLegends.BlackE.Zonozz));
    AddQuest(new QuestDesolace(Regions.BEDesolaceUnlock));
    AddQuest(new QuestBladeoftheBlackEmpire(Regions.TheAbyss));
    AddQuest(new QuestDestruction(AllLegends.BlackE.Nzoth));
    AddQuest(new QuestWorldStone(AllLegends.BlackE.Nzoth, AllLegends.Frostwolf.Orgrimmar));
    AddQuest(new QuestAscension(AllLegends.BlackE.Nzoth));
    AddQuest(new QuestAlignement(AllLegends.BlackE.Nzoth));
  }
}
