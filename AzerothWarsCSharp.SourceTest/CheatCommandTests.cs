//using AzerothWarsCSharp.Source.Libraries;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Linq;

//namespace AzerothWarsCSharp.SourceTest
//{
//  [TestClass]
//  public class CheatCommandTests
//  {
//    [TestMethod]
//    public void GetChatStringCommandActivator_ReturnsCommand()
//    {
//      var command = CheatCommand.GetChatStringCommandActivator("-test 80 dog 5");
//      Assert.AreEqual("test", command);
//    }

//    [TestMethod]
//    public void GetChatStringCommandParameters_ReturnsParameters()
//    {
//      var parameters = CheatCommand.GetChatStringCommandParameters("-test 80 dog 5").ToList();
//      Assert.IsTrue(parameters.Contains("5"));
//      Assert.IsTrue(parameters.Contains("80"));
//      Assert.IsTrue(parameters.Contains("dog"));
//    }
//  }
//}
