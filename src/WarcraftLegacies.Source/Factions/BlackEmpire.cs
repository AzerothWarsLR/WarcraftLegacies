using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public class BlackEmpire : Faction
  {
    /// <inheritdoc />
    public BlackEmpire(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup) : base("BlackEmpire", PLAYER_COLOR_TURQUOISE, "|C0000FFFF",
      @"ReplaceableTextures\CommandButtons\BTNNzothIcon.blp")
    {
      ControlPointDefenderUnitTypeId = Constants.UNIT_N0DV_CONTROL_POINT_DEFENDER_BLACK_EMPIRE_TOWER;
    }
    
    /// <inheritdoc />
    public override void OnRegistered()
    {
      RegisterObjectLimits();
      RegisterQuests();
      RegisterDialogue();
    }

    private void RegisterObjectLimits()
    {
      throw new System.NotImplementedException();
    }

    private void RegisterQuests()
    {
      throw new System.NotImplementedException();
    }

    private void RegisterDialogue()
    {
      throw new System.NotImplementedException();
    }
  }
}