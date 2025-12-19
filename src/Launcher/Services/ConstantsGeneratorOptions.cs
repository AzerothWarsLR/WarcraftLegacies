namespace Launcher.Services;

public sealed class ConstantsGeneratorOptions
{
  public static ConstantsGeneratorOptions Create(SharedPathOptions sharedPathOptions)
  {
    return new ConstantsGeneratorOptions
    {
      ConstantsOutputPath = sharedPathOptions.SharedProjectPath,
      RegionsOutputPath = sharedPathOptions.SourceProjectPath
    };
  }

  public required string ConstantsOutputPath { get; init; }

  public required string RegionsOutputPath { get; init; }
}
