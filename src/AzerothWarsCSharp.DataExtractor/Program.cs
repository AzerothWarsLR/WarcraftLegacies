using System.IO;
using System.Text;
using War3Net.Build.Extensions;

namespace AzerothWarsCSharp.DataExtractor
{
  internal static class Program
  {
    private const string TEST_OUTPUT_PATH = @"..\..\..\..\..\src\AzerothWarsCSharp.Launcher\ObjectFactory\Generated.cs";
    private const string BASE_OBJECT_PATH = @"..\..\..\..\..\source.w3o";

    public static void Main()
    {
      using var fileStream = File.OpenRead(BASE_OBJECT_PATH);
      using var binaryReader = new BinaryReader(fileStream);
      var objectData = binaryReader.ReadObjectData(false);
      var stringBuilder = new StringBuilder();
      stringBuilder.Append(new UnitFactoryGenerator().GenerateAll(objectData));
      File.WriteAllText(TEST_OUTPUT_PATH, stringBuilder.ToString());
    }
  }
}