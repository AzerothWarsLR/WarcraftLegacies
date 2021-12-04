using AzerothWarsCSharp.MacroTools;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.QuestOutcomes
{
  public class QuestOutcomeSpawnLegend : QuestOutcome
  {
    private readonly Legend _legend;
    private readonly Point _point;
    private readonly int _startingLevel;
    
    public QuestOutcomeSpawnLegend(Legend legend, Point point, string locationName, int startingLevel)
    {
      Description = $"{legend.Name} spawns at {locationName} at level {startingLevel.ToString()}";
      _legend = legend;
      _point = point;
      _startingLevel = startingLevel;
    }
    
    public override void Fire()
    {
      _legend.CreateOnMap(_point);
      SetHeroLevel(_legend.Unit, _startingLevel, true);
    }
  }
}