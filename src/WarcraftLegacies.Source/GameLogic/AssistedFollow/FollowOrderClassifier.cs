namespace WarcraftLegacies.Source.GameLogic.AssistedFollow;

/// <summary>
/// Defines the small set of orders that are safe to propagate to followers.
/// </summary>
public static class FollowOrderClassifier
{
  /// <summary>
  /// Converts an issued point order into the explicit point order followers should receive.
  /// </summary>
  public static bool TryGetMirroredPointOrder(int issuedOrderId, out int mirroredOrderId)
  {
    switch (issuedOrderId)
    {
      // A ground right-click is reported as smart. Use an explicit move order so the
      // destination remains fixed instead of retaining smart-order context.
      case ORDER_SMART:
      case ORDER_MOVE:
        mirroredOrderId = ORDER_MOVE;
        return true;
      case ORDER_ATTACK:
        mirroredOrderId = ORDER_ATTACK;
        return true;
      default:
        mirroredOrderId = 0;
        return false;
    }
  }

  /// <summary>
  /// Returns whether the leader is still executing the recorded point order. Warcraft may
  /// expose a ground smart order either as smart or as its normalized move order.
  /// </summary>
  public static bool IsMatchingLeaderOrder(int issuedOrderId, int mirroredOrderId, int currentOrderId) =>
    currentOrderId == issuedOrderId || currentOrderId == mirroredOrderId;

  /// <summary>Returns whether an immediate leader order should also stop its followers.</summary>
  public static bool IsMirroredImmediateOrder(int issuedOrderId) =>
    issuedOrderId == ORDER_STOP || issuedOrderId == ORDER_HOLD_POSITION;

  /// <summary>Returns whether a cache miss can safely be treated as a stationary leader.</summary>
  public static bool IsStationaryLeaderOrder(int currentOrderId) =>
    currentOrderId == 0 || currentOrderId == ORDER_STOP || currentOrderId == ORDER_HOLD_POSITION;

  /// <summary>
  /// Returns whether Reforged's order count contains an order after the active one.
  /// The current order itself is reported as a count of one.
  /// </summary>
  public static bool HasOrderQueuedBehindCurrent(int orderCount) => orderCount > 1;
}
