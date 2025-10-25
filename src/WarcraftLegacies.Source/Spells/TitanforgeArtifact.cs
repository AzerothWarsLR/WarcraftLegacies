using System;
using System.Collections.Generic;
using MacroTools.ArtifactSystem;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// Makes a held <see cref="Artifact"/> stronger permanently.
/// </summary>
public sealed class TitanForgeArtifact : Spell
{
  /// <summary>
  /// Certain Artifacts can gain a unique effect when Titanforged. If nothing is set here,
  /// <see cref="DefaultTitanforgedAbility"/> will be used instead.
  /// </summary>
  public required Dictionary<int, int> UniqueTitanforgedAbilitiesByItemTypeId { get; init; }

  public required int DefaultTitanforgedAbility { get; init; }

  public required int GoldCost { get; init; }

  /// <inheritdoc />
  public TitanForgeArtifact(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    try
    {
      var heldItem = @event.Unit.ItemAtOrDefault(0);
      if (heldItem == null)
      {
        @event.Player.Gold += GoldCost;
        return;
      }

      var heldArtifact = ArtifactManager.GetFromTypeId(heldItem.TypeId);
      if (heldArtifact == null || !TryTitanforgeArtifact(heldArtifact))
      {
        @event.Player.Gold += GoldCost;
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
    }
  }

  private bool TryTitanforgeArtifact(Artifact artifact)
  {
    if (!UniqueTitanforgedAbilitiesByItemTypeId.TryGetValue(artifact.Item.TypeId, out var titanforgedAbility))
    {
      titanforgedAbility = DefaultTitanforgedAbility;
    }

    if (artifact.Item.GetAbility(titanforgedAbility) != null)
    {
      return false;
    }

    artifact.Item.AddAbility(titanforgedAbility);
    artifact.Item.ExtendedDescription = $"{artifact.Item.ExtendedDescription}|n|n|cff800000Titanforged|r|n{BlzGetAbilityExtendedTooltip(titanforgedAbility, 0)}";
    artifact.Item.Description = $"{artifact.Item.Description}|n|cff800000Titanforged|r";
    return true;
  }
}
