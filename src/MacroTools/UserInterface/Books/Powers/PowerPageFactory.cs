using MacroTools.UserInterface.Books.Core;
using MacroTools.UserInterface.Frames;

namespace MacroTools.UserInterface.Books.Powers;

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
    newPage.SetPoint(framepointtype.Center, parent, framepointtype.Center, 0, 0);

    return newPage;
  }
}
