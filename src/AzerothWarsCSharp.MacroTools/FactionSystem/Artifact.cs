using System;
using System.Collections.Generic;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.MacroTools.FactionSystem
{
  public sealed class Artifact
  {
    private static readonly Dictionary<int, Artifact> ArtifactsByType = new();
    private static readonly List<Artifact> AllArtifacts = new();

    private readonly int _artifactHolderAbilId = FourCC("A01Y");
    private Person? _owningPerson;
    private unit? _owningUnit;
    private ArtifactStatus _status;
    private int _titanforgedAbility = FourCC("A0VJ");
    private string? _description;

    public Artifact(item whichItem)
    {
      Item = whichItem;
      _status = ArtifactStatus.Ground;
      SetOwningPerson(null);
    }

    /// <summary>
    /// Registers an <see cref="Artifact"/> to the Artifact System.
    /// </summary>
    public static void Register(Artifact artifact)
    {
      if (!ArtifactsByType.ContainsKey(GetItemTypeId(artifact.Item)))
      {
        ArtifactsByType[GetItemTypeId(artifact.Item)] = artifact;
        OnArtifactCreate?.Invoke(artifact, artifact);
        AllArtifacts.Add(artifact);
      }
      else
      {
        throw new Exception($"Attempted to create already existing Artifact from {GetItemName(artifact.Item)}.");
      }
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
        OnArtifactStatusChange?.Invoke(this, this);
      }
    }

    /// <summary>
    ///   The <see cref="unit" /> carrying this <see cref="Artifact" />, if any.
    /// </summary>
    public unit? OwningUnit
    {
      get => _owningUnit;
      private set
      {
        if (_owningPerson != Person.ByHandle(GetOwningPlayer(value)))
          SetOwningPerson(value != null ? Person.ByHandle(GetOwningPlayer(value)) : null);
      }
    }

    public string Description
    {
      set
      {
        _description = value;
        OnArtifactDescriptionChange?.Invoke(this, this);
      }
    }

    public static event EventHandler<Artifact>? OnArtifactCreate;
    public static event EventHandler<Artifact>? OnArtifactAcquire;
    public static event EventHandler<Artifact>? OnArtifactDrop;
    public static event EventHandler<Artifact>? OnArtifactDestroy;

    /// <summary>
    ///   The owner of this <see cref="Artifact" /> changes.
    /// </summary>
    public event EventHandler<Artifact>? OnArtifactOwnerChange;

    /// <summary>
    ///   Any Artifact changes its <see cref="ArtifactStatus" />.
    /// </summary>
    public event EventHandler<Artifact>? OnArtifactStatusChange;

    /// <summary>
    ///   Any <see cref="Artifact" /> changes Faction.
    /// </summary>
    public event EventHandler<Artifact>? OnArtifactFactionChange;

    /// <summary>
    /// Any unit carrying an Artifact has its owner changed.
    /// </summary>
    public event EventHandler<Artifact>?
      OnArtifactCarrierOwnerChange;

    /// <summary>
    /// Any <see cref="Artifact"/> has its description changed.
    /// </summary>
    public event EventHandler<Artifact>?
      OnArtifactDescriptionChange;

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

    private void SetOwningPerson(Person? p)
    {
      _owningPerson = p;
      OnArtifactOwnerChange?.Invoke(this, this);

      Status = _owningPerson != null ? ArtifactStatus.Unit : ArtifactStatus.Ground;
    }

    public static Artifact GetFromTypeId(int typeId)
    {
      return ArtifactsByType[typeId];
    }

    private void PickedUp()
    {
      OwningUnit = GetTriggerUnit();
      OnArtifactAcquire?.Invoke(this, this);
    }

    private void Dropped()
    {
      if (!IsTerrainPathable(GetUnitX(_owningUnit), GetUnitY(_owningUnit), PATHING_TYPE_FLOATABILITY) &&
          IsTerrainPathable(GetUnitX(_owningUnit), GetUnitY(_owningUnit), PATHING_TYPE_WALKABILITY))
        if (!UnitAlive(_owningUnit))
        {
          Shore tempShore = Shore.GetNearestShore(GetUnitX(_owningUnit), GetUnitY(_owningUnit));
          Item = CreateItem(GetItemTypeId(Item), tempShore.Position.X, tempShore.Position.Y);
        }

      //Remove dummy Artifact holding ability if the dropping unit had one
      if (GetUnitAbilityLevel(_owningUnit, _artifactHolderAbilId) > 0)
        UnitRemoveAbility(_owningUnit, _artifactHolderAbilId);

      SetOwningPerson(null);
      OwningUnit = null;
      OnArtifactDrop?.Invoke(this, this);
    }

    private void Ping(player p)
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
      OnArtifactDestroy?.Invoke(this, this);
      RemoveItem(Item);
    }

    private static void ItemPickup()
    {
      ArtifactsByType[GetItemTypeId(GetManipulatedItem())]?.PickedUp();
    }

    private static void ItemDrop()
    {
      if (!IsUnitIllusion(GetTriggerUnit()))
      {
        Artifact tempArtifact = ArtifactsByType[GetItemTypeId(GetManipulatedItem())];
        if (tempArtifact != null) tempArtifact.Dropped();
      }
    }

    private static void OnPersonFactionChanged(object? sender, Person person)
    {
    }

    private static IEnumerable<Artifact> GetAllArtifacts()
    {
      foreach (var artifact in AllArtifacts) yield return artifact;
    }

    /// <summary>
    ///   When a unit carrying an <see cref="Artifact" /> changes owner, update their <see cref="Artifact" />s owner
    ///   information.
    /// </summary>
    private static void UnitChangeOwner()
    {
      if (GetTriggerUnit() != null)
        foreach (var artifact in GetAllArtifacts())
          if (artifact.OwningUnit == GetTriggerUnit())
            artifact.SetOwningPerson(Person.ByHandle(GetOwningPlayer(GetTriggerUnit())));
    }

    public static void Setup()
    {
      Person.FactionChange += OnPersonFactionChanged;
      PlayerUnitEvents.Register(PlayerUnitEvent.ItemTypeIsPickedUp, ItemPickup);
      PlayerUnitEvents.Register(PlayerUnitEvent.ItemTypeIsDropped, ItemDrop);
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeChangesOwner, UnitChangeOwner);
    }
  }
}