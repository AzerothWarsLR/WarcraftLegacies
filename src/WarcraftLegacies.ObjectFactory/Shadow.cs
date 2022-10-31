using War3Api.Object.Enums;

namespace WarcraftLegacies.ObjectFactory
{
  public struct Shadow
  {
    public ShadowImage ShadowImage { get; set; }
    public float CenterX { get; set; }
    public float CenterY { get; set; }
    public float Height { get; set; }
    public float Width { get; set; }
    public string TextureBuilding { get; set; }
    public bool ShowOnWater { get; set; }
  }
}