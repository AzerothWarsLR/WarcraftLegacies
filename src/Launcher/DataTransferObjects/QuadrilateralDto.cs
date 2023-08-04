using System.Numerics;

namespace Launcher.DataTransferObjects
{
  public sealed class QuadrilateralDto
  {
    public Vector2 BottomLeft { get; set; }

    public Vector2 TopRight { get; set; }

    public Vector2 TopLeft { get; set; }

    public Vector2 BottomRight { get; set; }
  }
}