using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.MacroTools
{
  public static class ItemExtensions
  {
    public static void SetPosition(this item whichItem, Point position)
    {
      SetItemPosition(whichItem, position.X, position.Y);
    }

    public static Point GetPosition(this item whichItem)
    {
      return new Point(GetItemX(whichItem), GetItemY(whichItem));
    }
  }
}