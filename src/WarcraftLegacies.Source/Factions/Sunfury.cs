using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public class Sunfury : Faction
  {
    /// <inheritdoc />
    public Sunfury(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup) : base("Sunfury", PLAYER_COLOR_MAROON, "|cffff0000",
      @"ReplaceableTextures\CommandButtons\BTNBloodMage2.blp")
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