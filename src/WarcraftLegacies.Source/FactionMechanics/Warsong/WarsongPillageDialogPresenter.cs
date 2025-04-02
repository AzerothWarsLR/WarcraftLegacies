using System;
using MacroTools.Extensions;

namespace WarcraftLegacies.Source.FactionMechanics.Warsong
{
  public sealed class WarsongPillageDialogPresenter
  {
    private readonly unit _grom;
    private readonly WarsongPillageChoice[] _choices;

    public WarsongPillageDialogPresenter(unit grom, params WarsongPillageChoice[] choices)
    {
      _grom = grom ?? throw new ArgumentNullException(nameof(grom));
      _choices = choices ?? throw new ArgumentNullException(nameof(choices));
    }

    public void Run(player pickingPlayer)
    {
      // Opens the dialog to allow the player to pick their choice, implementation left out for brevity.
    }

    private void OnChoicePicked(player pickingPlayer, WarsongPillageChoice choice)
    {
      if (choice == null)
      {
        Console.WriteLine("No valid choice was made.");
        return;
      }

      Console.WriteLine($"{pickingPlayer.GetName()} picked {choice.Name}");

      // Handle the different reward logic based on choice type.
      if (choice.Type == PillageChoiceType.Subdue)
      {
        if (choice.ResearchReward > 0)
        {
          Console.WriteLine($"Applying research {choice.ResearchReward} for {pickingPlayer.GetName()}.");
          SetPlayerTechResearched(pickingPlayer, choice.ResearchReward, 1);
        }
      }
      else if (choice.Type == PillageChoiceType.Pillage)
      {
        Console.WriteLine($"Applying gold and experience rewards for Pillage to {pickingPlayer.GetName()}...");
        pickingPlayer.AddGold(choice.GoldReward);
        _grom.Unit?.AddExperience.ExperienceReward);
      }
    }
  }
}