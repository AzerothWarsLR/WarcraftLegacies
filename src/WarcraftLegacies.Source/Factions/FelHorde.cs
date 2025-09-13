using System.Collections.Generic;
using MacroTools.FactionSystem;
using MacroTools.Systems;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.FactionMechanics.Fel_Horde;
using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Quests.Fel_Horde;
using WarcraftLegacies.Source.Setup;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions
{
  public sealed class FelHorde : Faction
  {
    private readonly PreplacedUnitSystem _preplacedUnitSystem;
    private readonly AllLegendSetup _allLegendSetup;
    private readonly ArtifactSetup _artifactSetup;

    /// <inheritdoc />
    
    public FelHorde(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup)
      : base("Fel Horde", PLAYER_COLOR_GREEN, @"ReplaceableTextures\CommandButtons\BTNPitLord.blp")
    {
      TraditionalTeam = TeamSetup.Outland;
      _preplacedUnitSystem = preplacedUnitSystem;
      _allLegendSetup = allLegendSetup;
      _artifactSetup = artifactSetup;
      UndefeatedResearch = FourCC("R05L");
      StartingGold = 200;
      CinematicMusic = "Doom";
      ControlPointDefenderUnitTypeId = UNIT_N0AA_CONTROL_POINT_DEFENDER_FEL_HORDE;
      IntroText = IntroText = $"You are playing as the bloodthirsty {PrefixCol}Fel Horde|r.\n\n" +
                              "You begin in Nagrand, cut off from your forces in Hellfire Citadel. You must raise an army and quickly conquer Outland.\n\n" +
                              "Once Outland is under your control, gather your hordes and prepare to invade Azeroth through the Dark Portal.\n\n" +
                              "The Alliance is gathering outside the Dark Portal to stop you, so prepare for a very hard breakout.";

      FoodMaximum = 250;
      GoldMines = new List<unit>
      {
        _preplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(-2735, -30242))
      };
      Nicknames = new List<string>
      {
        "fh",
        "fel"
      };
      ProcessObjectInfo(FelHordeObjectInfo.GetAllObjectInfos());
    }

    /// <inheritdoc />
    public override void OnRegistered()
    {
      RegisterObjectLevels();
      RegisterQuests();
      JuggernautDeath.Setup(_preplacedUnitSystem);
      SharedFactionConfigSetup.AddSharedFactionConfig(this);
    }

    private void RegisterObjectLevels()
    {
      ModAbilityAvailability(ABILITY_A0GM_FOR_THE_HORDE_PINK_GREY_MAIN_BUILDINGS, -1);
    }

    private void RegisterQuests()
    {
      var questHellfireCitadel = AddQuest(new QuestHellfireCitadel(Regions.HellfireUnlock));
      AddQuest(new QuestRuinsofShadowmoon(Regions.ShadowmoonBaseUnlock));
      AddQuest(new QuestBlackrock(Regions.BlackrockUnlock, Regions.DarkPortalUnlock, new[] { questHellfireCitadel }));
      AddQuest(new QuestFelHordeKillIronforge(_allLegendSetup.Ironforge.GreatForge));
      AddQuest(new QuestFelHordeKillStormwind(_allLegendSetup.Stormwind.StormwindKeep));
      AddQuest(new QuestGuldansLegacy());
      AddQuest(new QuestDarkPortal(
        _preplacedUnitSystem.GetUnit(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Entrance_1.Center),
        _preplacedUnitSystem.GetUnit(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Entrance_2.Center),
        _preplacedUnitSystem.GetUnit(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Entrance_3.Center),
        _preplacedUnitSystem.GetUnit(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Exit_1.Center),
        _preplacedUnitSystem.GetUnit(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Exit_2.Center),
        _preplacedUnitSystem.GetUnit(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Exit_3.Center)));
      AddQuest(new QuestExtractSunwellVial(_allLegendSetup.Quelthalas.Sunwell, _artifactSetup.SunwellVial));
    }
  }
}