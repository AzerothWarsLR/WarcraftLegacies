using System.CommandLine;
using AutoMapper;
using Launcher.Services;

namespace Launcher.Commands
{
  public static class W3XToMapDataCommand
  {
    public static void RegisterW3XToMapDataCommand(this RootCommand rootCommand)
    {
      var command = new Command("w3x-to-mapdata", "Converts a Warcraft 3 map file into raw map data.");
      rootCommand.Add(command);

      var baseMapPathArgument = new Argument<string>(
        name: "basemappath",
        description: "The Warcraft 3 map to convert into map data.");
      command.AddArgument(baseMapPathArgument);
      
      var outputDirectoryArgument = new Argument<string>(
        name: "outputDirectory",
        description: "A path to the directory in which the created map data will be stored.");
      command.AddArgument(outputDirectoryArgument);

      command.SetHandler(Run, baseMapPathArgument, outputDirectoryArgument);
    }

    private static void Run(string baseMapPath, string outputDirectory)
    {
      var autoMapperConfig = new AutoMapperConfigurationProvider().GetConfiguration();
      var mapper = new Mapper(autoMapperConfig);
      new W3XToMapDataConverter(mapper).Convert(baseMapPath, outputDirectory);
    }
  }
}