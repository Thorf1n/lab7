

namespace Calculator_T
{
   
    
        public class MathCalculator<T>
        {
            private readonly Random random = new Random();

            public delegate T OperationDelegate(T a, T b);

            public OperationDelegate AdditionDelegate { get; set; }
            public OperationDelegate SubtractionDelegate { get; set; }
            public OperationDelegate MultiplicationDelegate { get; set; }
            public OperationDelegate DivisionDelegate { get; set; }

            public MathCalculator(OperationDelegate addition, OperationDelegate subtraction, OperationDelegate multiplication, OperationDelegate division)
            {
                AdditionDelegate = addition;
                SubtractionDelegate = subtraction;
                MultiplicationDelegate = multiplication;
                DivisionDelegate = division;
            }

            public T GetRandomValue()
            {
                if (typeof(T) == typeof(int))
                {
                    return (T)(object)random.Next(1, 100);
                }
                else if (typeof(T) == typeof(double))
                {
                    return (T)(object)(random.NextDouble() * 100);
                }
                else
                {
                    throw new NotSupportedException($"Type {typeof(T)} is not supported.");
                }
            }

            public void PerformRandomOperation()
            {
                T a = GetRandomValue();
                T b = GetRandomValue();

                Console.WriteLine($"Random Values: {a}, {b}");
                Console.WriteLine("Addition: " + AdditionDelegate(a, b));
                Console.WriteLine("Subtraction: " + SubtractionDelegate(a, b));
                Console.WriteLine("Multiplication: " + MultiplicationDelegate(a, b));
                Console.WriteLine("Division: " + DivisionDelegate(a, b));
            }
        }  
}
