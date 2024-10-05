using WarcraftLegacies.Shared.Extensions;

namespace WarcraftLegacies.Shared
{
  public sealed class ObjectLimit
  {
    public string ObjectTypeId { get; }
    
    public int Limit { get; }
    
    /// <summary>
    /// If set, indicates to the player how the object's limit can be changed in-game.
    /// </summary>
    public string? LimitIncreaseHint { get; }
    
    [Obsolete("Use the version that takes in two integers instead.")]
    public ObjectLimit(string objectTypeId, int limit, string? limitIncreaseHint = null)
    {
      ObjectTypeId = objectTypeId;
      Limit = limit;
      LimitIncreaseHint = limitIncreaseHint;
    }

    public ObjectLimit(int objectTypeId, int limit, string? limitIncreaseHint = null)
    {
      ObjectTypeId = objectTypeId.IdToFourCc(true);
      Limit = limit;
      LimitIncreaseHint = limitIncreaseHint;
    }

    public void Deconstruct(out string objectTypeId, out ObjectLimit limit)
    {
      objectTypeId = ObjectTypeId;
      limit = this;
    }
  }
}