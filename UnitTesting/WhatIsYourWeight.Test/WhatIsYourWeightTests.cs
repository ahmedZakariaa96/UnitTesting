using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace WhatIsYourWeight.Test
{
    [TestClass]
    public class WhatIsYourWeightTests
    {
        [TestMethod]
        //Given_when_then
        public void GetIdealWeight_ganderIs_M_and_HeightIs_173_Reurn_67dot25()
        {

            //arrange;
            WeightCalculater whatIsYourWeight = new WeightCalculater(173, "m");

            //actor;

            //assert;

        }
    }
}
