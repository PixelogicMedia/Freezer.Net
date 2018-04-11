using System.IO;
using Freezer.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Freezer.UnitTests
{
    [TestClass]
    public class GlobalTestSetup
    {
        [AssemblyInitialize]
        public static void Init(TestContext context)
        {
            FreezerGlobal.Initialize();

            if (!Directory.Exists("BmpResults/"))
                Directory.CreateDirectory("BmpResults/"); 
        }
    }
}
