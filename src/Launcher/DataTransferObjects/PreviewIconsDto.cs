namespace Launcher.DataTransferObjects
{
  public class PreviewIconsDto
  {
    public int FormatVersion { get; set; }
    public Icons[] Icons { get; set; }
  }

  public class Icons
  {
    public int IconType { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Color Color { get; set; }
  }
}