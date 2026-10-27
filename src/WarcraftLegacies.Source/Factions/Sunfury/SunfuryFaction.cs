using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.PreplacedWidgets;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.BloodElves.Quests;
using WarcraftLegacies.Source.Factions.Quelthalas;
using WarcraftLegacies.Source.Factions.Quelthalas.Quests;
using WarcraftLegacies.Source.Factions.Sunfury.Quests;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Shared.Quests;

namespace WarcraftLegacies.Source.Factions.Sunfury;

public sealed class SunfuryFaction : Faction
{
  /// <inheritdoc />
  public SunfuryFaction() : this(playercolor.Violet)
  {
  }

  /// <summary>Creates the Sunfury with a specific player colour.</summary>
  public SunfuryFaction(playercolor playerColor)
    : base("Sunfury", playerColor, @"ReplaceableTextures\CommandButtons\BTNBloodMage2.blp")
  {
    TraditionalTeam = TeamSetup.Outland;
    StartingGold = new StartingGold
    {
      Instant = 200,
      Income = 225,
      Turns = 10
    };
    CinematicMusic = "BloodElfTheme";
    FoodMaximum = 250;
    ControlPointDefenderUnitTypeId = UNIT_N0BC_CONTROL_POINT_DEFENDER_QUELTHALAS;
    IntroText = RoleplaySetting.IsActive
      ? () => Loc.Format(
        "You are now playing as the {faction}.\n\nThe Sunwell has fallen, and its loss gnaws at every elf of Quel'thalas. Prince Kael'thas has sworn his people to Kil'jaeden the Deceiver and led them through the Dark Portal to Tempest Keep, leaving the homeland to the Alliance.\n\nClaim the power of Netherstorm and slay the naaru M'uru. With its heart, Kael'thas can return to the Sunwell and open the way for his new master.",
        ("{faction}", $"{PrefixCol}{Loc.Get("Sunfury")}|r"))
      : () => Loc.Format(
        "You are playing as the power-hungry {faction}.\n\nYou begin in Netherstorm. Your first mission is to build three biodomes in the green areas protected by a bubble.\n\nUnite with your fel ally to push through the Dark Portal and destroy Stormwind.\n\nYour ultimate goal is to summon Kil'jaeden and annihilate your enemies.",
        ("{faction}", $"{PrefixCol}{Loc.Get("Sunfury")}|r"));
    Nicknames = new List<string>
    {
      "sf",
      "sun"
    };
    ProcessObjectInfo(SunfuryObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterQuests();
    SunfurySpells.Setup();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }

  /// <inheritdoc />
  public override void OnNotPicked()
  {
    var well = AllPreplacedWidgets.Units.Get(UNIT_N0DZ_THE_WELL_OF_ETERNITY_SUNFURY_OTHER);
    if (RoleplaySetting.IsActive)
    {
      SunfuryRelocation.HideOutposts();
      well.IsVisible = false;
    }
    else
    {
      well.Dispose();
    }

    Regions.Area52Unlock.CleanupNeutralPassiveUnits();
    Regions.Netherstorm.CleanupNeutralPassiveUnits();
    Regions.UpperNetherstorm.CleanupNeutralPassiveUnits();
    Regions.TempestKeep.CleanupNeutralPassiveUnits();
    Regions.SunfuryStartingPosition.CleanupNeutralPassiveUnits();
    base.OnNotPicked();
  }

  private void RegisterQuests()
  {
    if (RoleplaySetting.IsActive)
    {
      RegisterRoleplayQuests();
      return;
    }

    var newQuest =
      AddQuest(new QuestTempestKeep(Regions.TempestKeep, Regions.Biodome1, Regions.Biodome2, Regions.Biodome3));
    StartingQuest = newQuest;

    AddQuest(new QuestArea52(Regions.Area52Unlock));
    AddQuest(new QuestUpperNetherstorm(Regions.UpperNetherstorm));
    AddQuest(new QuestSolarian(Artifacts.EssenceofMurmur));
    AddQuest(new QuestSummonKil(AllLegends.Stormwind.StormwindKeep, AllLegends.Neutral.Karazhan,
      AllLegends.Sunfury.Kael));
    AddQuest(new QuestForgottenKnowledge());
    AddQuest(new QuestWellOfEternity(AllLegends.Sunfury.Kiljaeden));
    AddSunwellVialQuest();
  }

  private void RegisterRoleplayQuests()
  {
    StartingQuest = AddQuest(new QuestEcoDomes(Regions.Biodome1, Regions.Biodome2, Regions.Biodome3));
    AddQuest(new QuestForgottenKnowledge());
    AddQuest(new QuestSilentBlade(Artifacts.EssenceofMurmur));
    var heartOfMuru = new QuestHeartOfMuru();
    AddQuest(heartOfMuru);
    AddQuest(new QuestFallOfTheSunwell(AllLegends.Sunfury.Kael, AllLegends.Sunfury.Kiljaeden, AllLegends.Quel.Sunwell,
      heartOfMuru.HeartOfMuru, true));
    AddQuest(new QuestWellOfEternity(AllLegends.Sunfury.Kiljaeden));
    AddSunwellVialQuest();
  }

  private void AddSunwellVialQuest()
  {
    var sunwell = AllLegends.Quel.Sunwell.Unit;
    if (sunwell != null && sunwell.Alive)
    {
      AddQuest(new QuestExtractSunwellVial(AllLegends.Quel.Sunwell, Artifacts.SunwellVial));
    }
  }
}
