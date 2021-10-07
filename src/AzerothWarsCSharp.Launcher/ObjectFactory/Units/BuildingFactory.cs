using System.Collections.Generic;
using System.Linq;
using System.Text;
using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Units
{
  public class BuildingFactory : UnitFactory
  {
    private void GenerateTooltip()
    {
      var tooltipBuilder = new StringBuilder();
      tooltipBuilder.Append($"{Flavour}|n");
      tooltipBuilder.Append($"|n|c006969FFHit points|r: {_unit.StatsHitPointsMaximumBase}");
      //Trains
      if (_unit.TechtreeUnitsTrained != null && _unit.TechtreeUnitsTrained.Count() > 0)
      {
        tooltipBuilder.Append($"|n|c006969FFTrains|r: ");
        foreach (var unitTrained in _unit.TechtreeUnitsTrained)
        {
          tooltipBuilder.Append($"{unitTrained.TextName}");
        }
      }
      //Researches
      if (_unit.TechtreeResearchesAvailable != null && _unit.TechtreeResearchesAvailable.Count() > 0)
      {
        tooltipBuilder.Append($"|n|c006969FFResearches|r: ");
        foreach (var research in _unit.TechtreeResearchesAvailable)
        {
          tooltipBuilder.Append($"{research.TextName}");
        }
      }
      _unit.TextTooltipExtended = tooltipBuilder.ToString();
    }

    /// <summary>
    /// Generate a building instance.
    /// </summary>
    public new Unit Generate()
    {
      GenerateTooltip();
      return _unit;
    }

    /// <summary>
    /// Units that can be trained by generated buildings.
    /// </summary>
    public IEnumerable<Unit> UnitsTrained
    {
      set
      {
        _unit.TechtreeUnitsTrained = value;
      }
    }

    /// <summary>
    /// Researches that can be researched by generated buildings.
    /// </summary>
    public IEnumerable<Upgrade> ResearchesAvailable
    {
      set
      {
        _unit.TechtreeResearchesAvailable = value;
      }
    }

    public IEnumerable<PathingRequire> PathingPrevent
    {
      set
      {
        _unit.PathingPlacementPreventedBy = value;
      }
    }

    public IEnumerable<PathingPrevent> PathingRequire
    {
      set
      {
        _unit.PathingPlacementRequires = value;
      }
    }

    public BuildingFactory(UnitType baseType, string newRawCode) : base(baseType, newRawCode)
    {
    }
  }
}