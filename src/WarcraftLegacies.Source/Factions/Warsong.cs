using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public class Warsong : Faction
  {
    /// <inheritdoc />
    public Warsong(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup) : base("Warsong", PLAYER_COLOR_ORANGE, "|c00ff8000",
      @"ReplaceableTextures\CommandButtons\BTNHellScream.blp")
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