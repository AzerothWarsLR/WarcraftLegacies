using System;
using System.Diagnostics.CodeAnalysis;
using MacroTools.Utils;
using WarcraftLegacies.Source.Setup;

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
      Start();
    });
  }

  private static void Start()
  {
    try
    {
      GameSetup.Setup();
    }
    catch (Exception ex)
    {
      Logger.LogError(ex.ToString());
    }
  }
}
