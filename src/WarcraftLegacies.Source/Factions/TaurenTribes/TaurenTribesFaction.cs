using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Localization;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.TaurenTribes;

public sealed class TaurenTribesFaction : Faction
{
  /// <inheritdoc />
  public TaurenTribesFaction() : base("Tauren Tribes", playercolor.Orange, @"ReplaceableTextures\CommandButtons\BTNHeroTaurenChieftain.blp")
  {
    TraditionalTeam = TeamSetup.Kalimdor;
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
    TaurenTribesSpells.Setup();
    TaurenTribesTraits.Setup();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }
}
