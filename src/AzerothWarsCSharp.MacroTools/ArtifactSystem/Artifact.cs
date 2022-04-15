using System;
using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.ShoreSystem;
using WCSharp.Events;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.ArtifactSystem
{
  public sealed class Artifact
  {
    private unit? _owningUnit;
    private ArtifactStatus _status;
    private int _titanforgedAbility = FourCC("A0VJ");
    private string? _description;

    public static int ArtifactHolderAbilId { get; } = FourCC("A01Y");

    public Artifact(item whichItem)
    {
      Item = whichItem;
      _status = ArtifactStatus.Ground;
      SetOwningPlayer(null);
      PlayerUnitEvents.Register(PlayerUnitEvent.ItemTypeIsPickedUp, OnPickedUp, GetItemTypeId(whichItem));
      PlayerUnitEvents.Register(PlayerUnitEvent.ItemTypeIsDropped, OnDropped, GetItemTypeId(whichItem));
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeChangesOwner, OnUnitChangesOwner);
      PlayerData.FactionChange += OnPlayerFactionChange;
    }

    private void OnPlayerFactionChange(object? sender, PlayerFactionChangeEventArgs e)
    {
      if (OwningPlayer?.GetFaction() == e.Player.GetFaction())
      {
        FactionChanged?.Invoke(this, this);
      }
    }

    private void OnUnitChangesOwner()
    {
      if (OwningUnit == GetTriggerUnit())
          SetOwningPlayer(GetOwningPlayer(GetTriggerUnit()));
    }
    
    public item Item { get; private set; }

    /// <summary>
    ///   A pretend-position. The player can ping this position instead of the item's real position if
    ///   <see cref="ArtifactStatus" /> is set to <see cref="ArtifactStatus.Special" />.
    /// </summary>
    public Point FalsePosition { get; set; } = new(0, 0);

    /// <summary>
    ///   The extra ability the Artifact gains when it's Titanforged.
    /// </summary>
    public int TitanforgedAbility
    {
      set => _titanforgedAbility = value;
    }

    /// <summary>
    ///   Whether or not the Artifact has gained its bonus ability.
    /// </summary>
    public bool Titanforged { get; private set; }

    public ArtifactStatus Status
    {
      set
      {
        _status = value;
        StatusChanged?.Invoke(this, this);
      }
      get => _status;
    }

    /// <summary>
    ///   The <see cref="unit" /> carrying this <see cref="Artifact" />, if any.
    /// </summary>
    public unit? OwningUnit
    {
      get => _owningUnit;
      private set
      {
        if (OwningPlayer != GetOwningPlayer(value))
        {
          _owningUnit = value;
          SetOwningPlayer(value != null ? GetOwningPlayer(value) : null);
        }
      }
    }

    public string Description
    {
      set
      {
        _description = value;
        DescriptionChanged?.Invoke(this, this);
      }
      get => _description ?? "";
    }

    /// <summary>
    /// Fired when the <see cref="player"/> owning the <see cref="unit"/> carrying the <see cref="Artifact"/> changes <see cref="Faction"/>.
    /// </summary>
    public event EventHandler<Artifact>? FactionChanged;
    
    /// <summary>
    /// Fired when the <see cref="Artifact"/> is picked up by a unit.
    /// </summary>
    public event EventHandler<Artifact>? PickedUp;

    /// <summary>
    /// Fired when the <see cref="Artifact"/> is dropped.
    /// </summary>
    public event EventHandler<Artifact>? Dropped;
    
    /// <summary>
    /// Fired when the <see cref="Artifact"/> is permanently destroyed.
    /// </summary>
    public event EventHandler<Artifact>? Destroyed;

    /// <summary>
    ///   The owner of this <see cref="Artifact" /> changes.
    /// </summary>
    public event EventHandler<Artifact>? OwnerChanged;

    /// <summary>
    ///   Any Artifact changes its <see cref="ArtifactStatus" />.
    /// </summary>
    public event EventHandler<Artifact>? StatusChanged;

    /// <summary>
    ///   Any <see cref="Artifact" /> changes Faction.
    /// </summary>
    public event EventHandler<Artifact>? OnArtifactFactionChange;

    /// <summary>
    /// Any unit carrying an Artifact's unit carrier changes player ownership.
    /// </summary>
    public event EventHandler<Artifact>? CarrierOwnerChanged;

    /// <summary>
    /// Any <see cref="Artifact"/> has its description changed.
    /// </summary>
    public event EventHandler<Artifact>? DescriptionChanged;

    /// <summary>
    ///   Grant the Artifact a predefined bonus ability.
    /// </summary>
    public void Titanforge()
    {
      if (Titanforged == false)
      {
        Titanforged = true;
        BlzItemAddAbility(Item, _titanforgedAbility);
        BlzSetItemExtendedTooltip(Item,
          BlzGetItemExtendedTooltip(Item) + "|n|n|cff800000Titanforged|r|n" +
          BlzGetAbilityExtendedTooltip(_titanforgedAbility, 0));
        BlzSetItemDescription(Item, BlzGetItemDescription(Item) + "|n|cff800000Titanforged|r");
      }
    }

    private void UpdateFaction()
    {
      OnArtifactFactionChange?.Invoke(this, this);
    }

    public player? OwningPlayer { get; private set; }

    private void SetOwningPlayer(player? value)
    {
      OwningPlayer = value;
      OwnerChanged?.Invoke(this, this);

      Status = OwningPlayer != null ? ArtifactStatus.Unit : ArtifactStatus.Ground;
    }

    private void OnPickedUp()
    {
      OwningUnit = GetTriggerUnit();
      PickedUp?.Invoke(this, this);
    }

    private void OnDropped()
    {
      if (!IsTerrainPathable(GetUnitX(_owningUnit), GetUnitY(_owningUnit), PATHING_TYPE_FLOATABILITY) &&
          IsTerrainPathable(GetUnitX(_owningUnit), GetUnitY(_owningUnit), PATHING_TYPE_WALKABILITY))
        if (!UnitAlive(_owningUnit))
        {
          Shore tempShore = Shore.GetNearestShore(new Point(GetUnitX(_owningUnit), GetUnitY(_owningUnit)));
          Item = CreateItem(GetItemTypeId(Item), tempShore.Position.X, tempShore.Position.Y);
        }

      //Remove dummy Artifact holding ability if the dropping unit had one
      if (GetUnitAbilityLevel(_owningUnit, ArtifactHolderAbilId) > 0)
        UnitRemoveAbility(_owningUnit, ArtifactHolderAbilId);

      SetOwningPlayer(null);
      OwningUnit = null;
      Dropped?.Invoke(this, this);
    }

    /// <summary>
    /// Pings the <see cref="Artifact"/> on the minimap for the given player.
    /// </summary>
    public void Ping(player p)
    {
      if (GetLocalPlayer() == p)
      {
        if (_status == ArtifactStatus.Special)
          PingMinimap(FalsePosition.X, FalsePosition.Y, 3);
        else if (_owningUnit != null)
          PingMinimap(GetUnitX(_owningUnit), GetUnitY(_owningUnit), 3);
        else
          PingMinimap(GetItemX(Item), GetItemY(Item), 3);
      }
    }

    public void Destroy()
    {
      Destroyed?.Invoke(this, this);
      RemoveItem(Item);
    }
  }
}