using System;

namespace Learning03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Verify constructors
            Fraction fraction1 = new Fraction();
            Fraction fraction2 = new Fraction(5);
            Fraction fraction3 = new Fraction(3, 4);
            Fraction fraction4 = new Fraction(1, 3);

            // Verify getters and setters
            Console.WriteLine($"Fraction 1: {fraction1.GetFractionString()}");  // Expected: 1/1
            Console.WriteLine($"Decimal 1: {fraction1.GetDecimalValue()}");    // Expected: 1.0

            Console.WriteLine($"Fraction 2: {fraction2.GetFractionString()}");  // Expected: 5/1
            Console.WriteLine($"Decimal 2: {fraction2.GetDecimalValue()}");    // Expected: 5.0

            Console.WriteLine($"Fraction 3: {fraction3.GetFractionString()}");  // Expected: 3/4
            Console.WriteLine($"Decimal 3: {fraction3.GetDecimalValue()}");    // Expected: 0.75

            Console.WriteLine($"Fraction 4: {fraction4.GetFractionString()}");  // Expected: 1/3
            Console.WriteLine($"Decimal 4: {fraction4.GetDecimalValue()}");    // Expected: 0.333333...

            // Test setters
            fraction1.Numerator = 7;
            fraction1.Denominator = 8;
            Console.WriteLine($"Updated Fraction 1: {fraction1.GetFractionString()}");  // Expected: 7/8
            Console.WriteLine($"Updated Decimal 1: {fraction1.GetDecimalValue()}");    // Expected: 0.875
        }
    }
}