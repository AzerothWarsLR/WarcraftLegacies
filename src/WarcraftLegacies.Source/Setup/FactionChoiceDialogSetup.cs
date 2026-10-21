using System;
using MacroTools.Factions.Choices;
using WarcraftLegacies.Source.Factions.Dalaran;
// using WarcraftLegacies.Source.Factions.Frostwolf; // Disabled: player slot 0 is now Orcish Horde, Frostwolf and Warsong are being removed
using WarcraftLegacies.Source.Factions.Gilneas;
using WarcraftLegacies.Source.Factions.Illidari;
using WarcraftLegacies.Source.Factions.Sunfury;
using WarcraftLegacies.Source.GameLogic;
// using WarcraftLegacies.Source.Factions.Warsong;

namespace WarcraftLegacies.Source.Setup;

public static class FactionChoiceDialogSetup
{
  private const int ChoicePairCount = 2;

  public static void Setup(Action onAllChoicesResolved)
  {
    var remaining = ChoicePairCount;
    void OnChoiceResolved()
    {
      if (--remaining == 0)
      {
        onAllChoicesResolved();
      }
    }

    var illidari = new FactionChoice
    {
      Faction = new IllidariFaction(),
      Difficulty = FactionLearningDifficulty.Basic,
      StartingArea = Regions.IllidanStartingPosition
    };
    var sunfury = new FactionChoice
    {
      Faction = new SunfuryFaction(),
      Difficulty = FactionLearningDifficulty.Advanced,
      StartingArea = Regions.SunfuryStartingPosition,
      Disabled = RoleplaySetting.IsActive
    };
    new FactionChoiceDialogPresenter(illidari, sunfury).Run(player.Create(15), OnChoiceResolved);

    var dalaran = new FactionChoice
    {
      Faction = new DalaranFaction(),
      Difficulty = FactionLearningDifficulty.Basic,
      StartingArea = Regions.DalaStartPos
    };
    var gilneas = new FactionChoice
    {
      Faction = new GilneasFaction(),
      Difficulty = FactionLearningDifficulty.Advanced,
      StartingArea = Regions.DalaStartPos,
      RequiresCheats = false,
      Disabled = RoleplaySetting.IsActive
    };
    new FactionChoiceDialogPresenter(dalaran, gilneas).Run(player.Create(7), OnChoiceResolved);

    // Disabled: player slot 0 is now Orcish Horde, Frostwolf and Warsong are being removed
    // var frostwolf = new FactionChoice
    // {
    //   Faction = new FrostwolfFaction(),
    //   Difficulty = FactionLearningDifficulty.Basic,
    //   StartingArea = Regions.FrostwolfStartPos
    // };
    // var warsong = new FactionChoice
    // {
    //   Faction = new WarsongFaction(),
    //   Difficulty = FactionLearningDifficulty.Advanced,
    //   StartingArea = Regions.FrostwolfStartPos,
    //   RequiresCheats = false
    // };
    // new FactionChoiceDialogPresenter(frostwolf, warsong).Run(player.Create(0));
  }
}
