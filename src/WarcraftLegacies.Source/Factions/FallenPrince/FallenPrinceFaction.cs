using System.Collections.Generic;
using MacroTools.Factions;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.FallenPrince;

/// <summary>
/// Arthas risen as a death knight, leading what is left of Lordaeron's army as undead. Only reached through the
/// Fallen Prince path in Roleplay mode.
/// </summary>
public sealed class FallenPrinceFaction : Faction
{
  /// <inheritdoc />
  public FallenPrinceFaction() : base("Fallen Prince", playercolor.Navy,
    @"ReplaceableTextures\CommandButtons\BTNHeroDeathKnight.blp")
  {
    TraditionalTeam = TeamSetup.Legion;
    NameTakesArticle = true;
    ControlPointDefenderUnitTypeId = UNIT_U028_CONTROL_POINT_DEFENDER_SCOURGE;
    StartingGold = new StartingGold
    {
      Instant = 1000,
      Income = 0,
      Turns = 0
    };
    Nicknames = new List<string>
    {
      "fp",
      "fallen",
      "fallenprince"
    };
    ProcessObjectInfo(FallenPrinceObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered() => SharedFactionConfigSetup.AddSharedFactionConfig(this);
}
