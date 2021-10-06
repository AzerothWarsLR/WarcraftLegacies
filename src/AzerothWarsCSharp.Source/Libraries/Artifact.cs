using System;
using System.Collections.Generic;
using WCSharp.Events;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Libraries
{
  public enum ArtifactStatus
  {
    Ground,
    Unit,
    Special,
    Hidden
  }

  public sealed class ArtifactEventArgs : EventArgs
  {
    public ArtifactEventArgs(Artifact artifact)
    {
      Artifact = artifact;
    }

    public Artifact Artifact { get; }
  }

  public sealed class ArtifactManipulatedEventArgs : EventArgs
  {
    public ArtifactManipulatedEventArgs(Artifact artifact, unit manipulatingUnit)
    {
      Artifact = artifact;
      ManipulatingUnit = manipulatingUnit;
    }

    public Artifact Artifact { get; }
    public unit ManipulatingUnit { get; }
  }

  /// <summary>
  /// Represents a unique, powerful item in the Azeroth Wars universe.
  /// </summary>
  public class Artifact
  {
    private ArtifactStatus _status;
    private string _description;
    private readonly item _item;
    private static readonly Dictionary<item, Artifact> _byItem = new();

    public Artifact(item item)
    {
      _item = item;
      PlayerUnitEvents.Register(PlayerUnitEvent.ItemTypeIsPickedUp,
        () => PickedUp?.Invoke(this, new ArtifactEventArgs(this)),
        GetItemTypeId(item));
      PlayerUnitEvents.Register(PlayerUnitEvent.ItemTypeIsDropped,
        () => Dropped?.Invoke(this, new ArtifactEventArgs(this)),
        GetItemTypeId(item));
      ArtifactCreated?.Invoke(this, new ArtifactEventArgs(this));
    }

    ~Artifact()
    {
      //TODO: Unregister events
      Destroyed?.Invoke(this, new ArtifactEventArgs(this));
      _byItem[_item] = null;
      throw new NotImplementedException();
    }

    public static event EventHandler<ArtifactEventArgs> ArtifactCreated;
    public event EventHandler<ArtifactEventArgs> PickedUp;
    public event EventHandler<ArtifactEventArgs> Dropped;
    public event EventHandler<ArtifactEventArgs> Destroyed;
    public event EventHandler<ArtifactEventArgs> OwnerChanged;
    public event EventHandler<ArtifactEventArgs> StatusChanged;
    public event EventHandler<ArtifactEventArgs> FactionChanged;
    public event EventHandler<ArtifactEventArgs> CarrierOwnedChanged;
    public event EventHandler<ArtifactEventArgs> DescriptionChanged;

    public static Artifact ByItem(item whichItem)
    {
      return _byItem[whichItem];
    }

    /// <summary>
    /// Registers Warcraft 3 native triggers related to Artifacts.
    /// </summary>
    public static void Initialize()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Where the artifact is considered to be; meaningful to the user interface only.
    /// </summary>
    public ArtifactStatus Status
    {
      get
      {
        return _status;
      }
      set
      {
        _status = value;
        StatusChanged?.Invoke(this, new ArtifactEventArgs(this));
      }
    }

    /// <summary>
    /// A short piece of text describing the Artifact's status.
    /// </summary>
    public string Description
    {
      get
      {
        return _description;
      }
      set
      {
        _description = value;
        DescriptionChanged?.Invoke(this, new ArtifactEventArgs(this));
      }
    }

    /// <summary>
    /// The unit carrying the Artifact.
    /// </summary>
    public unit OwningUnit
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    /// <summary>
    /// Pings the Artifact on the minimap.
    /// </summary>
    public void Ping()
    {
      throw new NotImplementedException();
    }

    private static void OnUnitCarryingArtifactChangesOwner()
    {
      throw new NotImplementedException();
    }

    private static void OnPersonChangesFaction()
    {
      throw new NotImplementedException();
    }
  }
}
