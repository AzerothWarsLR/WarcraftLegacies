namespace Launcher.DataTransferObjects;

public sealed class QuadrilateralDto
{
  public Vector2Dto BottomLeft { get; set; }

  public Vector2Dto TopRight { get; set; }

  public Vector2Dto TopLeft { get; set; }

  public Vector2Dto BottomRight { get; set; }
}
