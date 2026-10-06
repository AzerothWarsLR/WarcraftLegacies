using System;
using System.Collections.Generic;
using MacroTools.Artifacts;
using MacroTools.Extensions;
using MacroTools.Localization;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

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
    var titanforgedAbility = UniqueTitanforgedAbilitiesByItemTypeId.GetValueOrDefault(artifact.Item.TypeId, DefaultTitanforgedAbility);

    if (artifact.Item.GetAbility(titanforgedAbility) != null)
    {
      return false;
    }

    artifact.Item.AddAbility(titanforgedAbility);
    // The word the tooltip gains is looked up rather than written into the sentence: an interpolated string is
    // compiled into a concatenation, so the label beside the localised description stayed English on every client.
    var titanforged = "|cff800000" + Loc.Get("Titanforged") + "|r";
    artifact.Item.ExtendedDescription = $"{artifact.Item.ExtendedDescription}|n|n{titanforged}|n{BlzGetAbilityExtendedTooltip(titanforgedAbility, 0)}";
    artifact.Item.Description = $"{artifact.Item.Description}|n{titanforged}";
    return true;
  }
}
