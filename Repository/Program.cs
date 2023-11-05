

namespace Repository
{
    internal class Program 
    {
        static void Main()
        {
            GenericRepository<int> intRepository = new GenericRepository<int>();
            intRepository.DisplayRandomNumbers(5);

            GenericRepository<double> doubleRepository = new GenericRepository<double>();
            doubleRepository.DisplayRandomNumbers(5);
        }
    }
}
