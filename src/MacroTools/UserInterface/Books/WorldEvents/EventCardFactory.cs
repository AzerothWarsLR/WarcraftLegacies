using MacroTools.UserInterface.Books.Core;
using MacroTools.UserInterface.Frames;

namespace MacroTools.UserInterface.Books.WorldEvents;

public sealed class EventCardFactory : ICardFactory<EventCard>
{
  /// <inheritdoc />
  public EventCard Create(Frame parent)
  {
    return new EventCard(parent);
  }
}
