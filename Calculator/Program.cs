

namespace Calculator_T
{
    internal class Program
    {
        static void Main()
        {
            MathCalculator<int> intCalculator = new MathCalculator<int>((a, b) => a + b, (a, b) => a - b, (a, b) => a * b, (a, b) => a / b);
            Console.WriteLine("Integer Calculations:");
            intCalculator.PerformRandomOperation();

            MathCalculator<double> doubleCalculator = new MathCalculator<double>((a, b) => a + b, (a, b) => a - b, (a, b) => a * b, (a, b) => a / b);
            Console.WriteLine("\nDouble Calculations:");
            doubleCalculator.PerformRandomOperation();
        }
    }
}