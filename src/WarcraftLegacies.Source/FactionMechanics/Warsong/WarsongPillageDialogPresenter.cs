using System;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.UserInterface;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.FactionMechanics.Warsong
{
  public sealed class WarsongPillageDialogPresenter : ChoiceDialogPresenter<WarsongPillageChoice>
  {
    private readonly unit _grom;
    private bool _rewardsGranted;

    public WarsongPillageDialogPresenter(unit grom, params WarsongPillageChoice[] choices)
      : base(choices, "Select how to handle the Ogres")
    {
      _grom = grom ?? throw new ArgumentNullException(nameof(grom));
    }

    /// <summary>
    /// Handles the reward logic based on the choice picked by the player.
    /// </summary>
    protected override void OnChoicePicked(player pickingPlayer, WarsongPillageChoice choice)
    {
      if (choice == null)
      {
        Console.WriteLine("No choice was selected.");
        return;
      }

      // Prevent double execution of rewards
      if (_rewardsGranted)
      {
        Console.WriteLine("Rewards have already been granted; skipping duplicate execution.");
        return;
      }

      _rewardsGranted = true;

      Console.WriteLine($"{pickingPlayer} selected {choice.Name}");

      if (choice.Type == PillageChoiceType.Pillage)
      {
        // Handle Pillage rewards
        Console.WriteLine($"Awarding {choice.GoldReward} gold and {choice.ExperienceReward} XP to {pickingPlayer}...");
        pickingPlayer.AddGold(choice.GoldReward);
        _grom?.AddExperience(choice.ExperienceReward);

        // Reduce life to 15% for all neutral structures in the location
        foreach (var unit in GlobalGroup.EnumUnitsInRect(choice.Location)
                   .Where(unit => IsUnitType(unit, UNIT_TYPE_STRUCTURE) &&
                                  (unit.OwningPlayer() == Player(PLAYER_NEUTRAL_AGGRESSIVE) ||
                                   unit.OwningPlayer() == Player(PLAYER_NEUTRAL_PASSIVE))))
        {
          unit.SetLifePercent(15);
        }
      }
     else if (choice.Type == PillageChoiceType.Subdue)
     {
       // Handle Subdue rewards
       if (choice.ResearchReward > 0)
       {
         // Find the faction related to the picking player
         var faction = FactionManager.GetAllFactions()
           .FirstOrDefault(f => f.Player == pickingPlayer);

         if (faction != null)
         {
           Console.WriteLine($"Granting research upgrade {choice.ResearchReward} for faction {faction.Name}...");
            
           // Directly calling SetPlayerTechResearched
           SetPlayerTechResearched(faction.Player, choice.ResearchReward, 1);

           Console.WriteLine("Rescuing all neutral units in the designated area...");
           var rescueUnits = choice.Location.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
           faction.Player.RescueGroup(rescueUnits); // Rescue for the faction's player
         }
         else
         {
           Console.WriteLine("Failed to grant research: Faction not found for the given player.");
         }
       }
     }
else
{
    Console.WriteLine($"Unhandled choice type: {choice.Type}");
}
    }

    /// <summary>
    /// Specifies the default choice to be picked if no explicit choice is made.
    /// </summary>
    protected override WarsongPillageChoice GetDefaultChoice(player whichPlayer)
    {
      return Choices.FirstOrDefault();
    }

    /// <summary>
    /// Specifies whether a choice is active and pickable for the player.
    /// </summary>
    protected override bool IsChoiceActive(player whichPlayer, WarsongPillageChoice choice)
    {
      return true; 
    }

    /// <summary>
    /// Grants a research upgrade to a faction.
    /// </summary>
    /// <param name="faction">The faction receiving the research upgrade.</param>
    /// <param name="researchId">The ID of the research to grant.</param>
    private void GrantResearchToFaction(Faction faction, int researchId)
    {
      if (faction == null || researchId <= 0)
      {
        Console.WriteLine($"Failed to grant research ID {researchId}. Invalid faction or ID.");
        return;
      }

      // Set the research to unlimited for the faction
      SetPlayerTechResearched(faction.Player, researchId, 1);

    }


  }
}