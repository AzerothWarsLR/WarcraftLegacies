using WCSharp.Missiles;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Spells
{
  public sealed class ApocalypseProjectile : BasicMissile
  {
    /// <inheritdoc />
    public ApocalypseProjectile(player castingPlayer, float casterX, float casterY, float targetX, float targetY) :
      base(castingPlayer, casterX, casterY, targetX, targetY)
    {
    }
  }
}