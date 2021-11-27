using System;
using System.Diagnostics;

namespace AzerothWarsCSharp.Launcher
{
  public static class CommandLineUtils
  {
    private const string Quote = "\"";

    public static void RunCommand(string cmd, string[] argumentArray)
    {
      //Add quotes around the command if necessary
      if (cmd.Contains(" "))
      {
        cmd = Quote + cmd + Quote;
      }
      //Add quotes around the arguments if they have spaces in them
      var arguments = "";
      var i = 0;
      foreach (var argument in argumentArray) {
        if (argument.Contains(" "))
        {
          arguments = arguments + Quote + argument + Quote;
        } else
        {
          arguments += argument;
        }
        i++;
        if (i < argumentArray.Length)
        {
          arguments += " ";
        }
      }
      var procStartInfo = new ProcessStartInfo("cmd", $"/c {cmd} {arguments}")
      {
        RedirectStandardError = true,
        RedirectStandardOutput = true,
        UseShellExecute = false,
        CreateNoWindow = true,
      };
      var proc = new Process
      {
        StartInfo = procStartInfo,
      };
      proc.Start();
      proc.WaitForExit();
      var result = proc.StandardError.ReadToEnd();

      if (result.Length > 0) {
        throw new Exception(result);
      }
    }
  }
}