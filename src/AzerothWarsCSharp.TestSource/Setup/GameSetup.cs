using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Frames.Books.Artifacts;
using AzerothWarsCSharp.MacroTools.Frames.Books.Powers;
using AzerothWarsCSharp.MacroTools.UserInterface;
using static War3Api.Common;

namespace AzerothWarsCSharp.TestSource.Setup
{
  public static class GameSetup
  {
    public static void Setup()
    {
      PreplacedUnitSystem.Initialize();
      SpellSetup.Setup();
      TeamSetup.Setup();
      NorthAllianceSetup.Setup(new[]
      {
        DalaranSetup.Setup(Player(7))
      });
      FactionMultiboard.Initialize();
      CheatSetup.Setup();
      QuestMenuSetup.Setup();
      ArtifactSetup.DrektharsSpellbookSetup();
      ArtifactSetup.FillerArtifactSetup();
      ArtifactBook.Initialize();
      PowerBook.Initialize();
      PreplacedUnitSystem.Shutdown();
    }
  }
}