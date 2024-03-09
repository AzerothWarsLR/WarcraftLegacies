using MacroTools.ArtifactSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;

namespace WarcraftLegacies.Source.FactionMechanics.Scourge
{
  /// <summary>
  ///  When Scourge leaves the game, drop the Helm of Domination to an easily accessible position since the default position is hard to see.
  /// </summary>
  public static class HelmOfDominationDropsWhenScourgeLeaves
  {
    private static Factions.Scourge? _scourge;
    private static Artifact? _helmOfDomination;
    private static trigger? _deathTrigger;
    private static Capital? _lichKing;

    /// <summary>
    /// Sets up <see cref="HelmOfDominationDropsWhenScourgeLeaves"/>.
    /// </summary>
    public static void Setup(Factions.Scourge scourge, Artifact helmOfDomination, Capital lichKing)
    {
      _scourge = scourge;
      _lichKing = lichKing;

      _deathTrigger = CreateTrigger();
      _deathTrigger.RegisterUnitEvent(lichKing.Unit, EVENT_UNIT_DEATH);
      _deathTrigger.AddAction(() =>
        {
          MaybeDropHelmOfDomination();
          UnregisterEvents();
        });

      scourge.ScoreStatusChanged += OnScourgeScoreStatusChanged;
      _helmOfDomination = helmOfDomination;
    }

    private static void OnScourgeScoreStatusChanged(object? sender, Faction faction)
    {
      if (faction.ScoreStatus != ScoreStatus.Defeated) 
        return;
      
      MaybeDropHelmOfDomination();
      UnregisterEvents();
    }

    private static void UnregisterEvents()
    {
      _deathTrigger?.Dispose();
      _scourge.ScoreStatusChanged -= OnScourgeScoreStatusChanged;
    }

    private static void MaybeDropHelmOfDomination()
    {
      if (_lichKing?.Unit == null || !UnitHasItem(_lichKing.Unit, _helmOfDomination?.Item))
        return;

      var lichKingPosition = _lichKing.Unit.GetPosition();
      _lichKing.Unit.DropAllItems();
      _helmOfDomination.Item.X = lichKingPosition.X - 55;
      _helmOfDomination.Item.Y = lichKingPosition.Y + 30;
    }
  }
}