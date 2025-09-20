using MacroTools.BookSystem.Core;
using MacroTools.Frames;

namespace MacroTools.BookSystem.Powers;

public sealed class PowerPageFactory : IPageFactory<PowerPage>
{
  /// <inheritdoc />
  public PowerPage Create(float width, float height, int pageNumber, Frame parent)
  {
    var newPage = new PowerPage(width, height)
    {
      PageNumber = pageNumber,
      Parent = parent,
      Visible = false
    };
    newPage.SetPoint(FRAMEPOINT_CENTER, parent, FRAMEPOINT_CENTER, 0, 0);

    return newPage;
  }
}
