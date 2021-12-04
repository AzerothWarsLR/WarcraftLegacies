using AzerothWarsCSharp.MacroTools;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.Source.QuestObjectives
{
  public class QuestObjectiveLegendInRect : QuestObjective
  {
    private Legend _targetLegend;
    private Rectangle _targetRectangle;

    public QuestObjectiveLegendInRect(Legend targetLegend, Rectangle targetRectangle, string rectName)
    {
      _targetLegend = targetLegend;
      _targetRectangle = targetRectangle;
      Description = $"{targetLegend.Name} is at {rectName}";
      X = targetRectangle.Center.X;
      Y = targetRectangle.Center.Y;
      HasLocation = true;
    }
  }
}