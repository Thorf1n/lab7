namespace Cache
{
    internal class Program
    {
        static void Main()
        {
            FunctionCache<int, string> cache = new FunctionCache<int, string>(CalculateResult);

            int key1 = 1;
            int key2 = 2;

            Console.WriteLine(cache.GetResult(key1)); 
            Console.WriteLine(cache.GetResult(key1)); 

            Console.WriteLine(cache.GetResult(key2)); 

            cache.SetCacheValidityPeriod(key1, TimeSpan.FromMinutes(30));

            Console.WriteLine(cache.GetResult(key1)); 
            System.Threading.Thread.Sleep(TimeSpan.FromMinutes(31));

            Console.WriteLine(cache.GetResult(key1)); 

            Console.ReadLine();
        }

        static string CalculateResult(int key)
        {
            Console.WriteLine($"Calculating result for key: {key}");
            return $"Result for key {key}";
        }
    }
}