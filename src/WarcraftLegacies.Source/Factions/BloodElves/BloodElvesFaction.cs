using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Localization;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.BloodElves.Quests;
using WarcraftLegacies.Source.Factions.Quelthalas.Quests;
using WarcraftLegacies.Source.Factions.Sunfury;
using WarcraftLegacies.Source.Factions.Sunfury.Quests;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Shared.Quests;

namespace WarcraftLegacies.Source.Factions.BloodElves;

/// <summary>Kael'thas's Blood Elves, exiled to Outland after the fall of the Sunwell.</summary>
public sealed class BloodElvesFaction : Faction
{
  public BloodElvesFaction()
    : base("Blood Elves", playercolor.Red, @"ReplaceableTextures\CommandButtons\BTNHeroBloodElfPrince.blp")
  {
    TraditionalTeam = TeamSetup.Outland;
    CinematicMusic = "BloodElfTheme";
    FoodMaximum = 250;
    ControlPointDefenderUnitTypeId = UNIT_N0BC_CONTROL_POINT_DEFENDER_QUELTHALAS;
    IntroText = () => Loc.Format(
      "You are now playing as the exiled {faction}.\n\nThe Sunwell has fallen, and its loss gnaws at every elf of Quel'thalas. Prince Kael'thas has left the homeland to its old allies and led his people through the Dark Portal to Tempest Keep.\n\nClaim the power of Netherstorm to sate your people's hunger. When Kael'thas is ready, he will return to the Sunwell and open the way for a far greater power.",
      ("{faction}", $"{PrefixCol}{Loc.Get("Blood Elves")}|r"));
    Nicknames = new List<string>
    {
      "be",
      "blood",
      "bloodelves"
    };
    ProcessObjectInfo(BloodElvesObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterQuests();
    SunfurySpells.Setup();
    BloodElvesSpells.Setup();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }

  private void RegisterQuests()
  {
    StartingQuest = AddQuest(new QuestEcoDomes(Regions.Biodome1, Regions.Biodome2, Regions.Biodome3));
    AddQuest(new QuestSolarian(Artifacts.EssenceofMurmur));
    AddQuest(new QuestForgottenKnowledge());
    var heartOfMuru = new QuestHeartOfMuru();
    AddQuest(heartOfMuru);
    AddQuest(new QuestFallOfTheSunwell(AllLegends.Sunfury.Kael, AllLegends.Sunfury.Kiljaeden, AllLegends.Quel.Sunwell,
      heartOfMuru.HeartOfMuru));
    var sunwell = AllLegends.Quel.Sunwell.Unit;
    if (sunwell != null && sunwell.Alive)
    {
      AddQuest(new QuestExtractSunwellVial(AllLegends.Quel.Sunwell, Artifacts.SunwellVial));
    }
  }
}
