using System;
using MacroTools.ArtifactSystem;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// Makes a held <see cref="Artifact"/> stronger permanently.
/// </summary>
public sealed class TitanForgeArtifact : Spell
{
  private readonly int _goldCost;

  /// <inheritdoc />
  public TitanForgeArtifact(int id, int goldCost) : base(id)
  {
    _goldCost = goldCost;
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    try
    {
      var heldItem = @event.Unit.ItemAtOrDefault(0);
      if (heldItem == null)
      {
        Refund(@event.Player);
        return;
      }

      var heldArtifact = ArtifactManager.GetFromTypeId(heldItem.TypeId);
      if (heldArtifact != null && !heldArtifact.Titanforged)
      {
        heldArtifact.Titanforge();
        return;
      }

      Refund(@event.Player);
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
    }
  }

  private void Refund(player whichPlayer) => whichPlayer.Gold += _goldCost;
}
