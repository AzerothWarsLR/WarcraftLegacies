using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Researches;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared.Researches;

namespace WarcraftLegacies.Source.Factions.TaurenTribes;

public sealed class TaurenTribesFaction : Faction
{
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
    ProcessObjectInfo(TaurenTribesObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterResearches();
    TaurenTribesSpells.Setup();
    TaurenTribesTraits.Setup();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
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
  }
}
