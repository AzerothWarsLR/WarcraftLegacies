using MacroTools.UserInterface.Books.Core;
using MacroTools.UserInterface.Frames;

namespace MacroTools.UserInterface.Books.Paths;

public sealed class PathPageFactory : IPageFactory<PathPage>
{
  /// <inheritdoc />
  public PathPage Create(float width, float height, int pageNumber, Frame parent)
  {
    var newPage = new PathPage(width, height)
    {
      PageNumber = pageNumber,
      Parent = parent,
      Visible = false
    };
    newPage.SetPoint(framepointtype.Center, parent, framepointtype.Center, 0, 0);

    return newPage;
  }
}
