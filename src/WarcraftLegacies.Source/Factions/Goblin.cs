using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public class Goblin : Faction
  {
    /// <inheritdoc />
    public Goblin(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup) : base("Bilgewater", PLAYER_COLOR_LIGHT_GRAY, "|cff808080",
      @"ReplaceableTextures\CommandButtons\BTNHeroTinker.blp")
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