using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.ShoreSystem;
using WCSharp.Events;

namespace MacroTools.ArtifactSystem;

/// <summary>
/// Manages all <see cref="Artifact"/>s by maintaining a list of registered <see cref="Artifact"/>s indexed by item type,
/// and by firing <see cref="Artifact"/> related events.
/// <para>When a hero carrying an <see cref="Artifact"/> dies, the <see cref="Artifact"/> is dropped to the floor,
/// or to the nearest <see cref="Shore"/> if the hero died on the water.</para>
/// </summary>
public static class ArtifactManager
{
  private static readonly Dictionary<int, Artifact> _artifactsByType = new();
  private static readonly Dictionary<string, Artifact> _artifactsByName = new();
  private static readonly List<Artifact> _allArtifacts = new();

  /// <summary>
  /// Fired when an <see cref="Artifact"/> is newly registered to the system.
  /// </summary>
  public static event EventHandler<Artifact>? ArtifactRegistered;

  /// <summary>
  /// Returns the registered <see cref="Artifact"/> that represents the item with the provided item type ID.
  /// If there isn't one, returns null.
  /// </summary>
  public static Artifact? GetFromTypeId(int typeId) =>
    _artifactsByType.ContainsKey(typeId) ? _artifactsByType[typeId] : null;

  /// <summary>
  /// Returns the registered <see cref="Artifact"/> with the given name.
  /// <para>Case insensitive.</para>
  /// <para>Returns null if there is no match.</para>
  /// </summary>
  public static bool TryGetByName(string name, [NotNullWhen(true)] out Artifact? artifact)
  {
    artifact = _artifactsByName.TryGetValue(name.ToLower(), out var value) ? value : null;
    return artifact != null;
  }

  /// <summary>
  /// Registers an <see cref="Artifact"/> to the <see cref="ArtifactManager"/>.
  /// </summary>
  public static void Register(Artifact artifact)
  {
    if (!_artifactsByType.ContainsKey(artifact.Item.TypeId))
    {
      artifact.Item.IsDroppedOnDeath = false;
      _artifactsByType[artifact.Item.TypeId] = artifact;
      _artifactsByName.Add(artifact.Item.Name.ToLower(), artifact);
      ArtifactRegistered?.Invoke(artifact, artifact);
      _allArtifacts.Add(artifact);
    }
    else
    {
      throw new Exception($"Attempted to create already existing Artifact from {artifact.Item.Name}.");
    }
  }

  /// <summary>
  /// Returns all <see cref="Artifact"/>s registered to the system.
  /// </summary>
  public static IEnumerable<Artifact> GetAllArtifacts() =>
    _allArtifacts.AsReadOnly().OrderBy(a => a.Item.Name);

  /// <summary>
  /// Completely removes the given Artifact from the game.
  /// </summary>
  /// <param name="artifact"></param>
  public static void Destroy(Artifact artifact)
  {
    _allArtifacts.Remove(artifact);
    _artifactsByType.Remove(artifact.Item.TypeId);
    _artifactsByName.Remove(artifact.Item.Name);
    artifact.Dispose();
  }

  private static void RegisterItemSinkingPrevention()
  {
    //When a hero carrying an Artifact dies, the Artifact is dropped to the floor,
    // or to the nearest Shore if the hero died on the water.
    PlayerUnitEvents.Register(UnitTypeEvent.Dies, () =>
    {
      try
      {
        var triggerUnit = @event.Unit;
        if (triggerUnit.IsUnitType(unittype.Summoned) || triggerUnit.IsIllusion)
        {
          return;
        }

        bool? isPositionPathable = null;
        for (var i = 0; i < 6; i++)
        {
          var itemInSlot = triggerUnit.ItemAtOrDefault(i);
          if (itemInSlot == null || !itemInSlot.IsDroppable)
          {
            continue;
          }

          var artifactInSlot = GetFromTypeId(itemInSlot.TypeId);
          if (artifactInSlot == null)
          {
            continue;
          }

          isPositionPathable ??= !pathingtype.Walkability.GetPathable(triggerUnit.X, triggerUnit.Y);

          if (isPositionPathable == true)
          {
            itemInSlot.SetPosition(triggerUnit.GetPosition());
          }
          else
          {
            var shore = ShoreManager.GetNearestShore(triggerUnit.GetPosition());
            if (shore == null)
            {
              throw new InvalidOperationException(
                $"{nameof(ArtifactManager)} could not find a {nameof(Shore)} to dump an {nameof(Artifact)}.");
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

  static ArtifactManager()
  {
    RegisterItemSinkingPrevention();
  }
}
