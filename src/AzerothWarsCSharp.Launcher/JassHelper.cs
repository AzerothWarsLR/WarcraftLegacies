using System;
using System.Collections.Generic;
using System.IO;

namespace AzerothWarsCSharp.Launcher
{
  public class JassHelper
  {
    private readonly string _blizzardjPath;
    private readonly string _commonjPath;
    private readonly string _executablePath;
    private readonly string _tempFileDirectoryPath;

    public JassHelper(string executablePath, string commonjPath, string blizzardjPath, string tempFileDirectoryPath)
    {
      _executablePath = Path.GetFullPath(executablePath);
      _commonjPath = commonjPath;
      _blizzardjPath = blizzardjPath;
      _tempFileDirectoryPath = tempFileDirectoryPath;
    }

    /// <summary>
    ///   Merges all vJASS .j files in a number of directories and their subdirectories into a single .j file,
    ///   then merges that with a single JASS war3map.j file in a Warcraft 3 map,
    ///   then compiles that result using JASSHelper.
    /// </summary>
    public void CombineVJassWithJass(string vJassFilePath, IEnumerable<string> jassDirectories, string outputFilePath)
    {
      var mergedJFilePath = Path.Combine(_tempFileDirectoryPath, "merged.j");
      using (var writer = new StreamWriter(mergedJFilePath))
      {
        using (var reader = File.OpenText(vJassFilePath))
        {
          writer.Write(reader.ReadToEnd());
        }

        foreach (var directory in jassDirectories)
        {
          var allJassFilesInDirectory = Directory.GetFiles(directory, "*.j", SearchOption.AllDirectories);
          {
            foreach (var t in allJassFilesInDirectory)
            {
              using var reader = File.OpenText(t);
              writer.Write(Environment.NewLine + reader.ReadToEnd());
            }
          }
        }
      }
      WriteCompiledJass(mergedJFilePath, outputFilePath);
    }

    private void WriteCompiledJass(string file, string newFileName)
    {
      File.Create(newFileName).Close();
      CommandLineUtils.RunCommand(_executablePath, new[]
      {
        "--scriptonly",
        _commonjPath,
        _blizzardjPath,
        file,
        newFileName
      });
    }
  }
}