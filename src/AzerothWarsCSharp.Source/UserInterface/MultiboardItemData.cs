using System.Drawing;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.UserInterface
{
  public class MultiboardItemData
  {
    public string Value { get; set; }

    public float Width { get; set; }

    public string Icon { get; set; }

    public Color Color { get; set; }

    public bool ShowValue { get; set; }
    
    public bool ShowIcon { get; set; }
  }
}