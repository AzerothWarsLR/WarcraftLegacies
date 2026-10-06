using MacroTools.UserInterface.Books.Core;
using MacroTools.UserInterface.Frames;

namespace MacroTools.UserInterface.Books.WorldEvents;

public sealed class EventPageFactory : IPageFactory<EventPage>
{
  /// <inheritdoc />
  public EventPage Create(float width, float height, int pageNumber, Frame parent)
  {
    var newPage = new EventPage(width, height)
    {
      PageNumber = pageNumber,
      Parent = parent,
      Visible = false
    };
    newPage.SetPoint(framepointtype.Center, parent, framepointtype.Center, 0, 0);

    return newPage;
  }
}
