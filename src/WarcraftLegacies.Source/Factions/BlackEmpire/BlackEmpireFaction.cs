using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Localization;
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
      Income = 135,
      Turns = 10
    };
    IntroText = () => Loc.Format(
      "You are playing as the {faction}.\n\nYou start in Nyalotha, restore the city to its glory by repelling the invaders from Azeroth.\n\nThen, move onto Kalimdor with your allies. You will quickly run into the Sentinels.\n\nBe sure to train Forsaken Ones, they are powerful units.",
      ("{faction}", $"{PrefixCol}{Loc.Get("Black Empire of N'zoth")}|r"));

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
    AddQuest(new QuestWakingDream());
    AddQuest(new QuestMawofShuma(AllLegends.BlackE.Yorsahj));
    AddQuest(new QuestMawofGorath(AllLegends.BlackE.Zonozz));
    AddQuest(new QuestDesolace(Regions.BEDesolaceUnlock));
    AddQuest(new QuestBladeoftheBlackEmpire(Regions.TheAbyss));
    AddQuest(new QuestDestruction(AllLegends.BlackE.Nzoth));
    AddQuest(new QuestWorldStone(AllLegends.BlackE.Nzoth, AllLegends.Warsong.Orgrimmar));
    AddQuest(new QuestAscension(AllLegends.BlackE.Nzoth));
    AddQuest(new QuestAlignement(AllLegends.BlackE.Nzoth));
  }
}
