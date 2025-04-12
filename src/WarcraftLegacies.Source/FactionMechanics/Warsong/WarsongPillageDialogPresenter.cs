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
      : base(choices, "Choose their fate")
    {
      _grom = grom ?? throw new ArgumentNullException(nameof(grom));
    }

    protected override void OnChoicePicked(player pickingPlayer, WarsongPillageChoice choice)
    {
      if (choice == null || _rewardsGranted)
      {
        return;
      }
      _rewardsGranted = true;

      if (choice.Type == PillageChoiceType.Pillage)
      {
        pickingPlayer.AddGold(choice.GoldReward);

        var heroes = GlobalGroup.EnumUnitsOfPlayer(pickingPlayer)
          .Where(unit => IsUnitType(unit, UNIT_TYPE_HERO))
          .ToList();

        if (heroes.Any())
        {
          var splitExperience = choice.ExperienceReward / heroes.Count;
          foreach (var hero in heroes)
          {
            hero.AddExperience(splitExperience);
          }
        }

        if (choice.ArtifactRewardItemType.HasValue && _grom != null)
        {
          var artifactItem = CreateItem(
            choice.ArtifactRewardItemType.Value,
            Regions.ArtifactDummyInstance.Center.X,
            Regions.ArtifactDummyInstance.Center.Y
          );
          UnitAddItem(_grom, artifactItem);
        }

        if (choice.ResearchReward > 0)
        {
          var faction = FactionManager.GetAllFactions()
            .FirstOrDefault(f => f.Player == pickingPlayer);

          if (faction != null)
          {
            faction.ModObjectLimit(choice.ResearchReward, Faction.UNLIMITED);
            faction.SetObjectLevel(choice.ResearchReward, 1);
          }
        }

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
        if (choice.ResearchReward > 0)
        {
          var faction = FactionManager.GetAllFactions()
            .FirstOrDefault(f => f.Player == pickingPlayer);

          if (faction != null)
          {
            faction.ModObjectLimit(choice.ResearchReward, Faction.UNLIMITED);
            faction.SetObjectLevel(choice.ResearchReward, 1);

            var rescueUnits = choice.Location.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
            faction.Player.RescueGroup(rescueUnits);

            foreach (var unit in rescueUnits)
            {
              unit.PauseEx(false);
            }
          }
        }
      }
    }

    protected override WarsongPillageChoice GetDefaultChoice(player whichPlayer)
    {
      return Choices.FirstOrDefault();
    }

    protected override bool IsChoiceActive(player whichPlayer, WarsongPillageChoice choice)
    {
      return true;
    }
  }
}