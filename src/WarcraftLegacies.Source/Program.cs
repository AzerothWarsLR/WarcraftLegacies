using System;
using System.Diagnostics.CodeAnalysis;
using MacroTools.Setup;
using MacroTools.Utils;

namespace WarcraftLegacies.Source;

public static class Program
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static void Main()
  {
    // Delay a little since some stuff can break otherwise
    timer timer = timer.Create();
    timer.Start(0.01f, false, () =>
    {
      timer.Dispose();
      Beans();
    });
  }

  private static void Beans()
  {
    try
    {
      SetupOrchestrator.RunPreSetup();
      SetupOrchestrator.RunMainSetup();
      SetupOrchestrator.RunPostSetup();
    }
    catch (Exception ex)
    {
      Logger.LogError(ex.ToString());
    }
  }
}
