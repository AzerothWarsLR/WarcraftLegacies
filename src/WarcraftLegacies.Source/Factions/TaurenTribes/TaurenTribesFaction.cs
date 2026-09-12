using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.PreplacedWidgets;
using MacroTools.Researches;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.TaurenTribes.Quests;
using WarcraftLegacies.Source.Factions.TaurenTribes.Researches;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Shared.Researches;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.TaurenTribes;

public sealed class TaurenTribesFaction : Faction
{
  private const float CampX = -9033.7f;
  private const float CampY = -11365.6f;

  private readonly unit _tent;
  private readonly List<unit> _productionBuildings;
  private readonly Point _thousandNeedlesTarget;
  private readonly Point _mulgoreTarget;
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
    _tent = AllPreplacedWidgets.Units.GetClosest(UNIT_OTNT_CHIEF_S_LODGE_TAUREN_TRIBES_T1, CampX, CampY);
    _productionBuildings = new List<unit>
    {
      AllPreplacedWidgets.Units.GetClosest(UNIT_OTWC_PROVING_GROUND_TAUREN_TRIBES_BARRACKS, CampX, CampY),
      AllPreplacedWidgets.Units.GetClosest(UNIT_OTSL_HALL_OF_ELDERS_TAUREN_TRIBES, CampX, CampY),
      AllPreplacedWidgets.Units.GetClosest(UNIT_OTAL_ALTAR_OF_THE_ANCESTORS_TAUREN_TRIBES_ALTAR, CampX, CampY)
    };
    var thousandNeedlesControlPoint = AllPreplacedWidgets.Units.Get(UNIT_N026_THOUSAND_NEEDLES);
    _thousandNeedlesTarget = new Point(thousandNeedlesControlPoint.X, thousandNeedlesControlPoint.Y);
    var mulgoreControlPoint = AllPreplacedWidgets.Units.Get(UNIT_N09G_MULGORE);
    _mulgoreTarget = new Point(mulgoreControlPoint.X, mulgoreControlPoint.Y);
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
    new GrantResearchOnLegendTrained(UNIT_OCBH_CHIEFTAIN_OF_THE_BLOODHOOF_TAUREN_TRIBES, UPGRADE_RT15_TRAIN_CAIRNE_BLOODHOOF_TAUREN_TRIBES);
  }

  private void RegisterQuests()
  {
    _theLongMarch = new QuestTheLongMarch(AllLegends.Tauren.CairneBloodhoof, _thousandNeedlesTarget, _mulgoreTarget,
      Regions.ThunderBluff);
    StartingQuest = AddQuest(_theLongMarch);
  }

  private void RegisterResearches()
  {
    ResearchManager.RegisterIncompatibleSet(
      new CustomResearch(UPGRADE_RT01_TAUREN_CHIEFTAINS_TAUREN_TRIBES, 0)
      {
        ResearchFunc = researchingPlayer =>
        {
          var faction = researchingPlayer.GetPlayerData().Faction;
          faction?.ModObjectLimit(UNIT_VP51_TAUREN_CHIEFTAIN_TAUREN_TRIBES_ELITE, 6);
        }
      },
      new CustomResearch(UPGRADE_RT02_OGRE_LORDS_TAUREN_TRIBES, 0)
      {
        ResearchFunc = researchingPlayer =>
        {
          var faction = researchingPlayer.GetPlayerData().Faction;
          faction?.ModObjectLimit(UNIT_VP52_OGRE_LORD_TAUREN_TRIBES_ELITE, 6);
        }
      });
    ResearchManager.Register(new StartTheLongMarch(this, _theLongMarch, _tent, _productionBuildings));
  }
}
