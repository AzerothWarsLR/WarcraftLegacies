using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public class Stormwind : Faction
  {
    /// <inheritdoc />
    public Stormwind(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup) : base("Stormwind", PLAYER_COLOR_BLUE, "|c000042ff",
      @"ReplaceableTextures\CommandButtons\BTNKnight.blp")
    {
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