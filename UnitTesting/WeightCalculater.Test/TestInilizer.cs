using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeightCalculater.Test
{
    [TestClass]
   public class TestInilizer
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            context.WriteLine("AssemblyInitialize");
        }
        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {

        }
    }
}
