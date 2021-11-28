using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using War3Api.Object;
using War3Net.Build.Extensions;
#pragma warning disable 8618

namespace AzerothWarsCSharp.IntegrityChecker.Tests
{
  [TestClass]
  public class MapIntegrityCheckerTests
  {
    private const string BaseObjectPath = @"..\..\..\..\..\source.w3o";
    private const string RootMapFolderPath = @"maps\test\";
    private static ObjectDatabase _objectDatabase;
    
    [ClassInitialize()]
    public static void ClassInit(TestContext context)
    {
      using var fileStream = File.OpenRead(BaseObjectPath);
      using var binaryReader = new BinaryReader(fileStream);
      var objectData = binaryReader.ReadObjectData(false);
      _objectDatabase = new ObjectDatabase();
      _objectDatabase.AddObjects(objectData);
    }

    [TestMethod]
    [DataRowAttribute(@"war3mapImported\Arthas.mdx")]
    [DataRowAttribute(@"war3mapImported\Arthas_portrait.mdx")]
    [DataRowAttribute("CaptainBananas.mdl")]
    public void ObjectDatabaseContainsModel_NonexistentModel_False(string modelPath)
    {
      var model = new ModelData(Path.Combine(RootMapFolderPath, modelPath), RootMapFolderPath);
      Assert.IsFalse(MapIntegrityChecker.ObjectDatabaseContainsModel(_objectDatabase, model));
    }
    
    [DataTestMethod]
    [DataRowAttribute(@"war3mapImported\Mograine.mdx")]
    [DataRowAttribute(@"war3mapImported\Mograine_portrait.mdx")]
    [DataRowAttribute(@"war3mapImported\Mograine_Portrait.mdx")]
    [DataRowAttribute(@"war3mapImported\Morgraine.mdx")]
    [DataRowAttribute(@"war3mapImported\Morgraine_portrait.mdx")]
    [DataRowAttribute(@"war3mapImported\Morgraine_Portrait.mdx")]
    [DataRowAttribute(@"war3mapImported\RenaultMograine.mdx")]
    [DataRowAttribute(@"war3mapImported\RenaultMograine_portrait.mdx")]
    [DataRowAttribute(@"war3mapImported\RenaultMograine_Portrait.mdx")]
    [DataRowAttribute("CaptainGilneasV1.03.mdl")]
    [DataRowAttribute(@"war3mapImported\HolyNova_Fixed.mdx")]
    public void ObjectDatabaseContainsModel_ExistingModel_True(string modelPath)
    {
      var model = new ModelData(Path.Combine(RootMapFolderPath, modelPath), RootMapFolderPath);
      Assert.IsTrue(MapIntegrityChecker.ObjectDatabaseContainsModel(_objectDatabase, model));
    }
  }
}