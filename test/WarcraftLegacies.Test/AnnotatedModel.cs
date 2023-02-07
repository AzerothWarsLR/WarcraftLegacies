using ModelTester;

namespace WarcraftLegacies.Test
{
  /// <summary>
  /// An <see cref="MDX"/> which has been annotated with user-provided data.
  /// </summary>
  public sealed class AnnotatedModel
  {
    public MDX Model { get; }
    
    public ModelAnnotation? Annotation { get; }

    public AnnotatedModel(MDX model, ModelAnnotation? annotation)
    {
      Model = model;
      Annotation = annotation;
    }
  }
}