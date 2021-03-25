using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCSharp.Events;
using static War3Api.Common;

namespace AzerothWarsCSharp.Template.Source.Libraries
{
  public enum ArtifactStatus
  {
    Ground,
    Unit,
    Special,
    Hidden
  }

  public class ArtifactEventArgs : EventArgs
  {

  }

  /// <summary>
  /// Represents a unique, powerful item in the Azeroth Wars universe.
  /// </summary>
  public class Artifact
  {
    private ArtifactStatus _status;
    private readonly string _description;
    private readonly Person _owningPerson;
    private static Dictionary<item, Artifact> _byItem = new();

    public Artifact(item item)
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.ItemTypeIsPickedUp, 
        ArtifactPickedUp(EventArgs.Empty), 
        GetItemTypeId(item));
      PlayerUnitEvents.Register(PlayerUnitEvent.ItemTypeIsDropped, OnArtifactDropped, GetItemTypeId(item));
    }

    public static EventHandler<ArtifactEventArgs> ArtifactCreated
    {
      get;
    }

    public static EventHandler<ArtifactEventArgs> ArtifactPickedUp
    {
      get;
    }

    public static EventHandler<ArtifactEventArgs> ArtifactDropped
    {
      get;
    }

    public static EventHandler<ArtifactEventArgs> ArtifactDestroyed
    {
      get;
    }

    public static EventHandler<ArtifactEventArgs> ArtifactOwnerChanged
    {
      get;
    }

    public static EventHandler<ArtifactEventArgs> ArtifactStatusChanged
    {
      get;
    }

    public static EventHandler<ArtifactEventArgs> ArtifactFactionChanged
    {
      get;
    }

    public static EventHandler<ArtifactEventArgs> ArtifactCarrierOwnedChanged
    {
      get;
    }

    public static EventHandler<ArtifactEventArgs> ArtifactDescriptionChanged
    {
      get;
    }

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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
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
    /// The Person owning the unit carrying the artifact.
    /// </summary>
    public Person OwningPerson
    {
      get
      {
        return _owningPerson;
      }
      set
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
