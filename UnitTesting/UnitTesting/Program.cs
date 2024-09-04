using System;

namespace UnitTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            WeightCalculater whatIsYourWeight = new WeightCalculater(173, "m");
            double idealWeight=whatIsYourWeight.GetIdealWeight();
            Console.WriteLine($"the ideal body weoght is {idealWeight}");
            IfElseBacicTest(idealWeight);

            whatIsYourWeight.gander = "f";
            idealWeight = whatIsYourWeight.GetIdealWeight();
            Console.WriteLine($"the ideal body weoght is {idealWeight}");
            IfElseBacicTest(idealWeight);


            Console.ReadKey();
        }
        static void  IfElseBacicTest(double idealWeight)
        {
            if (idealWeight == 67.25)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Test Succeeded");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Test Faild!");
            }
        }

    }
}
