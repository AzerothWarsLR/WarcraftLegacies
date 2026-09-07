using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Researches;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared.Researches;

namespace WarcraftLegacies.Source.Factions.OrcishHorde;

public sealed class OrcishHordeFaction : Faction
{
  /// <inheritdoc />
  public OrcishHordeFaction() : base("Orcish Horde", playercolor.Red, @"ReplaceableTextures\CommandButtons\BTNThrall.blp")
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
      ("{faction}", $"{PrefixCol}{Loc.Get("Orcish Horde")}|r"));
    Nicknames = new List<string>
    {
      "horde",
      "oh",
      "orc",
      "orcs"
    };
    ProcessObjectInfo(OrcishHordeObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterResearches();
    OrcishHordeSpells.Setup();
    OrcishHordeTraits.Setup();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }

  private void RegisterResearches()
  {
    ResearchManager.RegisterIncompatibleSet(
      new CustomResearch(UPGRADE_RZ02_BLADEMASTERS_ORCISH_HORDE, 0)
      {
        ResearchFunc = researchingPlayer =>
        {
          var faction = researchingPlayer.GetPlayerData().Faction;
          faction?.ModObjectLimit(UNIT_O00G_BLADEMASTER_ORCISH_HORDE, 6);
        }
      },
      new CustomResearch(UPGRADE_RZ03_KOR_KRON_ELITES_ORCISH_HORDE, 0)
      {
        ResearchFunc = researchingPlayer =>
        {
          var faction = researchingPlayer.GetPlayerData().Faction;
          faction?.ModObjectLimit(UNIT_N03F_KOR_KRON_ELITE_ORCISH_HORDE_ELITE, 6);
        }
      });
  }
}
