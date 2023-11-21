using System;

namespace MacroTools.FactionSystem
{
  /// <summary>
  /// A <see cref="Faction"/> initializer that is dependent on the registration of another <see cref="Faction"/> type
  /// to work.
  /// </summary>
  public sealed class FactionDependentInitializer
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="FactionDependentInitializer"/> class.
    /// </summary>
    /// <param name="factionDependency">The <see cref="Type"/> of the <see cref="Faction"/> that this initializer is dependent on.</param>
    /// <param name="initializerAction">The <see cref="Action"/> to run when the depended on <see cref="Faction"/> <see cref="Type"/> exists.</param>
    public FactionDependentInitializer(Type factionDependency, Action initializerAction)
    {
      FactionDependency = factionDependency;
      _initializerAction = initializerAction;
    }
    
    /// <summary>
    /// The <see cref="Type"/> of the <see cref="Faction"/> that this initializer is dependent on.
    /// </summary>
    public Type FactionDependency { get; }

    /// <summary>
    /// The <see cref="Action"/> to run when the depended on <see cref="Faction"/> <see cref="Type"/> exists.
    /// </summary>
    private readonly Action _initializerAction;
    
    /// <summary>
    /// Whether or not the initializer has already been run.
    /// </summary>
    public bool Executed { get; private set; }

    /// <summary>
    /// Executes the initializer.
    /// </summary>
    public void Execute()
    {
      if (Executed)
        return;
      
      _initializerAction();
      Executed = true;
    }
  }
}