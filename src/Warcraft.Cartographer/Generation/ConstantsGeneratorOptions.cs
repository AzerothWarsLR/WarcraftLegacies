using Warcraft.Cartographer.Paths;

namespace Warcraft.Cartographer.Generation;

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

  public static ConstantsGeneratorOptions CreateFor24p(SharedPathOptions sharedPathOptions)
  {
    return new ConstantsGeneratorOptions
    {
      ConstantsOutputPath = Path.Combine(sharedPathOptions.SourceProjectPath, "Constants"),
      RegionsOutputPath   = Path.Combine(sharedPathOptions.SourceProjectPath, "Regions")
    };
  }

  public required string ConstantsOutputPath { get; init; }
  public required string RegionsOutputPath { get; init; }
}
