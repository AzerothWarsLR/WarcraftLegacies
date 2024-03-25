namespace MacroTools.CommandSystem
{
  /// <summary>
  /// Indicates the minimum and maximum number of parameters something must have.
  /// </summary>
  public readonly ref struct ExpectedParameterCount
  {
    public int Maximum { get; }

    public int Minimum { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExpectedParameterCount"/> class.
    /// </summary>
    /// <param name="minimum">The minimum number of parameters.</param>
    /// <param name="maximum">The maximum number of parameters.</param>
    public ExpectedParameterCount(int minimum, int maximum)
    {
      Minimum = minimum;
      Maximum = maximum;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExpectedParameterCount"/> class.
    /// </summary>
    /// <param name="both">Both the minimum and maximum number of parameters.</param>
    public ExpectedParameterCount(int both)
    {
      Minimum = both;
      Maximum = both;
    }
  }
}