using System.Collections.Generic;
using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Fel_Horde
{
  /// <summary>
  /// Fel Horde opens the Dark Portal.
  /// </summary>
  public sealed class QuestDarkPortalOpen : QuestData
  {
    private readonly Dictionary<unit, Point> _portalDestinations;

    //todo: bad flavour
    /// <inheritdoc />
    public QuestDarkPortalOpen(PreplacedUnitSystem preplacedUnitSystem) : base("The Dark Portal Opens",
      "The Dark Portal has been opened", "ReplaceableTextures\\CommandButtons\\BTNDarkPortal.blp")
    {
      _portalDestinations = new Dictionary<unit, Point>
      {
        {
          preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL, new Point(4570, -24734)),
          Regions.Dark_Portal_Entrance_3.Center
        },
        {
          preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL, new Point(4701, -25372)),
          Regions.Dark_Portal_Entrance_1.Center
        },
        {
          preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL, new Point(5217, -25751)),
          Regions.Dark_Portal_Entrance_2.Center
        },
        {
          preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL, new Point(15581, -19540)),
          Regions.Dark_Portal_Exit_2.Center
        },
        {
          preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL, new Point(16552, -19148)),
          Regions.Dark_Portal_Exit_1.Center
        },
        {
          preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL, new Point(17442, -19218)),
          Regions.Dark_Portal_Exit_3.Center
        }
      };
      foreach (var portal in _portalDestinations.Keys)
        portal.Show(false);
      Required = true;
    }

    /// <inheritdoc />
    protected override string CompletionPopup => "The Dark Portal is now open";

    /// <inheritdoc />
    protected override string RewardDescription => "The Dark Portal is now open";

    /// <inheritdoc />
    protected override void OnComplete(Faction whichFaction) => OpenPortals();

    /// <inheritdoc />
    protected override void OnFail(Faction whichFaction) => OpenPortals();

    private void OpenPortals()
    {
      foreach (var (portal, portalDestination) in _portalDestinations)
      {
        portal.Show(true)
          .SetAnimation("birth")
          .QueueAnimation("stand")
          .SetWaygateDestination(portalDestination);
      }

      _portalDestinations.Clear();
    }
  }
}