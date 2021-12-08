using AzerothWarsCSharp.MacroTools.Frames;
using AzerothWarsCSharp.MacroTools.UserInterface;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class GameSetup
  {
    public static void Setup()
    {
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
    }
  }
}