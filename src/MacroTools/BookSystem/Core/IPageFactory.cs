using MacroTools.Frames;

namespace MacroTools.BookSystem.Core;

public interface IPageFactory<out TPage>
{
  /// <summary>
  /// Creates a Page of the specified type.
  /// </summary>
  public TPage Create(float width, float height, int pageNumber, Frame parent);
}
