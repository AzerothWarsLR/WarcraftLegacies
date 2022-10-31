using System;
using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.Extensions;
using AzerothWarsCSharp.MacroTools.ShoreSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.ArtifactSystem
{
  /// <summary>
  /// Manages all <see cref="Artifact"/>s by maintaining a list of registered <see cref="Artifact"/>s indexed by item type,
  /// and by firing <see cref="Artifact"/> related events.
  /// <para>When a hero carrying an <see cref="Artifact"/> dies, the <see cref="Artifact"/> is dropped to the floor,
  /// or to the nearest <see cref="Shore"/> if the hero died on the water.</para>
  /// </summary>
  public static class ArtifactManager
  {
    private static readonly Dictionary<int, Artifact> ArtifactsByType = new();
    private static readonly List<Artifact> AllArtifacts = new();
    
    /// <summary>
    /// Fired when an <see cref="Artifact"/> is newly registered to the system.
    /// </summary>
    public static event EventHandler<Artifact>? ArtifactRegistered;
    
    /// <summary>
    /// Returns the registered <see cref="Artifact"/> that represents the item with the provided item type ID.
    /// If there isn't one, returns null.
    /// </summary>
    public static Artifact? GetFromTypeId(int typeId) => ArtifactsByType.ContainsKey(typeId) ? ArtifactsByType[typeId] : null;

    /// <summary>
    /// Registers an <see cref="Artifact"/> to the <see cref="ArtifactManager"/>.
    /// </summary>
    public static void Register(Artifact artifact)
    {
      if (!ArtifactsByType.ContainsKey(GetItemTypeId(artifact.Item)))
      {
        SetItemDropOnDeath(artifact.Item, false);
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

    static ArtifactManager()
    {
      //When a hero carrying an Artifact dies, the Artifact is dropped to the floor,
      // or to the nearest Shore if the hero died on the water.
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeDies, () =>
      {
        try
        {
          var triggerUnit = GetTriggerUnit();
        
          bool? isPositionPathable = null;
          for (var i = 0; i < 6; i++)
          {
            var itemInSlot = UnitItemInSlot(triggerUnit, i);
            if (itemInSlot == null)
              continue;
            var artifactInSlot = GetFromTypeId(GetItemTypeId(itemInSlot));

            if (isPositionPathable == null && artifactInSlot != null)
              isPositionPathable = !IsTerrainPathable(GetUnitX(triggerUnit), GetUnitY(triggerUnit), PATHING_TYPE_WALKABILITY);

            if (isPositionPathable == true)
            {
              itemInSlot.SetPosition(triggerUnit.GetPosition());
            }
            else
            {
              var shore = ShoreManager.GetNearestShore(triggerUnit.GetPosition());
              if (shore == null)
              {
                throw new InvalidOperationException($"{nameof(ArtifactManager)} could not find a {nameof(Shore)} to dump an {nameof(Artifact)}.");
              }
              itemInSlot.SetPosition(shore.Position);
            }
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine($"{nameof(ArtifactManager)} failed to handle a unit dying: {ex}");
        }
      });
    }
  }
}