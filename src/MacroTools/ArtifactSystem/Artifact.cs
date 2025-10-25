using System;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Events;

namespace MacroTools.ArtifactSystem;

/// <summary>
///   Represents a unique item with some significance to the game's lore.
/// </summary>
public sealed class Artifact
{
  private ArtifactLocationType _locationType;
  private unit? _owningUnit;

  /// <summary>
  ///   Initializes a new instance of the <see cref="Artifact" /> class.
  /// </summary>
  /// <param name="whichItem">The real item that the Artifact is representing.</param>
  public Artifact(item whichItem)
  {
    Item = whichItem;
    _locationType = ArtifactLocationType.Ground;
    SetOwningPlayer(null);
    PlayerUnitEvents.Register(ItemTypeEvent.IsPickedUp, OnPickedUp, whichItem.TypeId);
    PlayerUnitEvents.Register(ItemTypeEvent.IsDropped, OnDropped, whichItem.TypeId);
    PlayerUnitEvents.Register(UnitTypeEvent.ChangesOwner, OnUnitChangesOwner);
    PlayerData.FactionChange += OnPlayerFactionChange;
  }

  /// <summary>
  ///   This ability is granted to any creep unit which holds an Artifact at the start of the game.
  ///   It should be an inventory ability so that the creep can hold the Artifact.
  /// </summary>
  public static int ArtifactHolderAbilId { get; } = FourCC("A01Y");

  /// <summary>
  ///   The real <see cref="item" /> that the <see cref="Artifact" /> is representing.
  /// </summary>
  public item Item { get; }

  /// <summary>
  ///   Describes the kind of location that the <see cref="Artifact" /> is in.
  /// </summary>
  public ArtifactLocationType LocationType
  {
    private set
    {
      _locationType = value;
      StatusChanged?.Invoke(this, this);
    }
    get => _locationType;
  }

  /// <summary>
  ///   The <see cref="unit" /> carrying this <see cref="Artifact" />, if any.
  /// </summary>
  public unit? OwningUnit
  {
    get => _owningUnit;
    private set
    {
      _owningUnit = value;
      if (OwningPlayer != value.Owner)
      {
        SetOwningPlayer(value != null ? value.Owner : null);
      }
    }
  }

  /// <summary>
  ///   The <see cref="player" /> owning the <see cref="unit" /> carrying this <see cref="Artifact" />.
  ///   Returs null if the Artifact is not being carried.
  /// </summary>
  public player? OwningPlayer { get; private set; }

  /// <summary>
  ///   Fired when the <see cref="player" /> owning the <see cref="unit" /> carrying the <see cref="Artifact" /> changes
  ///   <see cref="Faction" />.
  /// </summary>
  public event EventHandler<Artifact>? FactionChanged;

  /// <summary>
  ///   Fired when the <see cref="Artifact" /> is picked up by a unit.
  /// </summary>
  public event EventHandler<Artifact>? PickedUp;

  /// <summary>
  ///   Fired when the <see cref="Artifact" /> is dropped.
  /// </summary>
  public event EventHandler<Artifact>? Dropped;

  /// <summary>
  ///   Fired when the <see cref="Artifact" /> is permanently destroyed.
  /// </summary>
  public event EventHandler<Artifact>? Disposed;

  /// <summary>
  ///   The owner of this <see cref="Artifact" /> changes.
  /// </summary>
  public event EventHandler<Artifact>? OwnerChanged;

  /// <summary>
  ///   Any Artifact changes its <see cref="ArtifactLocationType" />.
  /// </summary>
  public event EventHandler<Artifact>? StatusChanged;

  /// <summary>
  ///   Pings the <see cref="Artifact" /> on the minimap for the given player.
  /// </summary>
  public void Ping(player whichPlayer)
  {
    if (_owningUnit != null)
    {
      whichPlayer.PingMinimapSimple(_owningUnit.X, _owningUnit.Y, 3);
    }
    else
    {
      whichPlayer.PingMinimapSimple(Item.X, Item.Y, 3);
    }
  }

  private void SetOwningPlayer(player? value)
  {
    OwningPlayer = value;
    OwnerChanged?.Invoke(this, this);

    LocationType = OwningPlayer != null ? ArtifactLocationType.Unit : ArtifactLocationType.Ground;
  }

  private void OnPickedUp()
  {
    OwningUnit = @event.Unit;
    PickedUp?.Invoke(this, this);
  }

  private void OnDropped()
  {
    //Remove dummy Artifact holding ability if the dropping unit had one
    if (_owningUnit.GetAbilityLevel(ArtifactHolderAbilId) > 0)
    {
      _owningUnit.RemoveAbility(ArtifactHolderAbilId);
    }

    SetOwningPlayer(null);
    OwningUnit = null;
    Dropped?.Invoke(this, this);
  }

  private void OnPlayerFactionChange(object? sender, PlayerFactionChangeEventArgs e)
  {
    var owningFaction = OwningPlayer?.GetPlayerData().Faction;
    if (owningFaction == null)
    {
      return;
    }

    if (owningFaction == e.Player.GetPlayerData().Faction)
    {
      FactionChanged?.Invoke(this, this);
    }
  }

  private void OnUnitChangesOwner()
  {
    if (OwningUnit == @event.Unit)
    {
      SetOwningPlayer(@event.Unit.Owner);
    }
  }

  /// <summary>
  /// Cleans up all managed resources used by the <see cref="Artifact"/>.
  /// </summary>
  internal void Dispose()
  {
    Disposed?.Invoke(this, this);
    Item.Dispose();
  }
}
