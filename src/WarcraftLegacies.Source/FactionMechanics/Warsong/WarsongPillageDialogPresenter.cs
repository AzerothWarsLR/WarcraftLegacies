using System;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.UserInterface;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.FactionMechanics.Warsong;

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
      HandlePillageChoice(pickingPlayer, choice);
    }


    else if (choice.Type == PillageChoiceType.Subdue)
    {
      HandleSubdueChoice(pickingPlayer, choice);
    }
  }

  private void HandlePillageChoice(player pickingPlayer, WarsongPillageChoice choice)
  {

    pickingPlayer.Gold += choice.GoldReward;

    var heroes = GlobalGroup.EnumUnitsOfPlayer(pickingPlayer)
      .Where(unit => unit.IsUnitType(unittype.Hero))
      .ToList();

    if (heroes.Count != 0)
    {
      var heroCount = heroes.Count;
      double multiplier;

      switch (heroCount)
      {
        case 1:
          multiplier = 0.50;
          break;
        case 2:
          multiplier = 0.75;
          break;
        default:
          multiplier = 1.0;
          break;
      }

      var splitExperience = (int)(choice.ExperienceReward * multiplier / heroCount);
      foreach (var hero in heroes)
      {
        AddHeroXP(hero, splitExperience, true);
      }
    }


    if (choice.ArtifactRewardItemType.HasValue && _grom != null)
    {
      var artifactItem = item.Create(choice.ArtifactRewardItemType.Value, Regions.ArtifactDummyInstance.Center.X, Regions.ArtifactDummyInstance.Center.Y);
      _grom.AddItem(artifactItem);
    }


    if (choice.ResearchReward > 0)
    {
      var faction = FactionManager.GetAllFactions()
        .FirstOrDefault(f => f.Player == pickingPlayer);

      if (faction != null)
      {
        faction.ModObjectLimit(choice.ResearchReward, Faction.Unlimited);
        faction.SetObjectLevel(choice.ResearchReward, 1);
      }
    }


    foreach (var unit in GlobalGroup.EnumUnitsInRect(choice.Location)
               .Where(unit => unit.IsUnitType(unittype.Structure) &&
                              (unit.Owner == player.NeutralAggressive ||
                               unit.Owner == player.NeutralPassive)))
    {
      unit.SetLifePercent(15);
    }
  }

  private void HandleSubdueChoice(player pickingPlayer, WarsongPillageChoice choice)
  {
    if (choice.ResearchReward > 0)
    {
      var faction = FactionManager.GetAllFactions()
        .FirstOrDefault(f => f.Player == pickingPlayer);

      if (faction != null)
      {
        faction.ModObjectLimit(choice.ResearchReward, Faction.Unlimited);
        faction.SetObjectLevel(choice.ResearchReward, 1);

        var rescueUnits = choice.Location.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
        faction.Player.RescueGroup(rescueUnits);

        foreach (var unit in rescueUnits)
        {
          unit.SetPausedEx(false);
        }


        if (choice.UnitUpgrade != null)
        {
          ApplyUnitUpgrade(faction, choice.UnitUpgrade);
        }
      }
    }
  }

  private static void ApplyUnitUpgrade(Faction faction, UnitUpgrade upgrade)
  {
    if (faction == null || upgrade == null)
    {
      Console.WriteLine("UnitUpgrade failed: Either faction or upgrade is null.");
      return;
    }


    if (upgrade.RemoveUnit != 0)
    {
      faction.ModObjectLimit(upgrade.RemoveUnit, -Faction.Unlimited);
    }


    if (upgrade.AddUnit != 0)
    {
      faction.ModObjectLimit(upgrade.AddUnit, Faction.Unlimited);
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
