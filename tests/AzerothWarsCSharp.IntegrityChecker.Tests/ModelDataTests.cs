using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AzerothWarsCSharp.IntegrityChecker.Tests
{
  [TestClass]
  public class ModelDataTests
  {
    private const string RootMapFolderPath = @"maps\test\";
    
    [DataTestMethod]
    [DataRow("TestModel_portrait.mdx")]
    [DataRow("TestModel_Portrait.mdx")]
    public void ModelData_IsPortrait_True(string modelPath)
    {
      var modelData = new ModelData(Path.Combine(RootMapFolderPath, modelPath), RootMapFolderPath);
      Assert.IsTrue(modelData.IsPortrait);
    }
    
    [DataTestMethod]
    [DataRow("TestModel.mdx")]
    [DataRow("TestModel_BigMan.mdx")]
    public void ModelData_IsPortrait_False(string modelPath)
    {
      var modelData = new ModelData(Path.Combine(RootMapFolderPath, modelPath), RootMapFolderPath);
      Assert.IsFalse(modelData.IsPortrait);
    }

    [TestMethod]
    public void ModelData_RelativePathMdx()
    {
      var modelData = new ModelData(@"maps\test\TestModel.mdx", RootMapFolderPath);
      Assert.AreEqual("TestModel.mdx", modelData.RelativePathMdx);
    }
    
    [TestMethod]
    public void ModelData_RelativePathMdl()
    {
      var modelData = new ModelData(@"maps\test\TestModel.mdx", RootMapFolderPath);
      Assert.AreEqual("TestModel.mdl", modelData.RelativePathMdl);
    }

    [DataTestMethod]
    [DataRow("TestModel_portrait.mdx", "TestModel.mdl")]
    [DataRow("TestModel_Portrait.mdx", "TestModel.mdl")]
    public void ModelData_RelativePathWithoutPortraitSuffixMdl_Equal(string modelWithPortraitSuffix, string modelWithoutPortraitSuffix)
    {
      var modelData = new ModelData(Path.Combine(RootMapFolderPath, modelWithPortraitSuffix), RootMapFolderPath);
      Assert.AreEqual(modelWithoutPortraitSuffix, modelData.RelativePathWithoutPortraitSuffixMdl);
    }
  }
}