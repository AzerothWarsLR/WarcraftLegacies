using System.Collections.Generic;
using MacroTools.ArtifactSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;

namespace WarcraftLegacies.Source.Powers
{
  public sealed class Domination : Power
  {
    private readonly List<player> _playersWithPower = new();
    private bool _isActive;

    /// <summary>Active when the <see cref="Power"/> is active, inactive otherwise.</summary>
    public required int ResearchId { get; init; }

    /// <summary>Players can only control these when they have this Power.</summary>
    public required List<int> MindlessUndeadUnitTypes { get; init; }

    /// <summary>The Power is only active while this Artifact is held by the player.</summary>
    public required Artifact DependentArtifact { get; init; }

    public Domination() => Name = "Domination";

    private bool IsActive
    {
      get => _isActive;
      set
      {
        _isActive = value;
        var prefix = IsActive ? "" : "|cffc0c0c0";
        Description =
          $"{prefix}You can train and control Ghouls, Abominations, Frost Wyrms, and Crypt Fiends. Only active while the Lich King holds the Helm of Domination.";
        var researchLevel = _isActive ? 1 : 0;
        foreach (var player in _playersWithPower)
        {
          SetPlayerTechResearched(player, ResearchId, researchLevel);
          if (IsActive)
            ChangeControlOfUndead(Player(PLAYER_NEUTRAL_AGGRESSIVE), player);
          else 
            ChangeControlOfUndead(player, Player(PLAYER_NEUTRAL_AGGRESSIVE));
        }
      }
    }

    /// <inheritdoc />
    public override void OnAdd(Faction whichFaction) => whichFaction.ModObjectLimit(ResearchId, Faction.UNLIMITED);

    /// <inheritdoc />
    public override void OnAdd(player whichPlayer)
    {
      _playersWithPower.Add(whichPlayer);
      DependentArtifact.OwnerChanged += OnArtifactOwnerChanged;
      RefreshIsActive();
    }

    /// <inheritdoc />
    public override void OnRemove(Faction whichFaction) => whichFaction.ModObjectLimit(ResearchId, -Faction.UNLIMITED);
    
    /// <inheritdoc />
    public override void OnRemove(player whichPlayer)
    {
      _playersWithPower.Remove(whichPlayer);
      ChangeControlOfUndead(whichPlayer, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    private void OnArtifactOwnerChanged(object? sender, Artifact artifact) => RefreshIsActive();

    private void RefreshIsActive() =>
      IsActive = DependentArtifact.OwningPlayer != null && _playersWithPower.Contains(DependentArtifact.OwningPlayer);

    private void ChangeControlOfUndead(player oldOwner, player newOwner)
    {
      var playerUnits = CreateGroup()
        .EnumUnitsOfPlayer(oldOwner)
        .EmptyToList();

      foreach (var unit in playerUnits)
        if (MindlessUndeadUnitTypes.Contains(unit.GetTypeId()))
          unit.SetOwner(newOwner);
    }
  }
}