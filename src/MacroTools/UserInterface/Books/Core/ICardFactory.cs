using MacroTools.UserInterface.Frames;

namespace MacroTools.UserInterface.Books.Core;

public interface ICardFactory<out TCard>
{
  /// <summary>
  /// Creates a Card of the specified type.
  /// </summary>
  public TCard Create(Frame parent);
}
