using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.TaurenTribes.Spells;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Powers;

public sealed class RootsOfTheWorld : Power
{
  private readonly int _spellbookId;
  private readonly int _cancelAbilityId;
  private readonly List<WorldTreeLink> _links;
  private readonly float _cooldown;
  private readonly timer _cooldownTimer = timer.Create();
  private readonly Dictionary<unit, Dictionary<int, bool>> _disabledAbilities = new();
  private Faction? _faction;
  private unit? _channellingTree;
  private bool _spellsRegistered;

  public RootsOfTheWorld(int spellbookId, int cancelAbilityId, List<WorldTreeLink> links, float channelDuration, float radius,
    int maximumUnits, float cooldown, string channelEffect, string arrivalEffect)
  {
    _spellbookId = spellbookId;
    _cancelAbilityId = cancelAbilityId;
    _links = links;
    _cooldown = cooldown;
    Name = Loc.Get("Roots of the World");
    Description = Loc.Format(
      "Your World Trees can teleport your nearby units to each other. All World Trees share a {cooldown} second cooldown.",
      ("{cooldown}", cooldown.ToString()));
    TravelSpells = new List<WorldTreeTravelSpell>();
    foreach (var link in links)
    {
      TravelSpells.Add(new WorldTreeTravelSpell(link.TravelAbilityId)
      {
        Destination = link.Tree,
        ChannelDuration = channelDuration,
        Radius = radius,
        MaximumUnits = maximumUnits,
        ChannelEffect = channelEffect,
        ArrivalEffect = arrivalEffect,
        TryBeginChannel = TryBeginChannel,
        EndChannel = EndChannel,
        OnTravelled = StartSharedCooldown
      });
    }
  }

  private List<WorldTreeTravelSpell> TravelSpells { get; }

  public override void OnAdd(Faction whichFaction)
  {
    _faction = whichFaction;
    if (!_spellsRegistered)
    {
      foreach (var spell in TravelSpells)
      {
        SpellRegistry.Register(spell);
      }

      _spellsRegistered = true;
    }

    foreach (var link in _links)
    {
      link.Tree.ChangedOwner += OnTreeChangedOwner;
    }

    Refresh();
  }

  public override void OnRemove(Faction whichFaction)
  {
    foreach (var link in _links)
    {
      link.Tree.ChangedOwner -= OnTreeChangedOwner;
      link.Tree.Unit?.RemoveAbility(_spellbookId);
    }

    _disabledAbilities.Clear();

    _faction = null;
  }

  private void OnTreeChangedOwner(LegendChangeOwnerEventArgs args) => Refresh();

  private bool IsOwned(Capital tree) =>
    _faction?.Player != null && tree.Unit != null && tree.Unit.Alive && tree.Unit.Owner == _faction.Player;

  private void Refresh()
  {
    foreach (var source in _links)
    {
      var tree = source.Tree.Unit;
      if (tree == null)
      {
        continue;
      }

      if (!IsOwned(source.Tree))
      {
        tree.RemoveAbility(_spellbookId);
        _disabledAbilities.Remove(tree);
        continue;
      }

      if (tree.GetAbilityLevel(_spellbookId) == 0)
      {
        tree.AddAbility(_spellbookId);
        var remainingCooldown = TimerGetRemaining(_cooldownTimer);
        if (remainingCooldown > 0)
        {
          foreach (var destination in _links)
          {
            BlzStartUnitAbilityCooldown(tree, destination.TravelAbilityId, remainingCooldown);
          }
        }
      }

      foreach (var destination in _links)
      {
        var usable = destination != source && IsOwned(destination.Tree);
        SetDisabled(tree, destination.TravelAbilityId, !usable);
      }

      SetDisabled(tree, _cancelAbilityId, _channellingTree != tree);
    }
  }

  private bool TryBeginChannel(unit tree)
  {
    if (_channellingTree != null || TimerGetRemaining(_cooldownTimer) > 0)
    {
      ShowRemainingCooldownShortly();
      return false;
    }

    _channellingTree = tree;
    SetDisabled(tree, _cancelAbilityId, false);
    return true;
  }

  private void EndChannel(unit tree)
  {
    if (_channellingTree == tree)
    {
      _channellingTree = null;
      SetDisabled(tree, _cancelAbilityId, true);
    }

    ShowRemainingCooldownShortly();
  }

  private void ShowRemainingCooldownShortly()
  {
    var delay = timer.Create();
    delay.Start(0.05f, false, () =>
    {
      delay.Dispose();
      ShowRemainingCooldown();
    });
  }

  private void ShowRemainingCooldown()
  {
    var remainingCooldown = TimerGetRemaining(_cooldownTimer);
    foreach (var source in _links)
    {
      var tree = source.Tree.Unit;
      if (tree == null || !IsOwned(source.Tree))
      {
        continue;
      }

      foreach (var destination in _links)
      {
        if (remainingCooldown > 0)
        {
          BlzStartUnitAbilityCooldown(tree, destination.TravelAbilityId, remainingCooldown);
        }
        else
        {
          BlzEndUnitAbilityCooldown(tree, destination.TravelAbilityId);
        }
      }
    }
  }

  private void SetDisabled(unit tree, int abilityId, bool disabled)
  {
    if (!_disabledAbilities.TryGetValue(tree, out var states))
    {
      states = new Dictionary<int, bool>();
      _disabledAbilities[tree] = states;
    }

    states.TryGetValue(abilityId, out var wasDisabled);
    if (wasDisabled == disabled)
    {
      return;
    }

    BlzUnitDisableAbility(tree, abilityId, disabled, false);
    states[abilityId] = disabled;
  }

  private void StartSharedCooldown()
  {
    _cooldownTimer.Start(_cooldown, false, () => { });
    foreach (var source in _links)
    {
      var tree = source.Tree.Unit;
      if (tree == null || !IsOwned(source.Tree))
      {
        continue;
      }

      foreach (var destination in _links)
      {
        BlzStartUnitAbilityCooldown(tree, destination.TravelAbilityId, _cooldown);
      }
    }
  }
}

public sealed class WorldTreeLink
{
  public WorldTreeLink(Capital tree, int travelAbilityId)
  {
    Tree = tree;
    TravelAbilityId = travelAbilityId;
  }

  public Capital Tree { get; }

  public int TravelAbilityId { get; }
}
