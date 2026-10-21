using MacroTools.UserInterface.Books.Core;
using MacroTools.WorldEvents;

namespace MacroTools.UserInterface.Books.WorldEvents;

public sealed class EventPage : Page<WorldEvent, EventCard, EventCardFactory>
{
  public EventPage(float width, float height) : base(width, height, 2, 2, 0.04f, 0.05f)
  {
  }
}
