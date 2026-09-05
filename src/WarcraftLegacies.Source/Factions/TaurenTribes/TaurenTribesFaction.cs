using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.PreplacedWidgets;
using MacroTools.Researches;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.TaurenTribes.Quests;
using WarcraftLegacies.Source.Factions.TaurenTribes.Researches;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.TaurenTribes;

public sealed class TaurenTribesFaction : Faction
{
  private const float CampX = -9033.7f;
  private const float CampY = -11365.6f;

  private readonly unit _tent;
  private readonly List<unit> _productionBuildings;
  private QuestTheLongMarch _theLongMarch = null!;

  /// <inheritdoc />
  public TaurenTribesFaction() : base("Tauren Tribes", playercolor.Orange, @"ReplaceableTextures\CommandButtons\BTNHeroTaurenChieftain.blp")
  {
    TraditionalTeam = TeamSetup.Horde;
    ControlPointDefenderUnitTypeId = UNIT_N0B6_CONTROL_POINT_DEFENDER_FROSTWOLF;
    StartingGold = new StartingGold
    {
      Instant = 200,
      Income = 130,
      Turns = 10
    };
    CinematicMusic = "SadMystery";
    IntroText = () => Loc.Format(
      "You are playing as the {faction}.",
      ("{faction}", $"{PrefixCol}{Loc.Get("Tauren Tribes")}|r"));
    Nicknames = new List<string>
    {
      "tauren",
      "tt"
    };
    _tent = AllPreplacedWidgets.Units.GetClosest(UNIT_OTNT_TAUREN_CAMP_TAUREN_TRIBES, CampX, CampY);
    _productionBuildings = new List<unit>
    {
      AllPreplacedWidgets.Units.GetClosest(UNIT_OTWC_WAR_CAMP_TAUREN_TRIBES, CampX, CampY),
      AllPreplacedWidgets.Units.GetClosest(UNIT_OTBE_BEASTIARY_TAUREN_TRIBES, CampX, CampY),
      AllPreplacedWidgets.Units.GetClosest(UNIT_OTSL_SPIRIT_LODGE_TAUREN_TRIBES, CampX, CampY)
    };
    ProcessObjectInfo(TaurenTribesObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterQuests();
    RegisterResearches();
    TaurenTribesSpells.Setup();
    TaurenTribesTraits.Setup();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }

  private void RegisterQuests()
  {
    _theLongMarch = new QuestTheLongMarch();
    StartingQuest = AddQuest(_theLongMarch);
  }

  private void RegisterResearches()
  {
    ResearchManager.Register(new StartTheLongMarch(this, _theLongMarch, _tent, _productionBuildings));
  }
}
