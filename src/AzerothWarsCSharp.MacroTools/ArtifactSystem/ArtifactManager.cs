using System;
using System.Collections.Generic;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.ArtifactSystem
{
  public static class ArtifactManager
  {
    private static readonly Dictionary<int, Artifact> ArtifactsByType = new();
    private static readonly List<Artifact> AllArtifacts = new();
    
    /// <summary>
    /// Fired when an <see cref="Artifact"/> is newly registered to the system.
    /// </summary>
    public static event EventHandler<Artifact>? ArtifactRegistered;
    
    public static Artifact? GetFromTypeId(int typeId) => ArtifactsByType.ContainsKey(typeId) ? null : ArtifactsByType[typeId];

    /// <summary>
    /// Registers an <see cref="Artifact"/> to the <see cref="ArtifactManager"/>.
    /// </summary>
    public static void Register(Artifact artifact)
    {
      if (!ArtifactsByType.ContainsKey(GetItemTypeId(artifact.Item)))
      {
        ArtifactsByType[GetItemTypeId(artifact.Item)] = artifact;
        ArtifactRegistered?.Invoke(artifact, artifact);
        AllArtifacts.Add(artifact);
      }
      else
      { 
        throw new Exception($"Attempted to create already existing Artifact from {GetItemName(artifact.Item)}.");
      }
    }
    
    /// <summary>
    /// Returns all <see cref="Artifact"/>s registered to the system.
    /// </summary>
    public static IEnumerable<Artifact> GetAllArtifacts()
    {
      foreach (var artifact in AllArtifacts) yield return artifact;
    }

    /// <summary>
    /// Completely removes the given Artifact from the game.
    /// </summary>
    /// <param name="artifact"></param>
    public static void Destroy(Artifact artifact)
    {
      AllArtifacts.Remove(artifact);
      ArtifactsByType.Remove(GetItemTypeId(artifact.Item));
      artifact.Dispose();
    }
  }
}