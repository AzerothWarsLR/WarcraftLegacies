using System;

namespace AzerothWarsCSharp.Source.UserInterface
{
  public class MultiboardItemData
  {
    private Color _color = new(255, 255, 255, 255);

    private string _icon;

    private string _value;

    private float _width;

    public string Value
    {
      get => _value;
      set
      {
        _value = value;
        PropertyChanged?.Invoke(this, new MultiboardItemDataEventArgs(this));
      }
    }

    public float Width
    {
      get => _width;
      set
      {
        _width = value;
        PropertyChanged?.Invoke(this, new MultiboardItemDataEventArgs(this));
      }
    }

    public string Icon
    {
      get => _icon;
      set
      {
        _icon = value;
        PropertyChanged?.Invoke(this, new MultiboardItemDataEventArgs(this));
      }
    }

    public Color Color
    {
      get => _color;
      set
      {
        _color = value;
        PropertyChanged?.Invoke(this, new MultiboardItemDataEventArgs(this));
      }
    }

    public event EventHandler<MultiboardItemDataEventArgs> PropertyChanged;
  }
}