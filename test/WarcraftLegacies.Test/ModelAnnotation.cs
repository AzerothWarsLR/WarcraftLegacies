namespace WarcraftLegacies.Test
{
  /// <summary>
  /// A set of extra information about a model, defined by hand.
  /// This information cannot be automatically generated.
  /// It is used to determine which aspects of the model need to be tested.
  /// </summary>
  
  public sealed class ModelAnnotation
  {
    /// <summary>
    /// A type that determines which aspects of the model need to be tested.
    /// </summary>
    public ModelType ModelType { get; init; }
  }
}