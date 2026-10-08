using System.Collections.Generic;
using MacroTools.Factions;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.FallenPrince;

/// <summary>Arthas and the dead of Lordaeron, reached through the Fallen Prince path.</summary>
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
