namespace AzerothWarsCSharp.Source.UserInterface
{
  public class MultiboardItemData
  {
    public string Value { get; set; }

    public float Width { get; set; }

    public string Icon { get; set; }

    public Color Color { get; set; } = new Color(255, 255, 255, 255);

    public bool ShowValue { get; set; }
    
    public bool ShowIcon { get; set; }
  }
}