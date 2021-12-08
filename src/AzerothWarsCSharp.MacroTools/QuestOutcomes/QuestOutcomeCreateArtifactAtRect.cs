using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.QuestOutcomes
{
  public class QuestOutcomeCreateArtifactAtRect : QuestOutcome
  {
    private readonly int _itemTypeId;
    private readonly Rectangle _rect;

    public QuestOutcomeCreateArtifactAtRect(int itemTypeId, Rectangle rect, string locationName)
    {
      Description = $"The Artifact {GetObjectName(itemTypeId)} spawns at {locationName}";
      _itemTypeId = itemTypeId;
      _rect = rect;
    }
    
    public override void Fire()
    {
      var artifact = new Artifact(CreateItem(_itemTypeId, _rect.Center.X, _rect.Center.Y));
      FactionSystem.Add(artifact);
    }
  }
}