using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public static EventHandler<ArtifactEventArgs> ArtifactCreated
    {
      get;
    }

    public static EventHandler<ArtifactEventArgs> ArtifactAquired
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

    /// <summary>
    /// Registers Warcraft 3 native triggers related to Artifacts.
    /// </summary>
    public static void Initialize()
    {
      throw new Exception();
    }

    public Artifact(item item) {
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
  }
}
